using Unity.VisualScripting;

namespace Becerra.HexGrid.Coordinates
{
    /// <summary>
    /// Position in axial coordinates.
    /// </summary>
    [Inspectable]
    public struct AxialCoordinates
    {
        /// <summary>
        /// X axis.
        /// </summary>
        [Inspectable]
        public int X;

        /// <summary>
        /// Y axis.
        /// </summary>
        [Inspectable]
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="AxialCoordinates" /> struct.
        /// </summary>
        /// <param name="x">X axis coordinate.</param>
        /// <param name="y">Y axis coordinate.</param>
        public AxialCoordinates(int x, int y)
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