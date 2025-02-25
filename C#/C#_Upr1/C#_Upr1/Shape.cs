namespace C__Upr1
{
    public abstract class Shape
    {
        private int color;

        public int Color
        {
            get
            {
                switch (color)
                {
                    case 0xFF0000: return 1; 
                    case 0x00FF00: return 2; 
                    case 0x0000FF: return 3; 
                    default: return 0;
                }
            }
            set
            {
                switch (value)
                {
                    case 1: color = 0xFF0000; break; 
                    case 2: color = 0x00FF00; break; 
                    case 3: color = 0x0000FF; break; 
                    default: color = 0; break;
                }
            }
        }
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public static class Colors
        {
            public static readonly int Red = 1;
            public static readonly int Green = 2;
            public static readonly int Blue = 3;
        }
    }
}
