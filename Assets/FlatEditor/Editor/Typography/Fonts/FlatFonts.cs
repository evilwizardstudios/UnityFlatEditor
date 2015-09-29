using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public static class FlatFonts
    {
        private const string FontAwesomePath = "Assets/FlatEditor/Editor/Typography/Fonts/fontawesome-webfont.ttf";
        private const string LatoPath = "Assets/FlatEditor/Editor/Typography/Fonts/Lato-";


        public static Font FontAwesome
        {
            get { return AssetDatabase.LoadAssetAtPath<Font>(FontAwesomePath); }
        }

        public static GUIStyle FontAwesomeStyle(int fontSize)
        {
            return new GUIStyle(EditorStyles.label)
            {
                font = FontAwesome,
                fontSize = fontSize,
                richText = true,
                alignment = TextAnchor.MiddleCenter
            };
        }

        public static Font LatoHairline
        {
            get { return AssetDatabase.LoadAssetAtPath<Font>(LatoPath+"Hairline.ttf"); }
        }

        public static GUIStyle LatoHairlineStyle(int fontSize, bool centered)
        {
            return new GUIStyle(EditorStyles.label)
            {
                font = LatoHairline,
                fontSize = fontSize,
                richText = true,
                alignment = centered ? TextAnchor.MiddleCenter : TextAnchor.MiddleLeft
            };
        }

        public static Font LatoLight
        {
            get { return AssetDatabase.LoadAssetAtPath<Font>(LatoPath + "Light.ttf"); }
 }

        public static GUIStyle LatoLightStyle(int fontSize, bool centered)
        {
            return new GUIStyle(EditorStyles.label)
            {
                font = LatoLight,
                fontSize = fontSize,
                richText = true,
                alignment = centered ? TextAnchor.MiddleCenter : TextAnchor.MiddleLeft
            };
        }

        public static Font Lato
        {
            get { return AssetDatabase.LoadAssetAtPath<Font>(LatoPath + "Regular.ttf"); }
 }

        public static GUIStyle LatoStyle(int fontSize, bool centered)
        {
            return new GUIStyle(EditorStyles.label)
            {
                font = Lato,
                fontSize = fontSize,
                richText = true,
                alignment = centered ? TextAnchor.MiddleCenter : TextAnchor.MiddleLeft
            };
        }

        public static Font LatoBlack
        {
            get { return AssetDatabase.LoadAssetAtPath<Font>(LatoPath + "Black.ttf"); }
        }

        public static GUIStyle LatoBlackStyle(int fontSize, bool centered)
        {
            return new GUIStyle(EditorStyles.label)
            {
                font = LatoBlack,
                fontSize = fontSize,
                richText = true,
                alignment = centered? TextAnchor.MiddleCenter: TextAnchor.MiddleLeft
            };
        }
    }
}