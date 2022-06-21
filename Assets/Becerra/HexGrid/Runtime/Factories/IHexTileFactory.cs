namespace Becerra.HexGrid.Factories
{
    using Becerra.HexGrid.Coordinates;

    /// <summary>
    /// Factory for hex tiles in the grid.
    /// </summary>
    public interface IHexTileFactory
    {
        /// <summary>
        /// Creates a new tile at the given position.
        /// </summary>
        /// <param name="cubePosition">Cube position inside the tile</param>
        /// <param name="size">Size of the tile.</param>
        /// <returns>New tile at the given position.</returns>
        IHexTile CreateHexTile(CubeCoordinates cubePosition, float size);
    }
}