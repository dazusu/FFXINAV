namespace PathFinder.Common
{
    public class Connection
    {
        public position_t To;
        public float Length;

        public Connection(position_t to, float length)
        {
            To = to;
            Length = length;
        }
    }
}