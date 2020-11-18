using System.Collections;
using System.Collections.Generic;
using PlanetarySystemTool;
using UnityEngine;

public class StarSystemCamera : MonoBehaviour
{
    public enum CameraState {stationary,follow,look}

    public CameraState cameraState;
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
        switch (cameraState)
        {
            case CameraState.stationary:
                transform.LookAt(system.star);
                break;
            case CameraState.follow:
                break;
            case CameraState.look:
                break;
        }
    }
}
