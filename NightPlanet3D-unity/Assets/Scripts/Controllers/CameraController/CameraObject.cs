using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObject : CameraBase
{
    private Dictionary<GameObject, Vector3> targetDict = new Dictionary<GameObject, Vector3>();
    private Vector3 cam2target;//cam부터 target까지의 벡터

    public override void Init(Transform _cam)
    {
        base.Init(_cam);
        SetSpeed(1f, 1f);
    }

    public void SetTarget(GameObject target, float x = 3, float y = 2, float z = 3)
    {
        if (targetDict.TryGetValue(target, out cam2target) == false)//Dictionary에 저장 안 되어있으면 저장하기
        {
            cam2target = new Vector3(x, y, z);
            targetDict.Add(target, cam2target);
        }

        this.target = target.transform;//타켓 설정
        CameraController.target = CameraController.FilmType.Objects;
    }

    public void OnUpdate()
    {
        if (target == null)
            return;

        LookTarget();
    }

    private void LookTarget()
    {
        Vector3 pos = target.position + cam2target;//타겟에서 cam2target만큼 떨어진 위치
        cam.position = Vector3.Lerp(cam.position, pos, Time.deltaTime * moveSpeed);//위치 보간

        Quaternion dir = Quaternion.LookRotation(target.position - cam.position);//캠위치부터 target까지의 거리
        cam.rotation = Quaternion.Slerp(cam.rotation, dir, Time.deltaTime * lookSpeed);//회전 보간
    }

    public override void Clear()
    {
        base.Clear();
        targetDict.Clear();
    }

}
