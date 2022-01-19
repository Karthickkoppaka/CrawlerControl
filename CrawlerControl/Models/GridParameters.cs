using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerControl.Models
{
    /// <summary>
    /// Grid Definition Paramters
    /// </summary>
    public class GridParameters
    {
        /// <summary>
        /// Total Grid Size
        /// </summary>
        public Coordinates GridSize { get; set; }
        /// <summary>
        /// Current position of Spider on grid
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// Traverse Path for spider on grid
        /// </summary>
        public string SpiderTraversePath { get; set; }
    }
}
