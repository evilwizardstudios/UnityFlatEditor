using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{

    public class Column
    {
        // in terms of row units, xs-sm-md-lg
        private byte[] widths;
        private byte[] offsets;

        public Column(byte width, byte offset)
        {
            // catch impossible width/offset combinations
            if (width < 1 || width + offset > 12)
            {
                throw new Exception("FlatEditor: Columns must be wider than width 0 and cannot be larger than 12 (including offsets)");
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
            if (width < 1 || width + offset > 12)
            {
                throw new Exception("FlatEditor: Columns must be wider than width 0 and cannot be larger than 12 (including offsets)");
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

        public int Width()
        {
            return widths[(int) Responsive.CurrentScreenSize];
        }

        public int PixelWidth()
        {
            return (Width()/12)*Screen.width;
        }

        public int Offset()
        {
            return offsets[(int)Responsive.CurrentScreenSize];
        }

        public int PixelOffset()
        {
            return (Offset() / 12) * Screen.width;
        }

        public void Start()
        {
            // modify column placement based on screen size
            Responsive.NewColumn(this);


        }

        public void End()
        {

        }
    }



}



