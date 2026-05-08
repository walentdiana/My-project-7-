using UnityEngine;

namespace Dziana.Input
{
    public class InputComponent : MonoBehaviour
    {
        internal static Vector2 GetMove()
        {
            return new Vector2(
                UnityEngine.Input.GetAxis("Horizontal"),
                UnityEngine.Input.GetAxis("Vertical")
            );
        }

        internal static bool BIsJump()
        {
            if (UnityEngine.Input.GetButton("Jump"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool BIsFire()
        {
            if (UnityEngine.Input.GetButton("Fire1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

