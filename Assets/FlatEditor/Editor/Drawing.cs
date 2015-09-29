using System.IO;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public static class Drawing
    {
        private const string DrawingPath = "Assets/FlatEditor/Editor/img/";

        private static Texture GetStateButton(Texture neutral, Texture hover, Rect rect)
        {
            return rect.Contains(Event.current.mousePosition) ? hover : neutral;
        }

        private static Texture LoadFlat(string filename)
        {
            return
                AssetDatabase.LoadAssetAtPath<Texture>(string.Format("{0}{1}.png", DrawingPath, filename));
        }

        public static Texture Circle
        {
            get { return LoadFlat("circle"); }
        }

        public static Texture Triangle(Direction direction)
        {
            switch (direction)
            {
                    case Direction.Down:
                    return LoadFlat("triangle_down");
                    case Direction.Left:
                    return LoadFlat("triangle_left");
                    case Direction.Right:
                    return LoadFlat("triangle_right");
                    case Direction.Up:
                    return LoadFlat("triangle_up");
            }
            return null;
        }


    public static Texture Pixel {
            get
            {
                return LoadFlat("1px");
            }
        }
    }
}