using UnityEngine;
using System.Collections;
using UnityEditor;
using FlatEditor;
using FlatEditor.Responsive;

public class ColumnTestWindow : EditorWindow
{
    [MenuItem("Window/My Window")]
    private static void Init()
    {
        ColumnTestWindow window = GetWindow<ColumnTestWindow>();
        window.ShowUtility();
    }

    void OnGUI()
    {
        GUILayout.Label("column test", EditorStyles.boldLabel);

        GUILayout.Space(20);


        Row.Start();
        GUILayout.Label("row", EditorStyles.miniLabel);
        var a = new Column(1, 1);
        var b = new Column(4, 2);
        b.SetSize(ScreenSize.xs, 12);
        var c = new Column(6, 2);
        c.SetSize(ScreenSize.lg, 12);

        a.Start();
        GUILayout.Label("col-md-1col-offset-1");
        EditorGUILayout.ColorField(Colors.Alizarin);
        a.End();
        b.Start();
        GUILayout.Label("col-md-4 col-offset-2 col-xs-12");
        EditorGUILayout.ColorField(Colors.Belize);
        b.End();
        Row.End();
        GUILayout.Label("/row", EditorStyles.miniLabel);
        GUILayout.Label("row", EditorStyles.miniLabel);
        Row.Start();
        c.Start();
        GUILayout.Label("col-md-6 col-offset-2 col-lg-12");
        EditorGUILayout.ColorField(Colors.Emerald);
        c.End();

        Row.End();
        GUILayout.Label("/row", EditorStyles.miniLabel);

    }


}