using System;
using UnityEngine;
using System.Collections;

namespace FlatEditor.Buttons
{
    public static class Navigation
    {
        public static int NavPills(string[] options, string[] glyphs, string[] badges, int selection,
            Color selected)
        {
            if (glyphs.Length != options.Length)
            {
                Array.Resize(ref glyphs, options.Length);
            }
            if (badges.Length != options.Length)
            {
                Array.Resize(ref badges, options.Length);
            }

            GUILayout.BeginHorizontal();
//            var panelStyle = new GUIStyle(FlatEditor.DefaultPanelSkin.customStyles[0]);

            for (int i = 0; i < options.Length; i++)
            {
                if (ButtonUtility.DrawButton(options[i], glyphs[i], badges[i],
                    i == selection ? selected : Color.clear,
                    Size.Default, true, true))
                {
                    selection = i;
                }
            }

            GUILayout.EndHorizontal();

            return selection;
        }
    }


}