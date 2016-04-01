using System;
using UnityEngine;

namespace FlatEditor
{
    public static class Typography
    {
        public enum Heading
        {
            h0 = 65,
            h1 = 42,
            h2 = 30,
            h3 = 24,
            h4 = 18,
            h5 = 14,
            h6 = 12,
        }

        /// <summary>
        /// Returns a richtext-formatted (hex) color string.
        /// </summary>
        public static string ColoredText(Color32 color, string text)
        {
            return String.Format("{0}{1}</color>", String.Format("<color=#{0}>", Colors.ColorToHex(color)), text);
        }

        /// <summary>
        /// Draws an auto-layout Lato Black title of the specified color and heading size, and draws a small secondary text element to its immediate right.
        /// Returns the resultant Rect.
        /// </summary>
        public static Rect Title(string titleText, Heading heading, Color color, string secondaryText)
        {
            return Title(AutoLayoutTitleRect(titleText), titleText, heading, color, secondaryText);
        }

        /// <summary>
        /// Draws an auto-layout Lato Black title of the specified color and heading size.
        /// Returns the resultant Rect.
        /// </summary>
        public static Rect Title(string titleText, Heading heading, Color color)
        {
            return Title(AutoLayoutTitleRect(titleText), titleText, heading, color);
        }

        private static Rect AutoLayoutTitleRect(string title)
        {
            return GUILayoutUtility.GetRect(new GUIContent(title), FlatStyles.LatoBlack);
        }

        /// <summary>
        /// Draws a Lato Black title of the specified color and heading size at the supplied Rect.
        /// Returns the resized Rect.
        /// </summary>
        public static Rect Title(Rect rect, string titleText, Heading heading, Color color, string secondaryText)
        {
            var style = new GUIStyle(FlatStyles.LatoBlack) {fontSize = (int) heading};
            rect.size = style.CalcSize(new GUIContent(titleText));
            GUI.Label(rect, ColoredText(color, titleText), style);

            return !string.IsNullOrEmpty(secondaryText)? Subtitle(style, secondaryText, color, rect) : rect;
        }

        /// <summary>
        /// Draws a Lato Black title of the specified color and heading size at the supplied Rect.
        /// Returns the resized Rect.
        /// </summary>
        public static Rect Title(Rect rect, string titleText, Heading heading, Color color)
        {
            var style = new GUIStyle(FlatStyles.LatoBlack) { fontSize = (int)heading };
            rect.size = style.CalcSize(new GUIContent(titleText));
            GUI.Label(rect, ColoredText(color, titleText), style);

            return rect;
        }

        /// <summary>
        /// Draws a subtitle in Lato Light for Titles with secondary texts. Returns the resized Rect.
        /// </summary>
        private static Rect Subtitle(GUIStyle style, string secondaryText, Color titleColor, Rect titleRect)
        {
            var subStyle = FlatStyles.LatoLight;
            subStyle.fontSize = Mathf.RoundToInt(style.fontSize * 0.6f);
            subStyle.alignment = TextAnchor.LowerLeft;

            var contentSize = subStyle.CalcSize(new GUIContent(secondaryText));
            var yOffset = titleRect.y + (style.fontSize / 3f) + 1;
            var subRect = new Rect(titleRect.xMax, yOffset, contentSize.x, contentSize.y);

            var lightColor = new Color32(100, 100, 100, 255);

            GUI.Label(subRect, ColoredText(Color.Lerp(lightColor, titleColor, 0.6f), secondaryText), subStyle);

            return new Rect(titleRect.x, titleRect.y, titleRect.width + subRect.width, titleRect.height);
        }

    }
}