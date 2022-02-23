using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : BaseScene
{
    private List<GameObject> objList = new List<GameObject>();
    
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Tutorial;

        GameObject player = GameManager.Resource.Instantiate("Player");//플레이어 생성
        player.transform.position = new Vector3(0, 0, -15f);
        PlayerController playerCtrl = player.GetOrAddComponent<PlayerController>();//PlayerController컴포넌트 부착
        PlayerMovement.style = PlayerMovement.MoveStyle.Horizontal;//움직임 수평이동
        objList.Add(player);//리스트에 추가

        //GameObject level = GameManager.Resource.Instantiate("Tutorial_Level");//튜토리얼 맵 생성
        //objList.Add(level);//리스트에 추가

        //GameManager.Item.PushAll();//레벨디자인에 있는 아이템들 미리 Dictoinary에 보관
        //GameManager.Trigger.PushAll();//레벨디자인에 있는 트리거들 미리 Dictoinary에 보관
        

        //StartCoroutine("Co_Intro", player);//바로 아래 코루틴 시작

        GameManager.Input.userInput -= GameManager.Input.UserInput;
        GameManager.Input.userInput += GameManager.Input.UserInput;//움직임 가능

        GameManager.Camera.Init();
        GameManager.Camera.cam.camFollow.SetTarget(player.transform);//기본 카메라로 설정
    }

    private IEnumerator Co_Intro(GameObject player)
    {
        CameraElement[] elements = FindObjectsOfType<CameraElement>();
        foreach (CameraElement element in elements)
            GameManager.Camera.Push(element);//카메라 매니저의 Dictionary에 저장

        float lookingTime = 0.2f;
        foreach(CameraElement target in GameManager.Camera.objectTypeList)//CameraElement의 Objects타입에 관해서만 실행
        {
            GameManager.Camera.cam.camObject.SetTarget(target.gameObject, target.camPos.x, target.camPos.y, target.camPos.z);//카메라의 위치 조정
            yield return new WaitForSeconds(lookingTime);//대기
        }

        GameManager.Input.userInput -= GameManager.Input.UserInput;
        GameManager.Input.userInput += GameManager.Input.UserInput;//움직임 가능

        GameManager.Camera.cam.camFollow.SetTarget(player.transform);//기본 카메라로 설정
    }

    public override void Clear()
    {
        foreach(GameObject go in objList)//List에 있는 내용 삭제
            GameManager.Resource.Destroy(go);
    }
}
