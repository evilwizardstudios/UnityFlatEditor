using UnityEngine;

namespace FlatEditor
{

    public enum Style
    {
        Default,
        Primary,
        Success,
        Info,
        Warning,
        Danger,
        Link
    }

    public static class Colors
    {
        public static Color ColorFromStyle(Style style)
        {
            switch (style)
            {
                case Style.Danger:
                    return Danger;
                case Style.Default:
                    break;
                case Style.Info:
                    return Info;
                case Style.Primary:
                    return Primary;
                case Style.Success:
                    return Success;
                case Style.Warning:
                    return Warning;
                case Style.Link:
                    return Link;
            }
            return Default;
        }


        public static Color Highlight
        {
            get { return new Color32(250, 250, 255, 255); }
        }

        public static Color Shadow
        {
            get { return new Color32(50, 50, 80, 255); }
        }

        public static Color Active
        {
            get { return new Color32(26, 188, 156, 255); }
        }

        public static Color GreenSea
        {
            get { return new Color32(22, 160, 133, 255); }
        }

        public static Color Success
        {
            get { return new Color32(46, 204, 113, 255); }
        }

        public static Color Nephritis
        {
            get { return new Color32(39, 174, 96, 255); }
        }

        public static Color Info
        {
            get { return new Color32(52, 152, 219, 255); }
        }

        public static Color Link
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

        public static Color Primary
        {
            get { return new Color32(52, 73, 94, 255); }
        }

        public static Color MidnightBlue
        {
            get { return new Color32(44, 62, 80, 255); }
        }
        
        public static Color Warning
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
        
        public static Color Danger
        {
            get { return new Color32(231, 76, 60, 255); }
        }
        
        public static Color Pomegranate
        {
            get { return new Color32(192, 57, 43, 255); }
        }

        public static Color Default
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

        public static void ResetUIColor()
        {
            GUI.color = Color.white;
            FlatEditor.TextColor = Color.black;
        }

        public static string ColorToHex(Color32 color)
        {
            string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
            return hex;
        }
    }
}