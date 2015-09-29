using UnityEditor;
using UnityEngine;
using System.Collections;

namespace FlatEditor.Input
{
    public static class Forms
    {
        public static string TextInputGroup(string text, string frontAddon, string backAddon, string glyph)
        {
            var inputStyle = FlatEditor.DefaultPanelSkin.textArea;
            var inputRect = EditorGUILayout.GetControlRect(GUILayout.Height(EditorGUIUtility.singleLineHeight*2));
            float iconOffset = 5;

            if (string.IsNullOrEmpty(frontAddon) && string.IsNullOrEmpty(backAddon))
            {
                DrawInputIcon(inputRect, inputStyle.fontSize, glyph, iconOffset);
                return GUI.TextArea(inputRect, text, inputStyle);
            }

            GUIContent frontContent = null;
            GUIStyle frontStyle = null;

            if (!string.IsNullOrEmpty(frontAddon))
            {
                frontContent = new GUIContent(frontAddon);
                frontStyle = new GUIStyle(FlatEditor.DefaultPanelSkin.customStyles[9]);

                if (Glyphs.CanParseAsGlyph(frontAddon))
                {
                    frontStyle.font = Glyphs.FontAwesomeStyle.font;
                    frontContent.text = Glyphs.GlyphString(frontAddon);
                }

                var frontStyleSize = frontStyle.CalcSize(frontContent);

                inputStyle.contentOffset = new Vector2(frontStyleSize.x, 0);
            }

            string output = GUI.TextArea(inputRect, text, inputStyle);

            if (!string.IsNullOrEmpty(frontAddon))
            {
                var frontStyleSize = frontStyle.CalcSize(frontContent);
                var frontRect = new Rect(inputRect.xMin, inputRect.yMin, frontStyleSize.x, inputRect.height);
                GUI.Box( frontRect, frontContent.text, frontStyle);

            }

            if (!string.IsNullOrEmpty(backAddon))
            {
                var backContent = new GUIContent(backAddon);
                var backStyle = new GUIStyle(FlatEditor.DefaultPanelSkin.customStyles[10]);

                if (Glyphs.CanParseAsGlyph(backAddon))
                {
                    backStyle.font = Glyphs.FontAwesomeStyle.font;
                    backContent.text = Glyphs.GlyphString(backAddon);
                }

                var frontStyleSize = backStyle.CalcSize(backContent);

                GUI.Box(
                    new Rect(inputRect.xMax - frontStyleSize.x, inputRect.yMin, frontStyleSize.x, inputRect.height),
                    backContent.text, backStyle);

                iconOffset += backStyle.CalcSize(backContent).x;
            }

            DrawInputIcon(inputRect, inputStyle.fontSize, glyph, iconOffset);

            return output;
        }

        private static void DrawInputIcon(Rect inputRect, int fontSize, string glyph, float rightOffset)
        {
            if (string.IsNullOrEmpty(glyph)) return;
            if (!Glyphs.CanParseAsGlyph(glyph)) return;

            var glyphStyle = Glyphs.GetGlyphStyle(glyph);
            glyphStyle.fontSize = fontSize;
            string g = Glyphs.GlyphString(glyph);

            var iconContent = new GUIContent(g);
            var size = glyphStyle.CalcSize(iconContent);

            GUI.Label(new Rect(inputRect.xMax - (size.x + rightOffset), inputRect.yMax - (inputRect.height/2 + size.y/2) , size.x, size.y), g, glyphStyle);
        }
    }

}
