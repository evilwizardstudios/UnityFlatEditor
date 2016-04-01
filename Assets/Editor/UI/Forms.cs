using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tizen;

namespace FlatEditor
{
    public static class Forms
    {
        public static int SingleLineInt(int value, Element icon, Element warningIcon = null)
        {
            var lineRect = EditorGUILayout.GetControlRect(GUILayout.Height(40), GUILayout.Width(Screen.width - 30));

            icon.Icon(lineRect);

            if (warningIcon != null)
            {
                warningIcon.Icon(new Rect(new Vector2(Screen.width - 55, lineRect.y), Vector2.zero));
            }

            var inputRect = new Rect(lineRect.x + 30, lineRect.y, lineRect.width - 70, 30);
            var inputStyle = GUI.skin.textField;

            return EditorGUI.IntField(inputRect, value, inputStyle);
        }

        public static float SingleLineFloat(Rect rect, float value, Element icon)
        {
            icon.Icon(rect);

            var inputRect = new Rect(rect.x + 35, rect.y, rect.width - 45, 30);
            var inputStyle = GUI.skin.textField;

            return EditorGUI.FloatField(inputRect, value, inputStyle);
        }

        public static string SingleLineText(string value)
        {
            var lineRect = EditorGUILayout.GetControlRect(GUILayout.Height(30), GUILayout.Width(Screen.width - 10));

            var inputStyle = GUI.skin.textField;

            return EditorGUI.TextField(lineRect, value, inputStyle);
        }

        public static string SingleLineText(string value, Rect rect, Element icon)
        {
            var inputStyle = GUI.skin.textField;

            icon.Icon(rect);

            rect.x += 35;
            rect.y += 2;
            rect.width -= 250;

            return EditorGUI.TextField(rect, value, inputStyle);
        }

        public static float FloatPercentageSlider(Rect rect, float value, float min, float max, string detailFormat, Element icon)
        {
            icon.Icon(rect);

            var inputRect = new Rect(rect.x + 50, rect.y, Screen.width - 200, 30);
            Typography.Title(new Rect(inputRect.x, inputRect.yMax, Screen.width, 10), String.Format(detailFormat, value), Typography.Heading.h5, Colors.WetAshphalt);

            return GUI.HorizontalSlider(inputRect, value, min, max);
        }
    }
}