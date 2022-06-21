namespace Becerra.HexGrid
{
    using Becerra.HexGrid.Coordinates;
    using UnityEngine;

    /// <summary>
    /// One hexagonal tile inside a hex grid.
    /// </summary>
    public interface IHexTile
    {
        /// <summary>
        /// Gets the position in world coordinates.
        /// </summary>
        Vector2 WorldPosition { get; }

        /// <summary>
        /// Gets the position in cube coordinates inside a hex grid.
        /// </summary>
        CubeCoordinates CubePosition { get; }

        /// <summary>
        /// Gets the position in offset coordinates inside a hex grid.
        /// </summary>
        OffsetCoordinates OffsetPosition { get; }

        /// <summary>
        /// Gets the position of the tile inside a grid, in axial coordinates.
        /// </summary>
        AxialCoordinates AxialPosition { get; }

        /// <summary>
        /// Gets the size of the hex tile, from its center to one of the corners.
        /// </summary>
        float Size { get; }

        /// <summary>
        /// Gets the horizontal length of the tile.
        /// </summary>
        float Width { get; }

        /// <summary>
        /// Gets the vertical length of the tile.
        /// </summary>
        float Height { get; }

        /// <summary>
        /// Number of corners of an hexagon.
        /// </summary>
        int CornersCount { get; }

        /// <summary>
        /// Number of neighbors this tile can have.
        /// </summary>
        int NeighborsCount { get; }

        /// <summary>
        /// Gets the world position of one of the six corners of the hexagonal tile.
        /// </summary>
        /// <param name="cornerIndex">Index of the tile, from 0 to 5.</param>
        /// <returns>Position of the corner in world coordinates.</returns>
        Vector2 GetCorner(int cornerIndex);

        /// <summary>
        /// Gets the position of a neighbor tile.
        /// </summary>
        /// <param name="neighborIndex">Index of the neighbor, from 0 to <see cref="NeighborsCount"/></param>
        /// <returns>Cube position of the neighbor tile.</returns>
        CubeCoordinates GetNeighborPosition(int neighborIndex);
    }
}