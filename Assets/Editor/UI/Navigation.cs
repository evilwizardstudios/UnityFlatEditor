using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public class Navigation
    {
        private const int HeaderHeight = 50;
        private const int SubheaderHeight = 30;
        private const int ButtonHeight = 30;
        private const int RightMargin = 40;

        private readonly Color _backgroundColor;
        private readonly string _helpNotification;
        private readonly HelpLink _helpLink;
        private readonly string _title;
        private readonly string _subtitle;
        private readonly Element[] _options;
        private readonly bool[] _disabledOptions;

        public Navigation(string title, string subtitle, string helpNotification, HelpLink helpLink, Element[] options, bool[] disabledOptions)
        {
            _backgroundColor = Colors.MidnightBlue;
            _title = title;
            _subtitle = subtitle;
            _helpNotification = helpNotification;
            _helpLink = helpLink;
            _options = options;
            _disabledOptions = disabledOptions;
        }
        
        public int DrawNavigation(int selected)
        {
            Header();
            SubHeader(selected);
            var selection = NavButtons(selected);
            GUI.color = Color.white;
            return selection;
        }

        private void Header()
        {
            var alt = Event.current.alt;
            var rect = WidthRect(HeaderHeight);
            GUI.color = alt ? Colors.Orange : _backgroundColor;
            GUI.Box(rect, alt ? Typography.ColoredText(Colors.WetAshphalt, _helpNotification): Typography.ColoredText(Colors.Clouds, _title), FlatStyles.NavHeader);
            HelpLinkUtility.HelpLink(rect, _helpLink);
        }

        private void SubHeader(int selected)
        {
            var subRect = WidthRect(SubheaderHeight);
            subRect.y -= 2;
            GUI.color = GetBackgroundColor(selected);
            GUI.Box(subRect, Typography.ColoredText(Colors.Clouds,_subtitle), FlatStyles.NavSubheader);
        }

        private int NavButtons(int selected)
        {
            var buttonRect = WidthRect(ButtonHeight);
            buttonRect.y -= 4;

            var count = _options.Length;
            var singleWidth = buttonRect.width / count;

            for (var i = 0; i < _options.Length; i++)
            {
                var nbRect = new Rect(buttonRect.xMin + (singleWidth * i), buttonRect.yMin, singleWidth, buttonRect.height);
                if (_options[i].Nav(i == selected, nbRect, true, _disabledOptions[i]))
                    return i;
            }
            return selected;
        }

        private Rect WidthRect(int height)
        {
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(height));
            rect.width = Screen.width - RightMargin;
            return rect;
        }

        private Color GetBackgroundColor(int mode)
        {
            return _options[mode].Color;
        }
    }
}