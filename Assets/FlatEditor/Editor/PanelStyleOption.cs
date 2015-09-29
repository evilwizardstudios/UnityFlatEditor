using System;

namespace FlatEditor
{
    [Flags]
    public enum PanelStyleOption
    {
        None = 0x0,
        Outline = 0x1,
        Depth = 0x2,
        DropShadow = 0x4,
        Badge = 99
    }
}