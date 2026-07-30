Shader "Custom/3D_HueShift_Instanced"
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
            // 1. Включаем генерацию вариантов шейдера для инстансинга
            #pragma multi_compile_instancing

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                // 2. Добавляем индекс инстанса во входные данные вершины
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                // 3. Передаем индекс инстанса из вершинного шейдера во фрагментный
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            // 4. Объявляем инстансируемые свойства. 
            // Если вы меняете Tint или HueShift индивидуально для каждого объекта через MaterialPropertyBlock,
            // Unity возьмет значения отсюда.
            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(fixed4, _Color)
                UNITY_DEFINE_INSTANCED_PROP(float, _HueShift)
            UNITY_INSTANCING_BUFFER_END(Props)

            float3 ApplyHueShift(float3 color, float shift)
            {
                float3 k = float3(0.57735, 0.57735, 0.57735);
                float angle = shift * 6.28318530718;
                float cosAngle = cos(angle);
                
                return color * cosAngle + 
                       cross(k, color) * sin(angle) + 
                       k * dot(k, color) * (1.0 - cosAngle);
            }

            v2f vert (appdata v)
            {
                v2f o;

                // 5. Настраиваем макросы чтения ID инстанса в вершинном шейдере
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 6. Настраиваем макрос чтения ID инстанса во фрагментном шейдере
                UNITY_SETUP_INSTANCE_ID(i);

                // 7. Получаем уникальные свойства конкретного инстанса через UNITY_ACCESS_INSTANCED_PROP
                fixed4 instancedColor = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
                float instancedHueShift = UNITY_ACCESS_INSTANCED_PROP(Props, _HueShift);

                fixed4 col = tex2D(_MainTex, i.uv) * instancedColor;
                col.rgb = ApplyHueShift(col.rgb, instancedHueShift);
                
                return col;
            }
            ENDCG
        }
    }
}