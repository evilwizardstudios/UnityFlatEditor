using UnityEngine;

namespace FlatEditor
{
    public class Multiswitch
    {
        private readonly Color _wellColor;
        private GUIStyle Style { get { return FlatStyles.SquareButton; } }

        private Element _wellIcon;
        
        private Element[] _options;

        public Multiswitch(Color wellColor, Element wellIcon, Element[] buttons)
        {
            _wellColor = wellColor;
            _wellIcon = wellIcon;
            _options = buttons;
        }

        public int Switch(Rect rect, int selected)
        {
            var buttonRect = DrawWell(rect);

            var count = _options.Length;
            var singleWidth = buttonRect.width / count;

            for (int i = 0; i < _options.Length; i++)
            {
                var nbRect = new Rect(buttonRect.xMin + (singleWidth * i), buttonRect.yMin, singleWidth, buttonRect.height);
                if (_options[i].Nav(i == selected, nbRect))
                    return i;
            }
            return selected;
        }

        private Rect DrawWell(Rect rect)
        {
            GUI.color = _wellColor;

            GUI.Box(rect, "", Style);

            var glyphRect = new Rect(rect.x + 5, rect.y + rect.height / 2 - 15, 30, 30);
            _wellIcon.Icon(rect);

            return new Rect(rect.x + glyphRect.width + 15, glyphRect.y,
                rect.width - glyphRect.width - 25, glyphRect.height);

        }
    }
}