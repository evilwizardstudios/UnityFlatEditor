using FlatEditor.Typography;
using UnityEngine;
using System.Collections;

namespace FlatEditor.Buttons
{
    public static class ButtonUtility
    {
        public static bool DrawButton(string buttonContent, string glyphName, string badge, Color buttonColor, Size size, bool block, bool noOutline = false)
        {
            GUI.color = buttonColor;
            Color textColor = ContrastingBinaryColor(buttonColor);
            if (buttonColor.a == 0)
            {
                textColor = Colors.Link;
            }


            var style = new GUIStyle(FlatEditor.DefaultPanelSkin.button);
            if (noOutline)
            {
                style.normal.background = FlatEditor.DefaultPanelSkin.customStyles[0].normal.background;
                style.hover.background = FlatEditor.DefaultPanelSkin.customStyles[0].normal.background;
            }

            style.fontSize = (int) size;

            if (Glyphs.CanParseAsGlyph(buttonContent))
            {
                style.font = Glyphs.GetGlyphStyle(buttonContent).font;
                buttonContent = Glyphs.GlyphString(buttonContent);
            }


            var contentSize = style.CalcSize(new GUIContent(buttonContent));
            Vector2 glyphSize = Vector2.zero;
            Vector2 badgeSize = Vector2.zero;

            if (!string.IsNullOrEmpty(glyphName) && Glyphs.CanParseAsGlyph(glyphName))
            {
                var glyphStyle = Glyphs.GetGlyphStyle(glyphName);
                glyphStyle.fontSize = (int) size + 5;
                var glyph = Glyphs.GlyphString(glyphName);
                glyphSize = glyphStyle.CalcSize(new GUIContent(glyph));
            }

            if (!string.IsNullOrEmpty(badge))
            {
                var badgeStyle = new GUIStyle(style);
                badgeStyle.fontSize = Mathf.Clamp(style.fontSize - 5, 10, 100);
                badgeSize = badgeStyle.CalcSize(new GUIContent(badge));
            }


            if (block)
            {
                style.stretchWidth = true;
            }
            else
            {
                style.fixedWidth = contentSize.x + glyphSize.x + badgeSize.x + style.padding.horizontal;
                style.contentOffset += new Vector2(glyphSize.x - 5,0) - new Vector2(badgeSize.x /5, 0);
            }
            
            var output = GUILayout.Button(TypographyUtilities.ColoredText(textColor, buttonContent), style);

            var buttonRect = new Rect();

            if (!string.IsNullOrEmpty(glyphName))
            {
                buttonRect = GUILayoutUtility.GetLastRect();
                var glyphStyle = Glyphs.GetGlyphStyle(glyphName);
                glyphStyle.fontSize = (int)size + 5;
                var glyph = Glyphs.GlyphString(glyphName);

                GUI.Label(new Rect(buttonRect.x + style.padding.left, buttonRect.yMax - (buttonRect.height / 2) - glyphSize.y / 2, glyphSize.x, glyphSize.y), TypographyUtilities.ColoredText(textColor, glyph), glyphStyle);
            }

            if (!string.IsNullOrEmpty(badge))
            {
                if (buttonRect == new Rect()) buttonRect = GUILayoutUtility.GetLastRect();
                var badgeStyle = new GUIStyle(FlatEditor.DefaultPanelSkin.customStyles[8])
                {
                    fontSize = Mathf.Clamp(style.fontSize - 5, 10, 100)
                };
                badgeSize = badgeStyle.CalcSize(new GUIContent(badge));

                var badgeColor = buttonColor;
                if (buttonColor.a == 0)
                {
                    badgeColor = Colors.Default;
                }

                GUI.color = textColor;
                GUI.Label(new Rect(buttonRect.xMax - badgeSize.x - style.padding.left, buttonRect.yMax - (buttonRect.height / 2) - badgeSize.y / 2, badgeSize.x, badgeSize.y), TypographyUtilities.ColoredText(badgeColor, badge), badgeStyle);
                Colors.ResetUIColor();
            }

            Colors.ResetUIColor();
            return output;
        }

        private static Color ContrastingBinaryColor(Color backgroundColor)
        {
            return backgroundColor.r + backgroundColor.g + backgroundColor.b < 1.7
                ? Color.white
                : Color.black;
        }

    }
}
