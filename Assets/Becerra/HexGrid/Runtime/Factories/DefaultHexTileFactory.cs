namespace Becerra.HexGrid.Factories
{
    using Becerra.HexGrid.Coordinates;
    using UnityEngine;

    /// <summary>
    /// Default implementation of the hex tile factory.
    /// This will create tiles of type <see cref="HexTile"/>.
    /// Attach this component to the same game object where the
    /// HexGrid is and the grid will create tiles using this factory.
    /// </summary>
    public class DefaultHexTileFactory : MonoBehaviour, IHexTileFactory
    {
        public IHexTile CreateHexTile(CubeCoordinates cubePosition, float size)
        {
            return new HexTile(cubePosition, size);
        }
    }
}