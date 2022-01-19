using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CrawlerControl.Models;
using CrawlerControl.BusinessHandlers;

namespace CrawlerControlTests
{
    [TestClass]
    public class GridCrawlerProcessorTests
    {
        [TestMethod]
        public void GetCurrentPositionTest()
        {
            // Input Parameters
            GridParameters gridInputParameters = new GridParameters();
            gridInputParameters.GridSize = new Coordinates()
            {
                X = 7,
                Y = 15
            };
            gridInputParameters.Position = new Position()
            {
                Coordinates = new Coordinates() { X = 4, Y = 10 },
                Orientation = Orientation.Left
            };
            gridInputParameters.SpiderTraversePath = "FLFLFRFFLF";

            // Expected Position
            Position expectedOutput = new Position()
            {
                Coordinates = new Coordinates() { X = 5, Y = 7 },
                Orientation = Orientation.Right
            };

            GridCrawlerProcessor gridCrawlerProcessor = new GridCrawlerProcessor();
            var outputPath = gridCrawlerProcessor.GetCurrentPosition(gridInputParameters);

            // Comparision of Expected and Output Position after traversal
            Assert.AreEqual(expectedOutput.Coordinates.X, outputPath.Coordinates.X);
            Assert.AreEqual(expectedOutput.Coordinates.Y, outputPath.Coordinates.Y);
            Assert.AreEqual(expectedOutput.Orientation, outputPath.Orientation);
        }
    }
}
