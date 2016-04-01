using UnityEditor;
using UnityEngine;

namespace FlatEditor.Responsive
{
    /// <summary>
    /// The row tracks column positioning (GUILayoutOption won't work for our columns) and enforces horizontal margins.
    /// Columns must be contained within a row.
    /// Rows cannot be nested.
    /// </summary>
    public class Row
    {
        public int ColumnPosition;

        public Row()
        {
            ColumnPosition = 0;
        }
        
        public static void Start()
        {
            Grid.NewRow(new Row());
        }

        public static void End()
        {
            Grid.EndRow();
        }

        /// <summary>
        /// If the line extends beyond 12 column units, force the row to end and start a new one.
        /// We don't override the row reference in the Grid, to preserve column behavior.
        /// </summary>
        public void Break()
        {
            if (ColumnPosition < 12) TrailingOffset(12 - ColumnPosition);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();

            ColumnPosition = 0;
        }

        /// <summary>
        /// Limit row layouts that don't extend a full 12 units by drawing an empty column of the appropriate size.
        /// </summary>
        public void TrailingOffset(int remainingColumns)
        {
            var trail = new Column(0, (byte) remainingColumns);
            trail.Start();
            trail.End();
        }
    }
}