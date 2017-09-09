using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Fuzzy.Orchestrator
{
    public class LevelInputSettings : MonoBehaviour
    {
        public string PLAYER = "Player";
        public string HORIZONTAL_AXIS = "Horizontal";
        public string VERTICAL_AXIS = "Vertical";

        private static LevelInputSettings _instance;

        public static LevelInputSettings instance
        {
            get { return _instance; }
        }

        public void Awake()
        {
            _instance = this;
        }
    }
}
