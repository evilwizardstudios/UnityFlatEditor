using UnityEngine;

namespace FlatEditor
{
    public class Tooltip
    {
        public readonly string Content;
        public readonly Direction Position;

        public Tooltip(string content)
        {
            Content = content;
            Position = Direction.Up;
        }

        public Tooltip(string content, Direction direction)
        {
            Content = content;
            Position = direction;
        }

        public static void AddTooltip(Rect sourceRect, Tooltip tooltip)
        {
            DrawTooltip(sourceRect, tooltip.Position, tooltip.Content);
        }

        private static void DrawTooltip(Rect sourceRect, Direction position, string content)
        {
            if (!sourceRect.Contains(Event.current.mousePosition))
            {
                return;
            }

            var tooltipRect = new Rect();

            var contentSize = FlatStyles.Shadow.CalcSize(new GUIContent(content));

            switch (position)
            {
                case Direction.Down:
                    tooltipRect = new Rect((sourceRect.xMax - sourceRect.width/2 - contentSize.x/2),
                        (sourceRect.yMax + 10),
                        contentSize.x, contentSize.y);
                    break;
                case Direction.Left:
                    tooltipRect = new Rect((sourceRect.xMin - (10 + contentSize.x)),
                        (sourceRect.yMax - sourceRect.height/2 - contentSize.y/2),
                        contentSize.x, contentSize.y);
                    break;
                case Direction.Right:
                    tooltipRect = new Rect((sourceRect.xMax + 10),
                        (sourceRect.yMax - sourceRect.height/2 - contentSize.y/2),
                        contentSize.x, contentSize.y);
                    break;
                case Direction.Up:
                    tooltipRect = new Rect((sourceRect.xMax - sourceRect.width/2 - contentSize.x/2),
                        (sourceRect.y - (10 + contentSize.y)),
                        contentSize.x, contentSize.y);
                    break;
            }

            float shift = 0;
            if (tooltipRect.xMax > Screen.width - 10)
            {
                shift = (-contentSize.x/2) + 20;
            }
            else if (tooltipRect.xMin < 10)
            {
                shift = (contentSize.x/2) - 20;
            }

            tooltipRect.x += shift;

            GUI.Box(tooltipRect, content, FlatStyles.Shadow);
            DrawCaret(tooltipRect, position, shift);
        }


        private static void DrawCaret(Rect bubble, Direction position, float shift)
        {
            Rect caretRect;

            switch (position)
            {
                case Direction.Down:
                    caretRect = new Rect((bubble.xMax - bubble.width/2) - 12 - shift, bubble.y - 14, 20, 20);
                    Glyphs.Glyph(caretRect, "", Color.white, 25);
                    break;
                case Direction.Left:
                    caretRect = new Rect(bubble.xMax - 12 - shift, (bubble.yMax - bubble.height/2) - 12, 20, 20);
                    Glyphs.Glyph(caretRect, "", Color.white, 25);
                    break;
                case Direction.Right:
                    caretRect = new Rect(bubble.x - 10 - shift, (bubble.yMax - bubble.height/2) - 12, 20, 20);
                    Glyphs.Glyph(caretRect, "", Color.white, 25);
                    break;
                case Direction.Up:
                    caretRect = new Rect((bubble.xMax - bubble.width/2) - 12 - shift, bubble.yMax - 11, 20, 20);
                    Glyphs.Glyph(caretRect, "", Color.gray, 25);
                    caretRect = new Rect((bubble.xMax - bubble.width/2) - 12 - shift, bubble.yMax - 14, 20, 20);
                    Glyphs.Glyph(caretRect, "", Color.white, 25);
                    break;
            }

        }

    }

}