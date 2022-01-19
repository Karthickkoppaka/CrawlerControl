# CrawlerControl

**Requirement:**
Create a Grid Wall traverser defined with <X, Y> coordinates and Orientation - UP, LEFT, RIGHT and DOWN

**Solution:**

*A console job is designed to accept the parameters from console input as below and Output of path after traversal is returned to console.*

Input is captured from console as below:

Enter Grid Size format <X Y> (X-Coordinate, Y-Coordinate)
7 15

Enter Current Position in format <X Y CurrentOrientation> (CurrentOrientation: Left, Right, Up, Down)
4 10 Left

Enter Spider Traverse path (Directions: LRF)
FLFLFRFFLF


**Output** Returned to console as :
Spider position after traversal <X Y Orientation>: **5 7 Right** 


**Main Project: CrawlerControl**

**Project Structure:**
CrawlerControl.csproj

 - Program.cs : Invokes main process

 - Models (Model Classes to capture Input)

    - Coordinates.cs : Defines X Y Coordinates

    - Position.cs : Defines Orientation - Down, Left, Up, Right, And positional coordinates

    - GridParameters.cs : Includes defintion of Grid Size, Current Spider Coordinates, Traverse Path for spider

  - BusinessHandlers (Fetch input parameters and To process grid traversal)
    
    - GridWallHandler.cs : Fetches input grid parameters and invoke grid traversal methods
    - GridCrawlerProcessor.cs: Perform grid traversal based on spider path
    
  **Test Project:** CrawlerControlTests.csproj
  
  **Test Project Structure:**
  
    -  GridCrawlerProcessorTests.cs : GetCurrentPositionTest method to test the path traversal functionality

