using System.Collections.Generic;
using UnityEngine;

namespace PlanetarySystemTool {
    public class StarSystem : MonoBehaviour {
        public Transform star;

        public List<SystemPlanet> planetsInfo = new List<SystemPlanet>();

        public float timeSpeed = 1;

        private void Update() {
            for (int i = planetsInfo.Count - 1; i >= 0; --i) {
                var planetInfo = planetsInfo[i];
                planetInfo.planet.RotateAround(star.position, star.up, Time.deltaTime * planetInfo.revolutionSpeed * timeSpeed);
                planetInfo.planet.Rotate(planetInfo.planet.up, Time.deltaTime * planetInfo.rotationSpeed * timeSpeed);
            }
        }
    }
}
