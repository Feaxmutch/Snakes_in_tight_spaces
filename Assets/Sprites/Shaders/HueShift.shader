Shader "Custom/3D_HueShift"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _HueShift ("Hue Shift", Range(0, 1)) = 0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _HueShift;

            // Корректный сдвиг оттенка через поворот вектора цвета
            float3 ApplyHueShift(float3 color, float shift)
            {
                float3 k = float3(0.57735, 0.57735, 0.57735); // 1 / sqrt(3)
                float angle = shift * 6.28318530718; // 2 * PI
                float cosAngle = cos(angle);
                
                // Формула вращения Родрига
                return color * cosAngle + 
                       cross(k, color) * sin(angle) + 
                       k * dot(k, color) * (1.0 - cosAngle);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                
                // Применяем плавный поворот цветового тона
                col.rgb = ApplyHueShift(col.rgb, _HueShift);
                
                return col;
            }
            ENDCG
        }
    }
}