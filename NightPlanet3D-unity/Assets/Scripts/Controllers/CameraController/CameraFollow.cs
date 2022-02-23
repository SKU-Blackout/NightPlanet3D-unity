using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : CameraBase
{
    //private readonly Vector3 addFocus = new Vector3(0, 2f, 3f);
    //private readonly Vector3 addCamPos = new Vector3(5f, 1f, 0.5f);
    private readonly Vector3 addFocus = new Vector3(3f, 2f, 0f);
    private readonly Vector3 addCamPos = new Vector3(0.5f, 1f, -5f);

    public override void Init(Transform _cam)
    {
        base.Init(_cam);
        SetSpeed(2f, 1f);
    }

    public void OnUpdate()
    {
        if (target == null)
            return;

        LookFollow();
    }

    
    public void SetTarget(Transform _player)
    {
        this.target = _player;
        CameraController.target = CameraController.FilmType.Player_Follow;
    }

    private void LookFollow()
    {
        Vector3 dest = target.position + addFocus + addCamPos;
        cam.position = Vector3.Lerp(cam.position, dest, Time.deltaTime * moveSpeed);//위치 보간

        Quaternion dir = Quaternion.LookRotation(target.position + addFocus - cam.position);//캠위치부터 target까지의 거리
        cam.rotation = Quaternion.Slerp(cam.rotation, dir, Time.deltaTime * lookSpeed);//회전 보간
    }
    

    

    
    public override void Clear()
    {
        base.Clear();
    }
}
