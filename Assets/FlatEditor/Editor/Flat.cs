using System;
using System.Linq;
using FlatEditor.Buttons;
using FlatEditor.Input;
using FlatEditor.Typography;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{

    public static class Flat
    {
        public static void Line()
        {
            var linerect = GUILayoutUtility.GetRect(Screen.width, 1);
            GUI.color = Color.black;
            GUI.DrawTexture(linerect, Drawing.Pixel, ScaleMode.StretchToFill);
            Colors.ResetUIColor();
        }

        public static void Title(string text, Heading heading, string secondaryText = null, bool centered = false)
        {
            Text.Title(text, heading, centered, secondaryText);
        }

        public static void Paragraph(string text, bool lead = false)
        {
            Text.Paragraph(text, lead);
        }

        public static void Quote(string quote, string source, Style blockStyle = Style.Primary, bool reverse = false)
        {
            Text.Blockquote(Colors.ColorFromStyle(blockStyle), quote, source, reverse);
        }

        public static bool Button(string content, Style style = Style.Default, string glyph = null, string badge = null, Size size = Size.Default, bool block = true)
        {
            return style == Style.Link ? ButtonUtility.DrawButton(content, glyph, badge, new Color32(0,0,0,0), size, block) 
                : ButtonUtility.DrawButton(content, glyph, badge, Colors.ColorFromStyle(style), size, block);
        }

        public static string TextInput(string text, string frontAddon = null, string backAddon = null, string glyph = null)
        {
            return Forms.TextInputGroup(text, frontAddon, backAddon, glyph);
        }

    }
}