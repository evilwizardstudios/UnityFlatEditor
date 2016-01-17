using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FlatEditor.Typography;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public static class Glyphs
    {

        public static GUIStyle FontAwesomeStyle
        {
            get { return new GUIStyle(EditorStyles.label)
            {
                font = FlatFonts.FontAwesome,
                alignment = TextAnchor.MiddleCenter,
                richText = true
            };}
        }

        public static void Glyph(Rect labelRect, string glyphName, int size = 16, Direction direction = Direction.Right)
        {
            var style = FontAwesomeStyle;
            style.fontSize = size;

            if (direction == Direction.Right)
            {
                GUI.Label(labelRect, TypographyUtilities.ColoredText(FlatEditor.TextColor, GlyphString(glyphName)), style);
            }
            else
            {
                var rotation = (float) (int) direction;

                GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
                {
                    GUIUtility.RotateAroundPivot(rotation, new Vector2(labelRect.xMax - (labelRect.width/2), labelRect.yMax - (labelRect.height/2)));
                    GUI.Label(labelRect, TypographyUtilities.ColoredText(FlatEditor.TextColor, GlyphString(glyphName)), style);
                    GUIUtility.RotateAroundPivot(-rotation, new Vector2(labelRect.xMax - (labelRect.width / 2), labelRect.yMax - (labelRect.height / 2)));
                }
                GUI.EndGroup();
            }
        }

        public static GUIStyle GetGlyphStyle(string glyphName)
        {
            if (glyphName.StartsWith("fa"))
            {
                return FontAwesomeStyle;
            }

            throw new Exception("font map cannot be found");
        }

        public static bool CanParseAsGlyph(string glyphName)
        {
            return Translate(glyphName) != "INVALID GLYPH";
        }


        public static Vector2 CalculateGlyphSize(string glyphName, int fontSize)
        {
            var style = new GUIStyle(EditorStyles.label)
            {
                fontSize = fontSize,
                font = FlatFonts.FontAwesome,
                alignment = TextAnchor.MiddleCenter,
                richText = true
            };

            return style.CalcSize(new GUIContent(GlyphString(glyphName)));
        }

        public static string GlyphString(string glyphName)
        {
            return Translate(glyphName);
        }

        public static string Translate(string glyphName)
        {
            //TODO: examine the first two characters of the glyph name to determine the correct map to load.

            var mapPath = FlatEditor.FontAwesomeMapPath;

            using (var reader = new StreamReader(mapPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    if (line.Contains(glyphName))
                    {

                        return line.Substring(0, 1);
                    }
                }

                return "INVALID GLYPH";
            }

        }
    }
}

