using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action keyAction = null;//옵저버패턴
    public Action userInput = null;

    public float inputX { get; private set; }
    public float inputZ { get; private set; }
    public bool jump { get; private set; }
    
    public bool shiftDown { get; private set; }
    public bool shiftUp { get; private set; }
    public void OnUpdate()//GameManager Updata안에서 작동
    {
        if(userInput != null)
            userInput.Invoke();

        if (Input.anyKey&& keyAction != null)
            keyAction.Invoke();
    }

    public void UserInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
        jump = Input.GetButtonDown("Jump");
        shiftDown = Input.GetButtonDown("Ray");
        shiftUp = Input.GetButtonUp("Ray");
    }

    public void Clear()
    {
        userInput = null;
        keyAction = null;
    }
}
