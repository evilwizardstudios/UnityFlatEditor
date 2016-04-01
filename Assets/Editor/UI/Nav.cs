using System;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public static class Nav
    {
        public static int Navbar(Rect rect, int selected, string[] options, Color[] colors, bool carets)
        {
            if (options.Length != colors.Length)
                throw new Exception("each option needs a color and vice versa. Array size mismatch!");

            var count = options.Length;
            var singleWidth = rect.width/count;

            for (int i = 0; i < options.Length; i++)
            {
                var nbRect = new Rect(rect.xMin + (singleWidth*i), rect.yMin, singleWidth, rect.height);
                if (NavButton(nbRect, colors[i], options[i], selected == i, carets))
                    return i;
            }
            return selected;
        }

        private static bool NavButton(Rect nbRect, Color color, string text, bool forceUnselectable, bool carets)
        {
            EditorGUI.BeginDisabledGroup(forceUnselectable);

            GUI.color = color;
            var selection = GUI.Button(nbRect, Typography.ColoredText(Colors.Clouds, text), GUI.skin.customStyles[13]);
            HelpLinkUtility.HelpLink(nbRect, "/editor/adapter#navigation");
            if (!forceUnselectable)
            {
                if (carets)
                {
                    DrawNavButtonCaret(nbRect, color);
                }
                else
                {
                    DrawNavButtonHighlight(nbRect);
                }
            }

            EditorGUI.EndDisabledGroup();
            GUI.color = Color.white;
            return selection;
        }

        private static bool NavButton(Rect nbRect, Color color, char glyph, bool forceUnselectable, bool carets)
        {
            EditorGUI.BeginDisabledGroup(forceUnselectable);
            var text = glyph.ToString();
            GUI.color = color;
            var selection = GUI.Button(nbRect, Typography.ColoredText(Colors.Clouds, text), GUI.skin.customStyles[15]);
            HelpLinkUtility.HelpLink(nbRect, "/editor/adapter#navigation");
            if (!forceUnselectable)
            {
                if (carets)
                {
                    DrawNavButtonCaret(nbRect, color);
                }
                else
                {
                    DrawNavButtonHighlight(nbRect);
                }
            }

            EditorGUI.EndDisabledGroup();
            GUI.color = Color.white;
            return selection;
        }

        private static void DrawNavButtonHighlight(Rect target)
        {
            if (!target.Contains(Event.current.mousePosition)) return;

            GUI.color = new Color32(34, 167, 240, 100);
            GUI.Box(target, "", GUI.skin.customStyles[13]);
            GUI.color = Color.white;
        }
        
        private static void DrawNavButtonCaret(Rect target, Color color)
        {
            if (!target.Contains(Event.current.mousePosition)) return;

            var caretRect = new Rect(target.position.x + (target.size.x / 2) - 27, target.position.y + target.size.y - 20, 50, 50);

            Glyphs.Glyph(caretRect, "", color, 50);

            Colors.Reset();
        }

        public static int Navbar(Rect rect, int selected, char[] glyphs, Tooltip[] tooltips, Color[] colors, bool[] disabled)
        {
            if (glyphs.Length != colors.Length)
                throw new Exception("each option needs a color and vice versa. Array size mismatch!");

            var count = glyphs.Length;
            var singleWidth = rect.width / count;

            for (int i = 0; i < glyphs.Length; i++)
            {
                EditorGUI.BeginDisabledGroup(disabled[i]);
                
                var nbRect = new Rect(rect.xMin + (singleWidth * i), rect.yMin, singleWidth, rect.height);
                if (NavButton(nbRect, disabled[i]? Colors.Concrete:colors[i], glyphs[i], selected == i, false))
                    return i;

                EditorGUI.EndDisabledGroup();
            }

            for (int i = 0; i < tooltips.Length; i++)
            {
                if (tooltips[i] == null)
                    continue;

                var ttRect = new Rect(rect.xMin + (singleWidth * i), rect.yMin, singleWidth, rect.height);
                Tooltip.AddTooltip(ttRect, tooltips[i]);
            }


            return selected;
        }
    }
}