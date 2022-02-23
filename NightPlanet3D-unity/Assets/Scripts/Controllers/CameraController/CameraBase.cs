using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase
{
    protected Transform cam;
    protected float moveSpeed;//카메라 이동속도
    protected float lookSpeed;//카메라 회전속도
    protected Transform target = null;
    public virtual void Init(Transform _cam)
    {
        this.cam = _cam;
    }

    public void SetSpeed(float moveSpeed, float lookSpeed)//속도조절
    {
        this.moveSpeed = Mathf.Clamp(moveSpeed, 0, 5f);
        this.lookSpeed = Mathf.Clamp(lookSpeed, 0, 5f);
    }

    public virtual void Clear()
    {
        cam = null;
        target = null;
    }
}
