using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Fuzzy.PlayerController
{
    public interface IVirtualJoystick : IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        Vector3 InputDirection { get; set; }

        float Vertical();

        float Horizontal();
    }
}