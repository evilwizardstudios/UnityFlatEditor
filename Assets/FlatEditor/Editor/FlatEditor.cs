using System;
using System.Collections.Generic;
using System.Linq;
using FlatEditor.Example;
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace FlatEditor
{
    public static class FlatEditor
    {
        public static Font DefaultFont = FlatFonts.Lato;
        public static float ButtonPadding = 5;

        public static int ButtonPanelStyleIndex = 0;
        public static int AlertPanelStyleIndex = 1;

        public static GUIStyle DefaultStyle (int size)
        {
            return new GUIStyle(EditorStyles.label)
            {
                font = DefaultFont,
                fontSize = size,
                richText = true,
                alignment = TextAnchor.MiddleCenter
            }; 
        }

        public static GUISkin DefaultPanelSkin
        {
            get
            {
                if (_defaultPanelSkin != null) return _defaultPanelSkin;
                _defaultPanelSkin = AssetDatabase.LoadAssetAtPath<GUISkin>("Assets/FlatEditor/FlatEditor.guiskin");
                return _defaultPanelSkin;
            }
        }

        private static GUISkin _defaultPanelSkin;

        public const string FontAwesomeMapPath = "Assets/FlatEditor/Editor/Typography/Fonts/FA_glyphmap.txt";

        public static Color BackgroundColor;
        public static Color TextColor = Color.black;
        /*
        public static Buttons.ButtonStyle DefaultButtonStyle
        {
            get
            {
                if (_defaultButtonStyle != null) return _defaultButtonStyle;
                _defaultButtonStyle = new Buttons.ButtonStyle()
                {
                    ContentPadding = new Vector2(5, 5),
                    ContentStyle = DefaultStyle(14),
                    ContentSizeOverride = 14,
                    DefaultColor = Colors.Primary,
                    ButtonPanelStyle = PanelStyleOption.Outline
                };
                return _defaultButtonStyle;
            }
        }
        
        private static Buttons.ButtonStyle _defaultButtonStyle;
        */
        public static bool InLayoutMode { get { return _layoutOrigins.Count > 0; } }

        public static void SpaceActiveLayoutRect(float x, float y)
        {
            var old = _layoutOrigins.Pop();
            _layoutOrigins.Push(new Vector2(old.x + x, old.y + y));

            TotalInspectorSpacing = old.y + y;
        }

        public static void MoveActiveLayoutRect(float xCoord, float yCoord)
        {
            _layoutOrigins.Peek().Set(xCoord, yCoord);
        }

        public static Vector2 ActiveLayout
        {
            get
            {
                if (_layoutOrigins == null)
                {
                    throw new Exception("No FlatEditor Layout active!");
                }

                    return _layoutOrigins.Peek();

            }
        }

        public static Stack<Vector2> LayoutOrigins
        {
            get {
                if (_layoutOrigins != null)
                {
                    return _layoutOrigins;
                }
                else
                {
                    _layoutOrigins = new Stack<Vector2>();
                    return _layoutOrigins;
                }
            }
        }

        private static Stack<Vector2> _layoutOrigins; 

        public static float MinimumElementSpacing = 5;

        public static float TotalInspectorSpacing = 0;

        public static void Enable(Editor inspector)
        {
            var inspectorRect = new Rect(0, 0, Screen.width, Screen.height);
            if (inspectorRect.Contains(Event.current.mousePosition))
            {
                inspector.Repaint();
            }

            _layoutOrigins = new Stack<Vector2>();
            _layoutOrigins.Push(EditorGUILayout.GetControlRect().position);

            TotalInspectorSpacing = 0;
        }

        public static void Disable()
        {
            if (_layoutOrigins == null) return;

            GUILayout.Space(TotalInspectorSpacing);
        }

    }
}
