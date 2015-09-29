using UnityEditor;
using UnityEngine;

namespace FlatEditor.Typography
{
    public static class Text
    {
        public static void Title(string titleText, Heading heading, bool centered, string secondaryText)
        {
            var style = FlatFonts.LatoBlackStyle((int) heading, centered);
            var content = new GUIContent(titleText);
            var titleRect = GUILayoutUtility.GetRect(content, style);
            GUI.Label(titleRect, TypographyUtilities.ColoredText(FlatEditor.TextColor, titleText), style);

            if (secondaryText != null)
            {
                var subStyle = new GUIStyle(style)
                {
                    font = FlatFonts.Lato,
                    fontSize = Mathf.RoundToInt(style.fontSize*0.85f),
                    alignment = TextAnchor.LowerLeft,
                };
                
                var contentSize = subStyle.CalcSize(new GUIContent(secondaryText));
                var offset = new Vector2(style.CalcSize(content).x, ((int) heading / 10) + 1);
                var subRect = new Rect(titleRect.position + offset, contentSize);


                var lightened = new Color32(125, 125, 125,255);

                GUI.Label(subRect, TypographyUtilities.ColoredText(lightened, secondaryText), subStyle);
            }
        }

        public static void Paragraph (string text, bool lead)
        {
            var style = lead?FlatFonts.LatoLightStyle(16, false) : FlatFonts.LatoStyle(14, false);

            style.wordWrap = true;
            
            var content = new GUIContent(text);
            var titleRect = GUILayoutUtility.GetRect(content, style);
            titleRect.height += EditorGUIUtility.singleLineHeight;
            GUI.Label(titleRect, TypographyUtilities.ColoredText(FlatEditor.TextColor, text), style);
        }

        public static void Blockquote(Color blockColor, string quote, string source, bool reverse)
        {
            GUILayout.Space(EditorGUIUtility.singleLineHeight);
            var offset = 20;

            var style = new GUIStyle(FlatFonts.LatoStyle(16, false));
            style.alignment = reverse ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;

            var quoteContent = new GUIContent(quote);
            var quoteRect = GUILayoutUtility.GetRect(quoteContent, style);

            if (!reverse)
            {
                quoteRect.x += offset;
            }

            quoteRect.width -= offset;
            
            GUI.Label(quoteRect, TypographyUtilities.ColoredText(FlatEditor.TextColor, quote), style);

            //BUG: Unity editor suddenly not rendering em-dash
//            source = reverse ? source + " ¡ª " : " ¡ª " + source;

            var sourceContent = new GUIContent(source);
            var sourceRect = GUILayoutUtility.GetRect(sourceContent, style);

            if (!reverse)
            {
                sourceRect.x += offset;
            }

            sourceRect.width -= offset;

            var lightened = new Color32(125, 125, 125, 255);

            GUI.Label(sourceRect, TypographyUtilities.ColoredText(lightened, source), style);
            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            var drawRect = reverse
                ? new Rect(quoteRect.xMax + 15, quoteRect.y, 5, quoteRect.height + sourceRect.height)
                : new Rect(10, quoteRect.y, 5, quoteRect.height + sourceRect.height);

            GUI.color = blockColor;
            GUI.DrawTexture(drawRect, Drawing.Pixel, ScaleMode.StretchToFill);
            Colors.ResetUIColor();

        }
    }
}