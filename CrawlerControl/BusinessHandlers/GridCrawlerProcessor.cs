using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerControl.Models;

namespace CrawlerControl.BusinessHandlers
{
    /// <summary>
    /// Grid Crawler Processor to traverse on wall
    /// </summary>
    public class GridCrawlerProcessor
    {
        private readonly Func<Orientation, Orientation> adjustDirection = (input) => (int)input >= 4 ? input - 4 : (input < 0 ? input + 4 : input);

        /// <summary>
        /// Traversal on grid to get Current position
        /// Approach:
        /// Grid orientation is controlled through Enum - Down, Left, Up, Right
        /// With help of enum index orientation is incremented or decremeneted by 1 to change orientation
        ///             Up = 2
        ///  Left = 1           Right = 3
        ///             Down = 0
        ///             
        /// For traverse path direction X, Y coordinates will be changed based on direction to move across grid for Forward movement (F)
        /// and
        /// Orientation will be change for L-Left and R-Right instructions
        /// /// </summary>
        /// <param name="gridParameters">Grid parameter with definition of grid</param>
        /// <returns>Current Position Details with Coordinates and Orientation</returns>
        public Position GetCurrentPosition(GridParameters gridParameters)
        {
            foreach (char direction in gridParameters?.SpiderTraversePath)
            {
                if (direction == 'F' && gridParameters?.Position?.Orientation == Orientation.Up)
                {
                    gridParameters.Position.Coordinates.Y += 1;
                }
                else if (direction == 'F' && gridParameters?.Position?.Orientation == Orientation.Down)
                {
                    gridParameters.Position.Coordinates.Y -= 1;
                }
                else if (direction == 'F' && gridParameters?.Position?.Orientation == Orientation.Left)
                {
                    gridParameters.Position.Coordinates.X -= 1;
                }
                else if (direction == 'F' && gridParameters?.Position?.Orientation == Orientation.Right)
                {
                    gridParameters.Position.Coordinates.X += 1;
                }
                else if (direction == 'L')
                {
                    gridParameters.Position.Orientation = adjustDirection(gridParameters.Position.Orientation - 1);
                }
                else if (direction == 'R')
                {
                    gridParameters.Position.Orientation = adjustDirection(gridParameters.Position.Orientation + 1);
                }
            }
            return gridParameters.Position;
        }
    }
}
