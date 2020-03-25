For making a navmesh you can export the ffxi zone from Noesis using the following advanced commands.

Advanced Export Options:  to flip cords :)
-rotate 180 0 -90 -fbxsmoothgroups -fbxtexrelonly -fbxtexext .tga

export as obj


In RecastDemo 
The setting i used where
Cell  Size = 30
Cell Hight = 20

Agent:
Height = 2
Radius = 0.6
Max Climb = 2.3
Max Slope = 47

tile size = 64 or 32 its up to you. just takes longer.




FFXINAV.dll functions
unload
Initialize
GetErrorMessage
findPath_DSP_NAV_Files(position_t start, position_t end);
isNavMeshEnabled
Pathpoints
Get_m_points_X
Get_m_points_Z
ReleaseItems


I have included a test porgram for testing navmeshes.
check imports.cs and FFXINAVTOOLS.cs