namespace Becerra.HexGrid.Tests
{
    using Becerra.HexGrid.Coordinates;
    using NUnit.Framework;
    using UnityEngine;

    public class CoordinatesTests
    {
        [TestFixture]
        public class AxialToWorldConversion
        {
            [Test]
            public void ConvertOrigin()
            {
                float tileSize = 1f;

                var axial = new AxialCoordinates(0, 0);
                var world = CoordinatesConversor.AxialToWorld(axial, tileSize, tileSize);

                Assert.AreEqual(new Vector2(0f, 0f), world);
            }

            [Test]
            public void ConvertRightTile()
            {
                float tileSize = 1f;

                var axial = new AxialCoordinates(1, 0);
                var world = CoordinatesConversor.AxialToWorld(axial, tileSize, tileSize);

                Assert.AreEqual(new Vector2(1f, 0f), world);
            }

            [Test]
            public void ConvertLeftTile()
            {
                float tileSize = 1f;

                var axial = new AxialCoordinates(-1, 0);
                var world = CoordinatesConversor.AxialToWorld(axial, tileSize, tileSize);

                Assert.AreEqual(new Vector2(-1f, 0f), world);
            }

            [Test]
            public void ConvertTopLeftTile()
            {
                float tileSize = 1f;

                var axial = new AxialCoordinates(0, -1);
                var world = CoordinatesConversor.AxialToWorld(axial, tileSize, tileSize);

                Assert.AreEqual(new Vector2(-tileSize * 0.5f, tileSize * 3f / 4f), world);
            }

            [Test]
            public void ConvertTopRightTile()
            {
                float tileSize = 1f;

                var axial = new AxialCoordinates(1, -1);
                var world = CoordinatesConversor.AxialToWorld(axial, tileSize, tileSize);

                Assert.AreEqual(new Vector2(tileSize * 0.5f, tileSize * 3f / 4f), world);
            }

            [Test]
            public void ConvertBottomLeftTile()
            {
                float tileSize = 1f;

                var axial = new AxialCoordinates(-1, 1);
                var world = CoordinatesConversor.AxialToWorld(axial, tileSize, tileSize);

                Assert.AreEqual(new Vector2(-tileSize * 0.5f, -tileSize * 3f / 4f), world);
            }

            [Test]
            public void ConvertBottomRightTile()
            {
                float tileSize = 1f;

                var axial = new AxialCoordinates(0, 1);
                var world = CoordinatesConversor.AxialToWorld(axial, tileSize, tileSize);

                Assert.AreEqual(new Vector2(tileSize * 0.5f, -tileSize * 3f / 4f), world);
            }
        }

        [TestFixture]
        public class WorldToAxialConversion
        {
            private float tileSize = 1f;

            [Test]
            public void ConvertOrigin()
            {
                var world = new Vector2(0f, 0f);

                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(0, 0), axial);
            }

            [Test]
            public void ConvertLeftTile()
            {
                var world = new Vector2(-1f * this.tileSize, 0f);
                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(-1, 0), axial);
            }

            [Test]
            public void ConvertRightTile()
            {
                var world = new Vector2(1f * this.tileSize, 0f);
                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(1, 0), axial);
            }

            [Test]
            public void ConvertTopLeftTile()
            {
                var world = new Vector2(-0.5f * this.tileSize, this.tileSize * 3f / 4f);
                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(0, -1), axial);
            }

            [Test]
            public void ConvertTopRightTile()
            {
                var world = new Vector2(0.5f * this.tileSize, this.tileSize * 3f / 4f);
                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(1, -1), axial);
            }

            [Test]
            public void ConvertBottomLeftTile()
            {
                var world = new Vector2(-0.5f * this.tileSize, -this.tileSize * 3f / 4f);
                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(-1, 1), axial);
            }

            [Test]
            public void ConvertBottomRightTile()
            {
                var world = new Vector2(0.5f * this.tileSize, -this.tileSize * 3f / 4f);
                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(0, 1), axial);
            }

            [Test]
            public void ConvertNotPrecisse()
            {
                var world = new Vector2(0.5f * this.tileSize + 0.1f, -this.tileSize * 3f / 4f - 0.1f);
                var axial = CoordinatesConversor.WorldToAxial(world, this.tileSize, this.tileSize);

                Assert.AreEqual(new AxialCoordinates(0, 1), axial);
            }
        }
    }
}