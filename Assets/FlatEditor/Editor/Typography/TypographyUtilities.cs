using System;
using UnityEngine;

namespace FlatEditor.Typography
{
    public static class TypographyUtilities
    {
        public static string ColoredText(Color32 color, string text)
        {
            return String.Format("{0}{1}</color>", String.Format("<color=#{0}FF>", Colors.ColorToHex(color)), text);
        }

    }
}