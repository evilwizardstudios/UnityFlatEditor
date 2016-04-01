using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public class Element
    {
        private readonly GUIStyle _style;

        private readonly Color _backgroundColor;
        public Color Color { get { return _backgroundColor; } }
        private readonly Color _foregroundColor;
        private readonly int _fontSize;
        private readonly int _oldFontSize;
        private readonly string _content;
        private readonly bool _padContent;

        private Rect _tooltipRect;
        private readonly Tooltip _tooltip;
        private readonly HelpLink _link;

        public Element(GUIStyle style, string content, Color background, int size, bool padContent = false, Tooltip tooltip = null, HelpLink link = null)
        {
            _style = style;
            _backgroundColor = background;
            _foregroundColor = Colors.Clouds;
            _fontSize = size;
            _oldFontSize = _style.fontSize;
            _padContent = padContent;
            _content = content;
            _tooltip = tooltip;
            _link = link;
        }

        public Element(string content, Color background, int size, Tooltip tooltip = null, HelpLink link = null)
        {
            _style = FlatStyles.GlyphButton;
            _backgroundColor = background;
            _foregroundColor = Colors.Clouds;
            _fontSize = size;
            _oldFontSize = _style.fontSize;
            _padContent = true;
            _content = content;
            _tooltip = tooltip;
            _link = link;
        }

        public bool Button(Rect buttonRect)
        {
            buttonRect = PrepareButtonRect(buttonRect);

            var result = Draw(buttonRect);
            return result;
        }

        public bool SubtitleButton(Rect buttonRect, string subtitle)
        {
            buttonRect = PrepareButtonRect(buttonRect);
            var result = Draw(buttonRect);

            var subtitleRect = new Rect(buttonRect.x, buttonRect.y + (buttonRect.height*0.85f), buttonRect.width,
                buttonRect.height*0.25f);
            GUI.color = Colorize(buttonRect);
            GUI.Box(subtitleRect, Typography.ColoredText(_foregroundColor, subtitle), FlatStyles.Rounded);
            GUI.color = Color.white;
            return result;
        }

        public bool TagStyleBadge(Rect rect, string badge)
        {
            var subRect = new Rect(rect.x + 6, rect.y, 20, rect.height + 1.5f);
            var caretRect = new Rect(subRect.x + 25.5f, subRect.y + 12, 0, 0);

            var color = Colorize(subRect);

            var badgeRect = new Rect(subRect);
            badgeRect.x += 10;
            var width = _style.CalcSize(new GUIContent(badge)).x;
            badgeRect.size = new Vector2(width + 25, 25);
            GUI.color = Colors.Clouds;
            GUI.Box(badgeRect, "", FlatStyles.Rounded);


            GUI.color = color;
            GUI.Box(subRect, "", FlatStyles.NavHeader);
            Glyphs.Glyph(caretRect, "", color, 43);
            GUI.color = Color.white;

            caretRect.x += 8;
            caretRect.y -= 12;
            Typography.Title(caretRect, badge, Typography.Heading.h5, Colors.WetAshphalt);


            return FixedSizeButton(rect, new Vector2(25, 25));

        }

        public void Icon(Rect iconRect)
        {
            Box(iconRect);
        }

        public bool FixedSizeButton(Rect buttonRect, Vector2 size)
        {
            buttonRect = PrepareFixedButtonRect(buttonRect, size);

            var result = Draw(buttonRect);
            return result;
        }

        public bool ButtonWithInset(Rect buttonRect, string inset)
        {
            buttonRect = PrepareButtonRect(buttonRect);

            var result = Draw(buttonRect);

            Inset(buttonRect, inset);
            return result;
        }
        
        private void Inset(Rect buttonRect, string inset)
        {
            var insetRect = new Rect(new Vector2(buttonRect.xMax - (buttonRect.width / 2.5f), buttonRect.yMax - (buttonRect.height / 2.5f)), buttonRect.size / 2.5f);
            _style.fontSize = _fontSize / 2;
            insetRect.size = _style.CalcSize(new GUIContent(inset));

            if (insetRect.width > insetRect.height)
            {
                insetRect.height = insetRect.width;
            }
            else
            {
                insetRect.width = insetRect.height;
            }

            InsetBox(insetRect, buttonRect, inset);
            _style.fontSize = _oldFontSize;
        }

        public bool Toggle(bool active, Rect buttonRect, bool disabled = false)
        {
            var color = _backgroundColor;
            if (active)
            {
                color = Color.Lerp(color, Colors.Clouds, 0.4f);
            }
            buttonRect = PrepareButtonRect(buttonRect);

            if (disabled)
            {
                GUI.color = Colors.Concrete;
                Box(buttonRect);
                return false;
            }
            
            GUI.color = color;
            if (Draw(buttonRect))
                return !active;
            return active;
        }

        public bool Nav(bool active, Rect buttonRect, bool caretHighlight = false, bool disabled = false)
        {
            var color = _backgroundColor;
            if (active)
            {
                color = Color.Lerp(color, Colors.Clouds, 0.4f);
            }
            else
            {
                color = Colorize(buttonRect);
                if (caretHighlight && !disabled)
                {
                    DrawCaret(buttonRect, color);
                }
            }

            if (disabled)
            {
                GUI.color = Colors.Concrete;
                Draw(buttonRect);
                return false;
            }

            GUI.color = color;
            return Draw(buttonRect);
        }

        private void Box(Rect boxRect)
        {
            boxRect = PrepareBoxRect(boxRect);
            GUI.Box(boxRect, Typography.ColoredText(_foregroundColor, _content), _style);
            Finish();
        }

        private void InsetBox(Rect boxRect, Rect buttonRect, string insetContent)
        {
            GUI.color = buttonRect.Contains(Event.current.mousePosition) ? Color.Lerp(_backgroundColor, Color.white, 0.3f) : _backgroundColor;
            GUI.color = Color.Lerp(GUI.color, Color.clear, 0.3f);
            GUI.Box(boxRect, Typography.ColoredText(_foregroundColor, insetContent), _style);
            Finish();
        }

        public int Popup(int selected, string[] selections, Rect buttonRect)
        {
            var result = EditorGUI.Popup(buttonRect, selected, selections, FlatStyles.Invisible);

            Button(buttonRect);

            return result;
        }

        public void DrawTooltip()
        {
            if (_tooltip == null) return;
            Tooltip.AddTooltip(_tooltipRect, _tooltip);
        }

        private bool Draw(Rect buttonRect)
        {
            var result =  GUI.Button(buttonRect, Typography.ColoredText(_foregroundColor, _content), _style);
            Finish();
            return result;
        }

        private void Finish()
        {
            ClearChanges();
            DrawTooltip();
            HelpLink();
        }

        private void HelpLink()
        {
            if (_link == null) return;
            HelpLinkUtility.HelpLink(_tooltipRect, _link.Anchor);
        }

        private void ClearChanges()
        {
            GUI.color = Color.white;
            _style.fontSize = _oldFontSize;
        }

        private Rect PrepareButtonRect(Rect buttonRect)
        {
            _style.fontSize = _fontSize;
            var adjustedSize = _style.CalcSize(new GUIContent(_content)) * (_padContent ? 1.25f : 1);
            buttonRect.size = adjustedSize.y > adjustedSize.x ? new Vector2(adjustedSize.y, adjustedSize.y) : new Vector2(adjustedSize.x, adjustedSize.x);
            _tooltipRect = buttonRect;
            GUI.color = Colorize(buttonRect);
            return buttonRect;
        }

        private Rect PrepareBoxRect(Rect buttonRect)
        {
            _style.fontSize = _fontSize;
            var adjustedSize = _style.CalcSize(new GUIContent(_content)) * (_padContent ? 1.25f : 1);
            buttonRect.size = adjustedSize.y > adjustedSize.x ? new Vector2(adjustedSize.y, adjustedSize.y) : new Vector2(adjustedSize.x, adjustedSize.x);
            _tooltipRect = buttonRect;
            GUI.color = _backgroundColor;
            return buttonRect;
        }

        private Rect PrepareFixedButtonRect(Rect buttonRect, Vector2 size)
        {
            buttonRect.size = size;
            _tooltipRect = buttonRect;
            GUI.color = Colorize(buttonRect);
            return buttonRect;
        }

        private Color Colorize(Rect buttonRect)
        {
            return buttonRect.Contains(Event.current.mousePosition) ? Color.Lerp(_backgroundColor, Color.white, 0.3f) : _backgroundColor;
        }

        private void DrawCaret(Rect target, Color color)
        {
            if (!target.Contains(Event.current.mousePosition)) return;

            var caretRect = new Rect(target.position.x + (target.size.x / 2) - 27, target.position.y + target.size.y - 20, 50, 50);

            Glyphs.Glyph(caretRect, "", color, 50);

            Colors.Reset();
        }
    }

}