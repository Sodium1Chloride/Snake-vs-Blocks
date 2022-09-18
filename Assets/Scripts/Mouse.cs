using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float CurrentMouseXPosition;
    public LayerMask Mask;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo = new();
        bool hitnow = Physics.Raycast(ray, out hitInfo, Mathf.Infinity, Mask);
        if (hitnow)
        {
            CurrentMouseXPosition = Mathf.Clamp(hitInfo.point.x, -9, 9);
        }
    }
}
