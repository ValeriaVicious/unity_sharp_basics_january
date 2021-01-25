using System;
using UnityEngine;


namespace GeekBrains
{
    public sealed class CaughtPlayerEventArgs : EventArgs
    {
        public Color Color { get; }

        public CaughtPlayerEventArgs(Color color)
        {
            Color = color;
        }
    }
}
