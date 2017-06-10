using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fuzzy
{
    public interface ITriggerCollider
    {
        void OnTriggerEnter(Collider collider);
        void OnTriggerStay(Collider collider);
        void OnTriggerExit(Collider collider);
    }
}