using UnityEngine;
using System.Collections;
using UnityEditor;
using FlatEditor;

public class ColumnTestWindow : EditorWindow
{

    [MenuItem("Window/My Window")]
    private static void Init()
    {
        // Get existing open window or if none, make a new one:
        ColumnTestWindow window = GetWindow<ColumnTestWindow>();
        window.ShowUtility();
    }

    void OnGUI()
    {
        GUILayout.Label("non columnar test", EditorStyles.boldLabel);

        GUILayout.Space(50);

        var a = new Column(2, 5);
        var b = new Column(3, 2);
        b.SetSize(ScreenSize.xs, 12);
        var c = new Column();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(20);

        a.Start();
        EditorGUILayout.ColorField(new Color());
        a.End();
        b.Start();
        EditorGUILayout.ColorField(new Color());
        b.End();
        c.Start();
        EditorGUILayout.ColorField(new Color());
        c.End();

        GUILayout.Space(20);
        EditorGUILayout.EndHorizontal();
        
    }

}