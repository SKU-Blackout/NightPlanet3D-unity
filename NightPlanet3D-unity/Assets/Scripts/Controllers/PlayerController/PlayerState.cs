using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public enum State
    {
        Idle,
        Move,
        UnKnown,
    }

    public State state { get; private set; } = State.Idle;

    public void OnUpdateState()
    {
        //일단은 대충함
        bool isIdle = true;

        isIdle &= (GameManager.Input.inputX==0);
        isIdle &= (GameManager.Input.inputZ == 0);
        if (isIdle && state != State.Idle)//유저 입력없고 상태가 idle이 아니면
            state = State.Idle;//idle로 변경
        else if (!isIdle && state != State.Move)//유저 입력 있고 상태가 move가 아니면
            state = State.Move;//move로 변경
    }
}
