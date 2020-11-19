using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetarySystemTool
{
    public class StarSystemUI : MonoBehaviour
    {
        public StarSystem system;
        public Text dateText;
        public Text speedText;
        public string speedUnit;

        private DateTime simulatedDate;
        public void Start()
        {
            simulatedDate = System.DateTime.Now;
        }

        public void Update()
        {
            speedText.text = system.timeSpeed + speedUnit;
            simulatedDate = simulatedDate.AddSeconds( 24 * 3600 * Time.deltaTime * system.timeSpeed);
            dateText.text = simulatedDate.ToString("dd MMM yyyy HH:mm:ss");
        }
    }
}
