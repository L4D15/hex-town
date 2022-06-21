using Unity.VisualScripting;

namespace Becerra.HexGrid.Coordinates
{
    /// <summary>
    /// Position in cube coordinates.
    /// </summary>
    [System.Serializable]
    [Inspectable]
    public struct CubeCoordinates
    {
        /// <summary>
        /// X axis
        /// </summary>
        [Inspectable]
        public int X;

        /// <summary>
        /// Y axis
        /// </summary>
        [Inspectable]
        public int Y;

        /// <summary>
        /// Z axis
        /// </summary>
        [Inspectable]
        public int Z;

        /// <summary>
        /// Initializes a new instance of the <see cref="CubeCoordinates" /> struct
        /// </summary>
        /// <param name="x">X axis coordinate</param>
        /// <param name="y">Y axis coordinate</param>
        /// <param name="z">Z axis coordinate</param>
        public CubeCoordinates(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Sum operation between cube coordinates.
        /// </summary>
        /// <param name="a">First coordinate value.</param>
        /// <param name="b">Second coordinate value.</param>
        /// <returns>Sum of the two coordinates.</returns>
        public static CubeCoordinates operator +(CubeCoordinates a, CubeCoordinates b)
        {
            return new CubeCoordinates(
                a.X + b.X,
                a.Y + b.Y,
                a.Z + b.Z);
        }

        /// <summary>
        /// Subtraction operation between cube coordinates.
        /// </summary>
        /// <param name="a">First coordinate value.</param>
        /// <param name="b">Second coordinate value.</param>
        /// <returns>Subtraction of the two coordinates.</returns>
        public static CubeCoordinates operator -(CubeCoordinates a, CubeCoordinates b)
        {
            return new CubeCoordinates(
                a.X - b.X,
                a.Y - b.Y,
                a.Z - b.Z);
        }

        /// <summary>
        /// Checks if two coordinates are equal.
        /// </summary>
        /// <param name="a">First coordinate to compare.</param>
        /// <param name="b">Second coordinate to compare.</param>
        /// <returns>True if both coordinates are equal, false otherwise.</returns>
        public static bool operator ==(CubeCoordinates a, CubeCoordinates b)
        {
            if (a.X.Equals(b.X) == false) return false;
            if (a.Y.Equals(b.Y) == false) return false;
            if (a.Z.Equals(b.Z) == false) return false;

            return true;
        }

        /// <summary>
        /// Checks if two coordinates are different.
        /// </summary>
        /// <param name="a">First coordinate to check.</param>
        /// <param name="b">Second coordinate to check.</param>
        /// <returns>True if the coordiantes are different, false if they are both the same.</returns>
        public static bool operator !=(CubeCoordinates a, CubeCoordinates b)
        {
            if (a.X.Equals(b.X) == false) return true;
            if (a.Y.Equals(b.Y) == false) return true;
            if (a.Z.Equals(b.Z) == false) return true;

            return false;
        }

        /// <summary>
        /// Generates a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({this.X},{this.Y},{this.Z})";
        }

        /// <summary>
        /// Checks if two cube coordinates are the same.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is CubeCoordinates b)
            {
                if (this.X != b.X) return false;
                if (this.Y != b.Y) return false;
                if (this.Z != b.Z) return false;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generates a hash code for hash-related operations.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.X * 10000 + this.Y * 100 + this.Z;
        }
    }
}