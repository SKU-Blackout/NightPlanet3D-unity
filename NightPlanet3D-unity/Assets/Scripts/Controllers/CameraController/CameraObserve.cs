using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObserve : CameraBase
{
    private Vector3 observePos;
    public override void Init(Transform _cam)
    {
        base.Init(_cam);
        SetSpeed(1f, 1f);
    }

    public void OnUpdate()
    {
        if (target == null)
            return;

        LookObserve();
    }

    
    public void SetTarget(Transform _player, Vector3 camPos)
    {
        target = _player;
        observePos = camPos;
        CameraController.target = CameraController.FilmType.Player_Observe;
    }

    private void LookObserve()
    {
        cam.position = Vector3.Lerp(cam.position, observePos, Time.deltaTime * moveSpeed);//위치 보간

        Quaternion dir = Quaternion.LookRotation(target.position + Vector3.up - cam.position);//캠위치부터 target까지의 거리
        cam.rotation = Quaternion.Slerp(cam.rotation, dir, Time.deltaTime * lookSpeed);//회전 보간
    }
    

    public override void Clear()
    {
        base.Clear();
    }
}
