using System;
using UnityEngine;

namespace PlanetarySystemTool {
    [Serializable]
    public class SystemPlanet {
        public float planetOrbit;
        public float rotationSpeed;
        public Vector3 revolutionAxis;
        public float revolutionSpeed;
        
        public Transform planet;

        [HideInInspector] public LineRenderer lineRenderer;

        public void Init(Material mat, Transform parent) {
            GameObject lineRendererGo = new GameObject("LineRenderer " + planet.gameObject.name);
            lineRendererGo.transform.parent = parent;
            lineRenderer = lineRendererGo.AddComponent<LineRenderer>();
            lineRenderer.loop = true;
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;
            lineRenderer.sharedMaterial = mat;
        }
        
        public void DrawCircle() {
            int segmentCount = 100;
            lineRenderer.positionCount = segmentCount + 1;
            float angle = 0;
            for (int i = 0; i < lineRenderer.positionCount; ++i) {
                lineRenderer.SetPosition(i, planetOrbit * new Vector3((float) Math.Cos(Mathf.Deg2Rad * angle), 0, (float) Math.Sin(Mathf.Deg2Rad * angle)));
                angle += 360f / segmentCount;
            }
        }
    }
}
