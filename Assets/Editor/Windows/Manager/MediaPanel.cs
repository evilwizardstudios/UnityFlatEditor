using System.Collections.Generic;
using System.Linq;
using FlatEditor;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    internal abstract class MediaPanel
    {
        private readonly Element _icon;

        const int LeftColumnPixelWidth = 50;

        protected MediaPanel(Element icon)
        {
            _icon = icon;
        }

        public virtual void Show()
        {
            //initial panel L/R
            EditorGUILayout.BeginHorizontal();
            {
                //identifier icon
                _icon.Icon(EditorGUILayout.GetControlRect(GUILayout.Width(LeftColumnPixelWidth)));

                //content panel
                EditorGUILayout.BeginVertical();
                {
                    Content();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);
        }

        protected abstract void Content();
    }
}