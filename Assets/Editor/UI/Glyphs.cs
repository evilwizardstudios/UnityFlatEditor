using System.IO;
using UnityEngine;

namespace FlatEditor
{
    public static class Glyphs
    {

        public static void Glyph(Rect labelRect, string rawGlyph, Color color, int size)
        {
            FlatStyles.Glyph.fontSize = size;
            GUI.Label(labelRect, Typography.ColoredText(color, rawGlyph), FlatStyles.Glyph);
            FlatStyles.Glyph.fontSize = 16;
        }

        
    }
}

