using UnityEngine;
using System.Collections;

namespace FlatEditor.Example
{
    /// <summary>
    /// This component doesn't actually do anything, but it does hold some navigation selections and toggle bools for demonstration purposes.
    /// </summary>
    public class ExampleComponent : MonoBehaviour
    {
        public int navSelection;
        public bool Toggle;
        public bool Dismissed;

        public string InputSingleLine;
    }
}