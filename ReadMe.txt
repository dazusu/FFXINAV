###FFXINAV.dll for Final Fantasy XI 

FFXINAV.dll is a project I am working on to path find using navigation meshes Made with recastdetour demo.exe, the dll source code isn’t available to public right now. 

 

### FFXINAV.dll function 

   * unload 

   * Initialize 

   * GetErrorMessage 

   * findPath_DSP_NAV_Files(position_t start, position_t end); 

   * findPath(position_t start, position_t end); 

   * isNavMeshEnabled 

   * PathpointsGet_m_points_X 

   * Get_m_points_Z 

   * ReleaseItems 

 

    ### findPath_DSP_NAV_Files(position_t start, position_t end); 

  will work the the darkstar project navmeshes found here 

https://github.com/DarkstarProject/xiNavmeshes 

In the test project “pathfinder.exe” you will see the dsp meshes don’t return good paths, Tile size is very big and no objects are included. So you will hit stuff when pathfinding. 

 

    ### findPath(position_t start, position_t end); 

This is to be used with the navmeshes made using the obj files exported from noesis.  

 

 

### PathFinder.exe  

This is just a test app written in c#.  that uses FFXINAV.dll and the EliteMMO api. 

#### Powered by EliteMMO Network
[![EliteMMO Network, your source for cheat, hacks, tutorials and more!!!](http://www.elitemmonetwork.com/img/468_60_FFXI.gif)](http://www.elitemmonetwork.com)

PathFinder.exe uses the EliteMMO API provided by Wiccaan at EliteMMO Network. Without his hard work and generosity in keeping the EliteAPI free to use, progress on this program would not be possible. 

 

### Noesis  

I use Noesis to export Final Fantasy XI maps to obj files to be used by recastdetour demo.exe 

To export maps so they are compatible with FFXINAV.dll please use the following settings. 

Output type = obj. 

Advanced Export Options: 

-rotate 180 0 -90 -fbxsmoothgroups -fbxtexrelonly -fbxtexext .tga 

You can download Noesis from the link below. 

https://richwhitehouse.com/index.php?content=inc_projects.php&filemirror=noesisv44191.zip 

 

### RecastDemo.exe 

This is trial and error atm.  

Settings I have been using are  

Cell size =30 

Cell height = 20 

Agent radius = 4 

Detailed mesh sample distance = 3 

Tile size 32, 48 or 64.  

You may have to go in and remove parts of the mesh using the Create tiles tool. Shift key + left mouse button removes tile. 

 

When finished save the mesh as “Zone”.nav  

 

### NavMeshes  

If anyone is willing to help make new navmeshes for ffxi using noesis to export the zones, that would be great. Please contact me. 
