using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CrawlerControl.Models;

namespace CrawlerControl.BusinessHandlers
{
    /// <summary>
    /// Grid Wall Handlers
    /// </summary>
    public class GridWallHandler
    {
        /// <summary>
        /// List of directions not allowed 
        /// </summary>
        private readonly string directions = @"[^LRF]";
        /// <summary>
        /// Grid Parameters for the wall
        /// </summary>
        private readonly GridParameters gridParameters;
        /// <summary>
        /// Grid Crawler Process Handler
        /// </summary>
        private readonly GridCrawlerProcessor gridCrawlerProcessor;

        /// <summary>
        /// Grid Wall handler Constructor
        /// </summary>
        public GridWallHandler()
        {
            gridParameters = new GridParameters();
            gridCrawlerProcessor = new GridCrawlerProcessor();
        }

        /// <summary>
        /// Spider Traverser for the navigation path on the wall
        /// </summary>
        public void SpiderGridTraverser()
        {
            ReadInputGridParameters();
            var currentPosition = gridParameters?.Position !=null ? gridCrawlerProcessor.GetCurrentPosition(gridParameters) : throw new Exception("Unable to process due to invalid input parameters");
            Console.WriteLine($"Spider position after traversal <X Y Orientation>: {currentPosition.Coordinates.X} {currentPosition.Coordinates.Y} {currentPosition.Orientation}");
        }

        /// <summary>
        /// Read the input parameters from console to define the grid
        /// </summary>
        private void ReadInputGridParameters()
        {
            try
            {
                Console.WriteLine("Enter Grid Size format <X Y> (X-Coordinate, Y-Coordinate)");
                int xGridSize, yGridSize;
                var input = Console.ReadLine().Split(' ');
                gridParameters.GridSize = input != null && input[0] != null && input[1] != null &&
                                            int.TryParse(input[0], out xGridSize) && int.TryParse(input[1], out yGridSize) ?
                                            new Coordinates
                                            {
                                                X = xGridSize,
                                                Y = yGridSize
                                            } :
                                            throw new Exception("Invalid input grid size parameters");

                Console.WriteLine("Enter Current Position in format <X Y CurrentOrientation> (CurrentOrientation: Left, Right, Up, Down)");
                Orientation currentOrientation;
                input = Console.ReadLine().Split(' ');
                gridParameters.Position = input != null && input[0] != null && input[1] != null && input[2] != null && int.TryParse(input[0], out xGridSize) &&
                                             int.TryParse(input[1], out yGridSize) && xGridSize >= 0 && yGridSize >= 0 && 
                                             Enum.TryParse(input[2], ignoreCase: true,out currentOrientation) ?
                                             new Position()
                                             {
                                                 Coordinates = new Coordinates() { X = xGridSize, Y = yGridSize },
                                                 Orientation = currentOrientation
                                             } :
                                             throw new Exception("Invalid input current position parameters on grid");

                Console.WriteLine("Enter Spider Traverse path (Directions: LRF)");
                input = Console.ReadLine().Split(' ');
                gridParameters.SpiderTraversePath = input != null && !Regex.IsMatch(input[0], directions, RegexOptions.IgnoreCase) ? input[0].ToUpper() :
                                                    throw new Exception("Invalid input spider traverse path");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while processing input data : {ex.Message}");
                return;
            }
        }

        

    }
}
