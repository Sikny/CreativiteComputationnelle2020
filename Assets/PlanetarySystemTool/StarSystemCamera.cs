using System.Collections;
using System.Collections.Generic;
using PlanetarySystemTool;
using UnityEngine;

public class StarSystemCamera : MonoBehaviour
{
    public enum CameraState {stationary,follow,look}
    
    public CameraState cameraState;
    public int planetId;
    public Vector3 followOffset;
    public StarSystem system;
    private Vector3 stationaryPosition;
    // Start is called before the first frame update
    void Start()
    {
        stationaryPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(planetId >= system.planetsInfo.Count)
        {
            planetId = system.planetsInfo.Count - 1;
        }else if(planetId < 0)
        {
            planetId = 0;
        }
        switch (cameraState)
        {
            case CameraState.stationary:
                transform.position = stationaryPosition;
                transform.LookAt(system.star);
                break;
            case CameraState.follow:
                transform.position = followOffset + system.planetsInfo[planetId].planet.position;
                transform.LookAt(system.planetsInfo[planetId].planet);
                break;
            case CameraState.look:
                transform.LookAt(system.planetsInfo[planetId].planet);
                break;
        }
    }
}
