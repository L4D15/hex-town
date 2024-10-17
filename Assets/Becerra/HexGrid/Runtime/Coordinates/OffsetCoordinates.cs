
namespace Becerra.HexGrid.Coordinates
{
    /// <summary>
    /// Position in offset coordinates.
    /// </summary>
    public struct OffsetCoordinates
    {
        /// <summary>
        /// X axis.
        /// </summary>
        public int X;

        /// <summary>
        /// Y axis.
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsetCoordinates" /> struct.
        /// </summary>
        /// <param name="x">X axis coordinates.</param>
        /// <param name="y">Y axis coordinates.</param>
        public OffsetCoordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Generates a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }
}