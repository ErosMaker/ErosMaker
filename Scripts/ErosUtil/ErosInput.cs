using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ErosUtils
{
    public class ErosInput : MonoBehaviour
    {
        public static Collider rayCollider;

        private void Awake()
        {
            rayCollider = GetComponent<Collider>();
        }
        public static Vector3 GetMouseWorldCoord()
        {
            Vector3 pos = GetMouseWorldCoordWithZ(Input.mousePosition, Camera.main);
            pos.z = 0f;
            return pos;
        }

        public static Vector3 GetMouseWorldCoordWithZ()
        {
            return GetMouseWorldCoordWithZ(Input.mousePosition, Camera.main);
        }

        public static Vector3 GetMouseWorldCoordWithZ(Camera worldCamera)
        {
            return GetMouseWorldCoordWithZ(Input.mousePosition, worldCamera);
        }

        public static Vector3 GetMouseWorldCoordWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.WorldToScreenPoint(screenPosition);
            return worldPosition;
        }

        public static Vector3 GetMouseXZCoords(float y)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
            {
                Debug.Log(new Vector3(raycastHit.point.x, y, raycastHit.point.z).ToString());
                return new Vector3(raycastHit.point.x, y, raycastHit.point.z);
            }

            else
            {
                return new Vector3(-1, -1, -1);
            }
        }

        public static Vector3 GetMouseXYZCoords()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
            {
                Debug.Log(new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z).ToString());
                return new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);
            }

            else
            {
                return Vector3.zero;
            }
        }
    }
}
