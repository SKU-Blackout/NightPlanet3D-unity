using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation
{

    private Animator ani;
    private PlayerState.State before = PlayerState.State.UnKnown;//이전의 상태값
    public void Init(Animator _ani)
    {
        ani = _ani;
    }
    public void OnAnimation(PlayerState.State state)
    {
        if (before == state)//애니메이션 작동중에 다시 실행을 방지
            return;

        switch(state)
        {
            case PlayerState.State.Idle:
                ani.Play("Idle");
                break;

            case PlayerState.State.Move:
                ani.Play("Walk Forward");
                break;

            default:
                break;
        }
    }

    public void SetCarryAni(bool active)//나중에 뒤로 걷게 하고 싶으면 역재생 애니메이션 클립을 따로 만들어서 재생시키자, 지금은 바쁘니 스킵
    {
        if (active)
        {
            ani.Play("Push");
            ani.speed = 0.7f;
        }
        else
        {
            ani.speed = 1;
            ani.Play("Unknown");
        }
            
    }
}
