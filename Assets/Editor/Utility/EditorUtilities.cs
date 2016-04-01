using FlatEditor;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public static class EditorUtilities
    {
        public static Texture Pixel
        {
            get
            {
                return new Texture2D(1,1);
            }
        }

        public static void Line(int offset = 40)
        {
            GUILayout.Space(10);
            var linerect = EditorGUILayout.GetControlRect(GUILayout.Height(1), GUILayout.Width(EditorGUIUtility.currentViewWidth - offset));
            GUI.color = Colors.Silver;
            GUI.DrawTexture(linerect, Pixel, ScaleMode.StretchToFill);
            Colors.Reset();
            GUILayout.Space(10);
        }


        public static Rect AbsolutePositionRect(Vector2 size)
        {

            var mpos = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            var rect = new Rect(mpos, Vector2.zero);

            if (mpos.x > Screen.currentResolution.width/2f)
            {
                rect.x -= size.x;
            }

            if (mpos.y > Screen.currentResolution.height / 2f)
            {
                rect.y -= size.y;
            }

            return rect;
        }

        public static void WindowBackground(Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), EditorGUIUtility.whiteTexture);
            GUI.color = Color.white;
        }

        public static void Skin()
        {
            if (GUI.skin.name != "Flat")
            {
                GUI.skin = AssetDatabase.LoadAssetAtPath<GUISkin>("Assets/FlatEditor/Editor/InternalResources/Flat.guiskin");
            }
        }

        public static Vector2 BeginScrollView(Vector2 scrollPosition)
        {
            var mX = Event.current.mousePosition.x;
            var thumbColor = mX > Screen.width - 20 && mX < Screen.width
                ? Color.Lerp(Color.white, Color.clear, 0.4f)
                : Color.Lerp(Color.white, Color.clear, 0.8f);
            GUI.color = thumbColor;
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, false);
            GUI.color = Color.white;
            return scrollPosition;
        }

    }
}
