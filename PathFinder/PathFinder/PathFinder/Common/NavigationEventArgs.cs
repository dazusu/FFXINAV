using System;

namespace PathFinder.Common
{
    public class NavigationEventArgs : EventArgs
    {
        public NavigationEventArgs(Position position)
        {
            Position = position;
        }

        public Position Position { get; }
    }
}