using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetarySystemTool {
    [Serializable]
    public class SystemPlanet {
        public float planetOrbit;
        public float rotationSpeed;
        public Vector3 revolutionAxis;
        public float revolutionSpeed;
        
        public Transform planet;

        public List<SystemPlanet> satellites;

        [HideInInspector] public LineRenderer lineRenderer;

        public void Init(Material mat, Transform parent) {
            planet.localPosition = parent.right * planetOrbit;
            GameObject lineRendererGo = new GameObject("LineRenderer " + planet.gameObject.name);
            lineRendererGo.transform.parent = parent;
            lineRenderer = lineRendererGo.AddComponent<LineRenderer>();
            lineRenderer.loop = true;
            lineRenderer.startWidth = 1f;
            lineRenderer.endWidth = 1f;
            lineRenderer.sharedMaterial = mat;
            for (int i = satellites.Count - 1; i >= 0; --i) {
                satellites[i].Init(mat, parent);
                satellites[i].planet.position = planet.position + planet.right * satellites[i].planetOrbit;
                //satellites[i].planet.parent = planet;
            }
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

        public void Update(float time) {
            for (int i = satellites.Count - 1; i >= 0; --i) {
                var satInfo = satellites[i];
                satInfo.planet.RotateAround(planet.position, satInfo.revolutionAxis, satInfo.revolutionSpeed * time);
                satInfo.planet.Rotate(satInfo.planet.up, satInfo.rotationSpeed * time);
                satInfo.DrawCircle();
            }
        }
    }
}
