using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerControl.BusinessHandlers;

namespace CrawlerControl
{
    class Program
    {
        static void Main(string[] args)
        {
            GridWallHandler gridWallHandler = new GridWallHandler();
            //Invoke Spider Grid program
            gridWallHandler.SpiderGridTraverser();
        }
    }
}
