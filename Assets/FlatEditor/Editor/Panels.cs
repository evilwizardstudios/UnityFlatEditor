using System.Collections;
using FlatEditor.Typography;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public static class Panels
    {
        public static void Line(float yOrigin, Color color)
        {
            var rect = new Rect(0, yOrigin, Screen.width, 1);
            GUI.color = color;
            GUI.DrawTexture(rect, Drawing.Pixel);
            Colors.ResetUIColor();
        }

        public static void ContentPanel(Vector2 panelOrigin, GUIContent content, GUIStyle style, Color panelColor, PanelStyleOption option)
        {
            var rect = new Rect(panelOrigin, style.CalcSize(content) + new Vector2(75, 20));
            style.alignment = TextAnchor.MiddleLeft;
            
            DrawPanel(rect, panelColor, option);

            var labelrect = new Rect(rect.position + new Vector2(5, 10), style.CalcSize(content));

            content.text = TypographyUtilities.ColoredText(Color.Lerp(panelColor, Color.black, 0.8f), content.text);
            GUI.Label(labelrect, content, style);

            FlatEditor.SpaceActiveLayoutRect(0, rect.height + FlatEditor.MinimumElementSpacing);

        }
        /*
        public static bool DismissiblePanel(Vector2 panelOrigin, GUIContent content, GUIStyle style, Color panelColor, PanelStyleOption option)
        {
            var rect = new Rect(panelOrigin, style.CalcSize(content) + new Vector2(75,20));
            style.alignment = TextAnchor.MiddleLeft;

            DrawPanel(rect, panelColor, option);

            var labelRect = new Rect(panelOrigin + new Vector2(5, 10), style.CalcSize(content));
            content.text = Flat.ColoredText(Color.Lerp(panelColor, Color.black, 0.8f), content.text);

            GUI.Label(labelRect, content, style);

            rect.Set(rect.xMax-50, rect.yMin + (rect.height/2) - 25, 50,50);

            var output =  Buttons.Link(panelOrigin + new Vector2(labelRect.width + 25,8), new GUIContent(Glyphs.GlyphString("fa-close")), Color.Lerp(panelColor, Color.black, 0.3f), Colors.Default,
                FlatFonts.FontAwesomeStyle(20),null);

            FlatEditor.SpaceActiveLayoutRect(0, rect.height + FlatEditor.MinimumElementSpacing);

            return output;
        }*/

        public static void Blank(Rect rect, Color color, PanelStyleOption option)
        {
            DrawPanel(rect, color, option);
        }
        
        private static void DrawPanel(Rect rect, Color color, PanelStyleOption option)
        {
            GUI.color = color;
            GUI.Box(rect, "", PanelStyle(option));

            Colors.ResetUIColor();
        }


        public static GUIStyle PanelStyle(PanelStyleOption option)
        {
            switch (option)
            {
                case PanelStyleOption.None:
                    return FlatEditor.DefaultPanelSkin.customStyles[0];
                case PanelStyleOption.Outline:
                    return FlatEditor.DefaultPanelSkin.customStyles[1];
                case PanelStyleOption.Depth:
                    return FlatEditor.DefaultPanelSkin.customStyles[2];
                case PanelStyleOption.DropShadow:
                    return FlatEditor.DefaultPanelSkin.customStyles[3];
                case PanelStyleOption.Outline | PanelStyleOption.DropShadow:
                    return FlatEditor.DefaultPanelSkin.customStyles[4];
                case PanelStyleOption.Depth | PanelStyleOption.DropShadow:
                    return FlatEditor.DefaultPanelSkin.customStyles[5];
                case PanelStyleOption.Depth | PanelStyleOption.Outline:
                    return FlatEditor.DefaultPanelSkin.customStyles[6];
                case PanelStyleOption.Depth | PanelStyleOption.Outline | PanelStyleOption.DropShadow:
                    return FlatEditor.DefaultPanelSkin.customStyles[7];
                case PanelStyleOption.Badge:
                    return FlatEditor.DefaultPanelSkin.customStyles[8];
            }
            return FlatEditor.DefaultPanelSkin.customStyles[0];
        }

    }
}