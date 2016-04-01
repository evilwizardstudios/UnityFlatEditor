using UnityEngine;

namespace FlatEditor
{
    public static class Colors
    {
        public static void Reset()
        {
            GUI.color = Default;
        }

        private static Color Default
        {
            get { return Color.white; }
        }

        public static Color Highlight
        {
            get { return new Color32(241, 196, 15, 100); }
        }

        public static Color Honey
        {
            get { return new Color32(253, 227, 167, 255); }
        }

        public static Color Chambray
        {
            get { return new Color32(58, 83, 155, 255); }
        }

        public static Color Jellybean
        {
            get { return new Color32(37, 116, 169, 255); }
        }

        public static Color Turquoise
        {
            get { return new Color32(26, 188, 156, 255); }
        }

        public static Color GreenSea
        {
            get { return new Color32(22, 160, 133, 255); }
        }

        public static Color Emerald
        {
            get { return new Color32(46, 204, 113, 255); }
        }

        public static Color Nephritis
        {
            get { return new Color32(39, 174, 96, 255); }
        }

        public static Color River
        {
            get { return new Color32(52, 152, 219, 255); }
        }

        public static Color Belize
        {
            get { return new Color32(41, 128, 185, 255); }
        }

        public static Color Amethyst
        {
            get { return new Color32(155, 89, 182, 255); }
        }

        public static Color Wisteria
        {
            get { return new Color32(142, 68, 173, 255); }
        }

        public static Color WetAshphalt
        {
            get { return new Color32(52, 73, 94, 255); }
        }

        public static Color MidnightBlue
        {
            get { return new Color32(44, 62, 80, 255); }
        }
        
        public static Color Sunflower
        {
            get { return new Color32(241, 196, 15, 255); }
        }
        
        public static Color Orange
        {
            get { return new Color32(243, 156, 18, 255); }
        }
        
        public static Color Carrot
        {
            get { return new Color32(230, 126, 34, 255); }
        }
        
        public static Color Pumpkin
        {
            get { return new Color32(211, 84, 0, 255); }
        }
        
        public static Color Alizarin
        {
            get { return new Color32(231, 76, 60, 255); }
        }
        
        public static Color Pomegranate
        {
            get { return new Color32(192, 57, 43, 255); }
        }

        public static Color Clouds
        {
            get { return new Color32(236, 240, 241, 255); }
        }

        public static Color Silver
        {
            get { return new Color32(189, 195, 199, 255); }
        }

        public static Color Concrete
        {
            get { return new Color32(149, 165, 166, 255); }
        }

        public static Color Asbestos
        {
            get { return new Color32(127, 140, 141, 255); }
        }

        public static string ColorToHex(Color32 color)
        {
            string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
            return hex;
        }
    }
}