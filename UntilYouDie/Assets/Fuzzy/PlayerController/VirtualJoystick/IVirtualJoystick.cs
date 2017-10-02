using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Fuzzy.PlayerController
{
    public interface IVirtualJoystick : IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        Vector3 InputDirection { get; set; }

        float AngleDirection { get; }

        float Vertical();

        float Horizontal();
    }
}