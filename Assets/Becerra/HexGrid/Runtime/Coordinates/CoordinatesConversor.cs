namespace Becerra.HexGrid.Coordinates
{
    using UnityEngine;

    /// <summary>
    /// Operations to convert from one coordinates to another.
    /// </summary>
    public static class CoordinatesConversor
    {
        /// <summary>
        /// Collection of coordinates changes to obtain a list of cube coordinates
        /// for the neighbors of a tile.
        /// </summary>
        private static readonly CubeCoordinates[] NeighborDeltas = new CubeCoordinates[]
        {
            new CubeCoordinates(+1, -1, 0),
            new CubeCoordinates(+1, 0, -1),
            new CubeCoordinates(0, +1, -1),
            new CubeCoordinates(-1, +1, 0),
            new CubeCoordinates(-1, 0, +1),
            new CubeCoordinates(0, -1, +1)
        };

        /// <summary>
        /// Collection of coordinate deltas to apply to a grid position in cube coordinates
        /// to obtain its neighboring tiles.
        /// </summary>
        public static CubeCoordinates[] NeighborsCubeCoordinates => NeighborDeltas;

        /// <summary>
        /// Converts a position from cube coordinates to axial coordinates.
        /// </summary>
        /// <param name="cubePosition">Position in cube coordinates.</param>
        /// <returns>Position in axial coordinates.</returns>
        public static AxialCoordinates CubeToAxial(CubeCoordinates cubePosition)
        {
            var q = cubePosition.X;
            var r = cubePosition.Z;

            return new AxialCoordinates(q, r);
        }

        /// <summary>
        /// Converts a position from axial coordinates to cube coordinates.
        /// </summary>
        /// <param name="axialPosition">Position in axial coordinates.</param>
        /// <returns>Position in cube coordinates.</returns>
        public static CubeCoordinates AxialToCube(AxialCoordinates axialPosition)
        {
            var x = axialPosition.X;
            var z = axialPosition.Y;
            var y = -x - z;

            return new CubeCoordinates(x, y, z);
        }

        /// <summary>
        /// Converts a position from cube coordinates to offset coordinates.
        /// This assumes you are using a odd-row offset grid.
        /// </summary>
        /// <param name="cubePosition">Position in cube coordinates</param>
        /// <returns>Position in offset coordinates</returns>
        public static OffsetCoordinates CubeToOffset(CubeCoordinates cubePosition)
        {
            var x = cubePosition.X + Mathf.RoundToInt((cubePosition.Z - (cubePosition.Z & 1)) / 2f);
            var y = cubePosition.Z;

            return new OffsetCoordinates(x, y);
        }

        /// <summary>
        /// Converts a position from offset coordinates to cube coordinates.
        /// This assumes you are using a odd-row offset grid.
        /// </summary>
        /// <param name="offsetPosition">Position in offset coordinates.</param>
        /// <returns>Position in cube coordinates.</returns>
        public static CubeCoordinates OffsetToCube(OffsetCoordinates offsetPosition)
        {
            var x = offsetPosition.X - Mathf.RoundToInt((offsetPosition.Y - (offsetPosition.Y & 1)) / 2f);
            var z = offsetPosition.Y;
            var y = -x - z;

            return new CubeCoordinates(x, y, z);
        }

        /// <summary>
        /// Converts a position from offset coordinates to axial coordinates.
        /// </summary>
        /// <param name="offsetPosition">Position in offset coordinates.</param>
        /// <returns>Position in axial coordinates.</returns>
        public static AxialCoordinates OffsetToAxial(OffsetCoordinates offsetPosition)
        {
            var cube = OffsetToCube(offsetPosition);

            return CubeToAxial(cube);
        }

        /// <summary>
        /// Converts a position from axial coordinates to offset coordinates.
        /// </summary>
        /// <param name="axialPosition">Position in axial coordinates.</param>
        /// <returns>Position in offset coordinates.</returns>
        public static OffsetCoordinates AxialToOffset(AxialCoordinates axialPosition)
        {
            var cube = AxialToCube(axialPosition);

            return CubeToOffset(cube);
        }

        /// <summary>
        /// Converts from axial grid position to a world position.
        /// </summary>
        /// <param name="axial">Axial position.</param>
        /// <param name="tileWidth">Width of tiles in the grid.</param>
        /// <param name="tileHeight">height of tiles in the grid.</param>
        /// <returns>World position of the tile's center.</returns>
        public static Vector2 AxialToWorld(AxialCoordinates axial, float tileWidth, float tileHeight)
        {
            var x = (axial.X + axial.Y * 0.5f) * tileWidth;
            var y = (-1f) * axial.Y * tileHeight * (3f / 4f);

            return new Vector2(x, y);
        }

        /// <summary>
        /// Converts from world position to axial position in the grid.
        /// </summary>
        /// <param name="world">World position.</param>
        /// <param name="tileWidth">Width of tiles in the grid.</param>
        /// <param name="tileHeight">Height of tiles in the grid.</param>
        /// <returns>Axial position of the grid containing the world position provided.</returns>
        public static AxialCoordinates WorldToAxial(Vector2 world, float tileWidth, float tileHeight)
        {
            var y = (-1f) * ((4f * world.y) / (3f * tileHeight));
            var x = (world.x / tileWidth) - y * 0.5f;
            var axial = new AxialCoordinates(Mathf.RoundToInt(x), Mathf.RoundToInt(y));

            return axial;
        }

        /// <summary>
        /// Converts from a cube position to a world position.
        /// </summary>
        /// <param name="cubePosition">Cube position of the tile.</param>
        /// <param name="tileWidth">Width of tiles in the grid.</param>
        /// <param name="tileHeight">Height of tiles in the grid.</param>
        /// <returns>Position in world coordinates.</returns>
        public static Vector2 CubeToWorld(CubeCoordinates cubePosition, float tileWidth, float tileHeight)
        {
            var axial = CubeToAxial(cubePosition);

            return AxialToWorld(axial, tileWidth, tileHeight);
        }

        /// <summary>
        /// Converts from a world position to a cube position.
        /// </summary>
        /// <param name="worldPosition">Position in world coordinates.</param>
        /// <returns>Position in cube coordinates inside the grid.</returns>
        public static CubeCoordinates WorldToCube(Vector2 worldPosition, float tileWidth, float tileHeight)
        {
            var axial = WorldToAxial(worldPosition, tileWidth, tileHeight);

            return AxialToCube(axial);
        }

        /// <summary>
        /// Calculates all six neighbors of a tile.
        /// </summary>
        /// <param name="cubePosition">Cube position of the tile at the center.</param>
        /// <param name="neighborsPositions">Array to store the positions. It must be, at least, of size 6.</param>
        public static void CalculateNeighboringTiles(CubeCoordinates cubePosition, ref CubeCoordinates[] neighborsPositions)
        {
            for (int i = 0; i < NeighborDeltas.Length && i < neighborsPositions.Length; i++)
            {
                neighborsPositions[i] = cubePosition + NeighborDeltas[i];
            }
        }
    }
}