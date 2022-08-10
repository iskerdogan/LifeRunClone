using UnityEngine;
using PathCreation;
using PathCreation.Examples;
using Utilities;

public class PathManager : Singleton<PathManager>
{
	[SerializeField]
	private PathCreator path;

	[SerializeField]
	private RoadMeshCreator pathMesh;
    
	public PathCreator Path => path;
	public RoadMeshCreator PathMesh => pathMesh;
}

