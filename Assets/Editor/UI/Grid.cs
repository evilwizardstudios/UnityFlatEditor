using System;
using UnityEditor;
using UnityEngine;

namespace FlatEditor.Responsive
{
    public static class Grid
    {

        public static Row OpenRow
        {
            get
            {
                if (_openRow == null)
                {
                    throw new Exception("No currently open row. Start a new Row before adding columns.");
                }
                else
                {
                    return _openRow;
                }
            }
        }

        private static Row _openRow;

        public static void NewRow(Row row)
        {
            _openRow = row;
            EditorGUILayout.BeginHorizontal();
        }

        public static void EndRow()
        {
            if (_openRow.ColumnPosition < 12)
            {
                _openRow.TrailingOffset(12 - _openRow.ColumnPosition);
            }

            EditorGUILayout.EndHorizontal();
            _openRow = null;
        }


        public static int ScreenWidth { get; set; }

        // Returns the screen size we're currently in, based on breakpoint
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

    }
}