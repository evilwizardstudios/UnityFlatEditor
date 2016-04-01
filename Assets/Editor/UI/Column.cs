using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FlatEditor.Responsive
{
    /// <summary>
    /// By default, columns are described in units of width out of 12 (like Bootstrap). Columns must be declared within a Row.Start().
    /// </summary>
    public class Column
    {
        private Rect columnRect;

        // in terms of row units, xs-sm-md-lg
        private byte[] widths;
        private byte[] offsets;

        public Column(byte width, byte offset = 0)
        {
            // catch impossible width/offset combinations
            if (width + offset > 12)
            {
                throw new Exception("FlatEditor: Columns cannot be larger than width 12 (including offsets)");
            }

            widths = new byte[4];
            offsets = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                widths[i] = width;
                offsets[i] = offset;
            }
        }

        public Column()
        {
            widths = new byte[4];
            offsets = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                widths[i] = 12;
                offsets[i] = 0;
            }
        }

        /// <summary>
        /// Set the column size (in column units out of 12) and offset (also in column units) at a resolution breakpoint.
        /// Widths cannot be zero, and width + column size must equal 12 or less.
        /// </summary>
        public void SetSize(ScreenSize size, byte width, byte offset = 0)
        {
            if (width + offset > 12)
            {
                throw new Exception("FlatEditor: Columns width cannot be larger than 12 (including offsets)"); 
            }

            switch (size)
            {
                case ScreenSize.xs:
                    widths[0] = width;
                    offsets[0] = offset;
                    break;
                case ScreenSize.sm:
                    widths[1] = width;
                    offsets[1] = offset;
                    break;
                case ScreenSize.md:
                    widths[2] = width;
                    offsets[2] = offset;
                    break;
                case ScreenSize.lg:
                    widths[3] = width;
                    offsets[3] = offset;
                    break;
            }
        }

        public int Width
        {
            get { return widths[(int) Grid.CurrentScreenSize]; }
        }

        public float PixelWidth
        {
            get { return (Width/12f)*(Screen.width); }
        }

        public int Offset
        {
            get { return offsets[(int) Grid.CurrentScreenSize]; }
        }

        public float PixelOffset
        {
            get { return (Offset/12f)*(Screen.width); }
        }

        public void Start()
        {
            var row = Grid.OpenRow;

            if (row.ColumnPosition + Width + Offset > 12) row.Break();

            if (Offset > 0) DrawOffset(row);

            columnRect = EditorGUILayout.BeginVertical(GUILayout.Width(PixelWidth));
        }

        public void End()
        {
            EditorGUILayout.EndVertical();
            Grid.OpenRow.ColumnPosition += Width;
        }

        private void DrawOffset(Row row)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(PixelOffset);
            EditorGUILayout.EndHorizontal();

            row.ColumnPosition += Offset;
        }
    }



}



