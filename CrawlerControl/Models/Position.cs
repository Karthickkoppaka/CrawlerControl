using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerControl.Models
{
    /// <summary>
    /// Spider Position Details with Coordinates and Orientation
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Coordinates of Spider on Wall
        /// </summary>
        public Coordinates Coordinates { get; set; }
        /// <summary>
        /// Orienation of Spider on grid
        /// </summary>
        public Orientation Orientation { get; set; }
    }

    /// <summary>
    /// Orientations on Grid
    /// </summary>
    public enum Orientation
    {
        Down = 0,
        Left = 1,
        Up = 2,
        Right = 3
    }
}
