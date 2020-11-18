using System;
using UnityEngine;

namespace PlanetarySystemTool {
    [Serializable]
    public class SystemPlanet {
        public float planetOrbit;
        public float rotationSpeed;
        public float revolutionSpeed;
        
        public Transform planet;
    }
}
