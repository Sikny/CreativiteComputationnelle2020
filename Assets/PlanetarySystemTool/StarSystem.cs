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
                planetsInfo[i].planet.position = transform.right * planetsInfo[i].planetOrbit;
                planetsInfo[i].Init(lineRendererMaterial, transform);
            }
        }

        private void Update() {
            float time = Time.deltaTime * timeSpeed;
            for (int i = planetsInfo.Count - 1; i >= 0; --i) {
                var planetInfo = planetsInfo[i];
                
                planetInfo.planet.position = (planetInfo.planet.position - star.position).normalized * planetInfo.planetOrbit;
                planetInfo.planet.RotateAround(star.position, planetInfo.revolutionAxis, planetInfo.revolutionSpeed * time);
                planetInfo.planet.Rotate(planetInfo.planet.up, planetInfo.rotationSpeed * time);
                
                planetInfo.DrawCircle();
            }
        }
    }
}
