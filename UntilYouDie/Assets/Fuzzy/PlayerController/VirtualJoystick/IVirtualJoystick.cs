using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Fuzzy.PlayerController
{
    public interface IVirtualJoystick : IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        /// <summary>
        /// Contains the (X, Y) Coordinates of the Input being sent to the character, with the center of the virtual joystick used as (0,0,0).
        /// </summary>
        Vector3 InputDirection { get; set; }

        /// <summary>
        /// The Polar Coordinates of (X, Y) implemented.
        /// </summary>
        float AngleDirection { get; }

        /// <summary>
        /// The Vertical Axis Float Value.
        /// </summary>
        float Vertical();

        /// <summary>
        /// The Horizontal Axis Float Value.
        /// </summary>
        float Horizontal();
    }
}