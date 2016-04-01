using System;
using UnityEditor;
using UnityEngine;

namespace FlatEditor
{
    public abstract class Dropdown : EditorWindow
    {
        private Vector2 _size;

        public virtual void Init(Vector2 size)
        {
            _size = size;
            ShowAsDropDown(EditorUtilities.AbsolutePositionRect(_size), _size);
        }

        public static T ShowDropdown<T>(Vector2 size) where T : Dropdown
        {
            var dropdown = CreateInstance<T>();
            dropdown.Init(size);
            return dropdown;
        }

    }
}