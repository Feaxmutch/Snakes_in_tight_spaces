namespace Other
{
    public readonly struct Color
    {
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public byte R { get; }

        public byte G { get; }

        public byte B { get; }

        public static Color Black => new Color(0, 0, 0);

        public static Color ConvertFromUnity(UnityEngine.Color color)
        {
            byte r = (byte)(byte.MaxValue * color.r);
            byte g = (byte)(byte.MaxValue * color.g);
            byte b = (byte)(byte.MaxValue * color.b);

            return new Color(r, g, b);
        }

        public static UnityEngine.Color ConvertToUnity(Color color)
        {
            float r = (float)((float)color.R / (float)byte.MaxValue);
            float g = (float)((float)color.G / (float)byte.MaxValue);
            float b = (float)((float)color.B / (float)byte.MaxValue);

            return new UnityEngine.Color(r, g, b);
        }

        public override bool Equals(object o)
        {
            return base.Equals(o);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Color left, Color right)
        {
            bool equalsR = left.R == right.R;
            bool equalsG = left.G == right.G;
            bool equalsB = left.B == right.B;
            return equalsR && equalsG && equalsB;
        }

        public static bool operator !=(Color left, Color right)
        {
            return (left == right) == false;
        }
    }
}