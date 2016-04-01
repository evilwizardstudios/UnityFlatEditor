using System.Collections.Generic;
using System.Linq;
using FlatEditor;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    internal class FlatEditorObjectBrowser
    {

        private List<GameObject> FlatEditorObjects; 

        public FlatEditorObjectBrowser()
        {
            var allAssetsPaths =
                AssetDatabase.FindAssets("l: FlatEditorObject").Select(s => AssetDatabase.GUIDToAssetPath(s));

            FlatEditorObjects =
                allAssetsPaths.Select(
                    path => AssetDatabase.LoadAssetAtPath<GameObject>(path)).ToList();
        }
        
        public void Draw()
        {
            if (!FlatEditorObjects.Any())
            {
                GUI.Box(EditorGUILayout.GetControlRect(GUILayout.ExpandHeight(true)),
                        "<b>No FlatEditor-enabled objects found in the project! Create some to continue.\n" +
                        "If objects are missing, click the Diagnose and Repair tool to the left.</b>",
                    FlatStyles.InfoPanel);
                return;
            }

            int columns = 5;
            int row = 0;
            int spacer = 0;
            var rect = EditorGUILayout.GetControlRect(GUILayout.Width(140), GUILayout.Height(140));

            foreach (GameObject o in FlatEditorObjects)
            {
                ObjectIcon(o, rect);
                rect.x += rect.width + 15;
                row++;

                if (row == columns)
                {
                    GUILayout.Space(45);
                    rect = EditorGUILayout.GetControlRect(GUILayout.Width(140), GUILayout.Height(140));
                    row = 0;
                    spacer++;
                }
            }

            GUILayout.Space(25);


        }

        private void ObjectIcon(GameObject gameObject, Rect rect)
        {
            GUI.color = rect.Contains(Event.current.mousePosition) ? (Color32)Colors.Turquoise : new Color32(82, 82, 82, 255);
            GUI.Box(rect, "", FlatStyles.InfoPanel);
            GUI.Box(new Rect(rect.x, rect.yMax-12, rect.width, 40), Typography.ColoredText(Colors.Clouds, string.Format("<b>{0}</b>", gameObject.name)), FlatStyles.InfoPanel);
            GUI.color = Color.white;

            if (GUI.Button(rect, new GUIContent(AssetPreview.GetAssetPreview(gameObject))))
            {
                EditorGUIUtility.PingObject(gameObject);
                Selection.activeGameObject = gameObject;
            }
        }
    }
}