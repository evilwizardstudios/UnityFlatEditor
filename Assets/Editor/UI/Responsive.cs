using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public static class Responsive
    {
        public static int ScreenWidth { get; set; }

        // Returns which screen size we have to use 
        public static ScreenSize CurrentScreenSize
        {
            get
            {
                if (Screen.width >= (int) Breakpoint.lg) return ScreenSize.lg;
                else if (Screen.width >= (int) Breakpoint.md) return ScreenSize.md;
                else if (Screen.width >= (int) Breakpoint.sm) return ScreenSize.sm;
                else return ScreenSize.xs;
            }
        }

        // A 'pointer' to track where we start drawing the next column in the layout
        public static int ColumnPosition;
        private static Rect lastColumnRect;

        public static void NewResponsiveWindow()
        {
            ColumnPosition = 0;
            lastColumnRect = new Rect();
        }

        public static void NewColumn(Column column)
        {
            ColumnPosition += column.Width() + column.Offset();
            if (ColumnPosition > 12)
            {
                RowBreak();
                ColumnPosition = column.Width() + column.Offset();
            }

            //draw the empty offset
            if (column.Offset() > 0)
            {
                //make fixed area column offset
            }

            //begin the column
            EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(column.PixelWidth()), GUILayout.Width(column.PixelWidth()));
        }

        public static void EndColumn()
        {
            EditorGUILayout.EndHorizontal();
        }

        // breaks and re-starts the horizontal layout group of the current row, so the layout doesn't extend out of bounds
        private static void RowBreak()
        {
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
        }

    }
}