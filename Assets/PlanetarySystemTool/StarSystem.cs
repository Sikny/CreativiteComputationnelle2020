﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetarySystemTool {
    public class StarSystem : MonoBehaviour {
        public Material lineRendererMaterial;
        public Transform star;

        public List<SystemPlanet> planetsInfo = new List<SystemPlanet>();

        public float timeSpeed = 1;

        private void Awake() {
            for (int i = planetsInfo.Count - 1; i >= 0; --i) {
                planetsInfo[i].Init(lineRendererMaterial, transform);
            }
        }

        private float _currentTime;
        private void Update() {
            float time = Time.deltaTime * timeSpeed;
            _currentTime += time;
            for (int i = planetsInfo.Count - 1; i >= 0; --i) {
                var planetInfo = planetsInfo[i];

                //planetInfo.planet.position = planetInfo.planetOrbit * new Vector3(Mathf.Cos(_currentTime * planetInfo.revolutionSpeed),0, Mathf.Sin(_currentTime * planetInfo.revolutionSpeed)).normalized;
                //planetInfo.planet.position = (planetInfo.planet.position - star.position).normalized * planetInfo.planetOrbit;
                planetInfo.planet.RotateAround(star.position, planetInfo.revolutionAxis, planetInfo.revolutionSpeed * time);
                planetInfo.planet.Rotate(planetInfo.planet.up, planetInfo.rotationSpeed * time);
                planetInfo.Update(time);
                
                planetInfo.DrawCircle();
            }
        }
    }
}
