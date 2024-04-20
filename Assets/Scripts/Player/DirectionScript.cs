using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionScript : MonoBehaviour
{
    public Camera CameraLink;
    public float TargetInSkyDistance;

    public Transform TargetObject;

    void Update()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TargetObject.position = hit.point + 10 * CameraLink.transform.forward;
        }
        else
        {
            TargetObject.position = ray.GetPoint(TargetInSkyDistance);
        }
    }
}
