using System.Security.Policy;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public class HelpLink
    {
        public string Anchor { get; private set; }

        public HelpLink (string anchor)
        {
            Anchor = anchor;
        }
    }

    public static class HelpLinkUtility
    {
        private const string DocsUrl = "http://www.evilwizardstudios.com/FlatEditor/documentation{0}"; 
        
        public static void HelpLink(Rect targetRect, string anchor)
        {
            if (!Event.current.alt) return;

            EditorGUIUtility.AddCursorRect(targetRect, MouseCursor.Link);

            if (!targetRect.Contains(Event.current.mousePosition)) return;

            DrawHelpLinkHighlight(targetRect);

            if (Event.current.alt && Event.current.type == EventType.MouseDown)
                LaunchDocpage(anchor);
        }

        public static void HelpLink(Rect targetRect, HelpLink link)
        {
            if (!Event.current.alt) return;

            EditorGUIUtility.AddCursorRect(targetRect, MouseCursor.Link);

            if (!targetRect.Contains(Event.current.mousePosition)) return;

            DrawHelpLinkHighlight(targetRect);

            if (Event.current.alt && Event.current.type == EventType.MouseDown)
                LaunchDocpage(link.Anchor);
        }

        private static void LaunchDocpage(string anchor)
        {
            Application.OpenURL(string.Format(DocsUrl, anchor));
        }

        private static void DrawHelpLinkHighlight(Rect targetRect)
        {
            GUI.color = Colors.Highlight;
            GUI.DrawTexture(targetRect, EditorUtilities.Pixel, ScaleMode.StretchToFill);
            GUI.color = Color.white;
        }
    }
}