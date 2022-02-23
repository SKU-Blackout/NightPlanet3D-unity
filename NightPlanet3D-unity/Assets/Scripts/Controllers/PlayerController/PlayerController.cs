using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement = new PlayerMovement();//움직임 관리
    private PlayerState playerState = new PlayerState();//캐릭터 상태관리
    //private PlayerAnimation ani = new PlayerAnimation();//캐릭터 애니메이션 관리
    private PlayerRay ray = new PlayerRay();

    void Start()
    {
        movement.Init(transform);
        //ani.Init(GetComponent<Animator>());//애니메이션 컴포넌트 전달
        ray.Init(transform);
        //ray.carry.Init(transform, ani,movement);
        gameObject.AddComponent<PlayerTrigger>();

        GameManager.Input.keyAction -= OnKeyBoard;
        GameManager.Input.keyAction += OnKeyBoard;
    }

    private void Update()
    {
        playerState.OnUpdateState();//입력에 따라 state체크
        //ani.OnAnimation(playerState.state);//state에 따라 Animation동기화
        movement.OnUpdate();
        ray.carry.OnUpdate();
    }

    private void OnKeyBoard()//InputManager안의 Update, 유저의 입력을 받을때만 실행
    {
        ray.RayControll();
        movement.Rotate();
    }

    public void Release()//소멸자, 이 객체를 없애기 전에 호출
    {
        GameManager.Input.keyAction -= OnKeyBoard;//Scene클래스에서 연결하고 있음
    }


    //#if UNITY_EDITOR

    //    private void OnDrawGizmosSelected()
    //    {
    //        //Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
    //        //Gizmos.DrawWireCube(obstacle.checkPos, obstacle.checkBox);
    //    }

    //#endif

}
