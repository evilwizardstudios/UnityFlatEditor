using UnityEngine;

namespace FlatEditor
{
    public static class Tags
    {
        public static bool TagLabel(Vector2 origin, Color color, string content, out float offset)
        {
            bool result = false;
            var tagRect = new Rect(origin.x + 17, origin.y, 20, 20);
            var tagStyle = GUI.skin.customStyles[13];
            tagRect.size = tagStyle.CalcSize(new GUIContent(content));

            color = tagRect.Contains(Event.current.mousePosition) ? Color.Lerp(color, Color.white, 0.3f) : color;

            GUI.color = color;
            if (GUI.Button(tagRect, Typography.ColoredText(Colors.Clouds, content), tagStyle))
            {
                result = true;
            }
            Glyphs.Glyph(new Rect(tagRect.x - 17, tagRect.y + 2, 20, 20), "", color, 42);

            Glyphs.Glyph(new Rect(tagRect.x, tagRect.y + 2, 20, 20), "", Colors.Clouds, 20);

            GUI.color = Color.white;

            offset = tagRect.width;
            return result;
        }

        public static bool TagLabelButton(Vector2 origin, Color color, string content, out Rect tagRect)
        {
            var tagStyle = GUI.skin.customStyles[13];

            var rect = new Rect(new Vector2(origin.x + 17, origin.y), tagStyle.CalcSize(new GUIContent(content)));

            color = rect.Contains(Event.current.mousePosition) ? Color.Lerp(color, Color.white, 0.3f) : color;
            GUI.color = color;
            var result = GUI.Button(rect, Typography.ColoredText(Colors.Clouds, content), tagStyle);

            Glyphs.Glyph(new Rect(rect.x - 17, rect.y + 2, 20, 20), "", color, 42);

            Glyphs.Glyph(new Rect(rect.x, rect.y + 2, 20, 20), "", Colors.Clouds, 20);

            GUI.color = Color.white;

            tagRect = rect;
            return result;
        }
    }
}