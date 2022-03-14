using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFPS
{
    private Transform target;
    private Transform cam; 

    public void Init(Transform _cam)
    {
        this.cam = _cam;
    }

    public void OnUpdate()
    {
        cam.position = target.position + target.forward * 0.2f + Vector3.up;
        cam.rotation = target.rotation;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        CameraController.target = CameraController.FilmType.FPS;
    }

}
