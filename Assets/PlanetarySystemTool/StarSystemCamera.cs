using System.Collections;
using System.Collections.Generic;
using PlanetarySystemTool;
using UnityEngine;

public class StarSystemCamera : MonoBehaviour
{
    public enum CameraState: int {stationary,follow,look}
    
    public CameraState cameraState;
    public int planetId;
    public Vector3 followOffset;
    public StarSystem system;
    public Vector3 stationaryPosition;

    [Header("Inputs")]
    public KeyCode decreasePlanetId;
    public KeyCode increasePlanetId;
    public KeyCode decreaseMode;
    public KeyCode increaseMode;
    

    void Update()
    {
        //Debug.Log(cameraState.GetHashCode());
        updateMode();
        updateTarget();
        clampPlanetId();
        switch (cameraState)
        {
            case CameraState.stationary:
                transform.position = stationaryPosition;
                transform.LookAt(system.star);
                break;
            case CameraState.follow:
                updateTarget();
                transform.position = followOffset + system.planetsInfo[planetId].planet.position;
                transform.LookAt(system.planetsInfo[planetId].planet);
                break;
            case CameraState.look:
                transform.position = stationaryPosition;
                transform.LookAt(system.planetsInfo[planetId].planet);
                break;
        }
    }

    private void updateMode()
    {
        int hash = cameraState.GetHashCode();
        if (Input.GetKeyDown(decreaseMode))
        {
            hash -= 1;
        }else if (Input.GetKeyDown(increaseMode))
        {
            hash += 1;
        }

        if (hash > 2) hash = 0;
        if (hash < 0) hash = 2;
        cameraState = (CameraState) hash;
    }

    private void updateTarget()
    {
        if (Input.GetKeyDown(decreasePlanetId))
        {
            planetId -= 1;
            if (planetId < 0) planetId = system.planetsInfo.Count - 1;
        }else if (Input.GetKeyDown(increasePlanetId))
        {
            planetId += 1;
            if (planetId >= system.planetsInfo.Count) planetId = 0;
        }
    }
    
    private void clampPlanetId()
    {
        if (planetId >= system.planetsInfo.Count)
        {
            planetId = system.planetsInfo.Count - 1;
        }
        else if (planetId < 0)
        {
            planetId = 0;
        }
    }

}
