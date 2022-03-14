//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum FilmType
    {
        Unknown,
        Player_Follow,
        Player_Observe,
        Objects,
        FPS,
    }

    public CameraObject camObject = new CameraObject();
    public CameraFollow camFollow = new CameraFollow();
    public CameraObserve camObserve = new CameraObserve();
    public CameraFPS camFPS = new CameraFPS();
    public static FilmType target = FilmType.Unknown;
    private bool isInit = false;

    public void Init()
    {
        isInit = true;
        camObject.Init(transform);
        camFollow.Init(transform);
        camObserve.Init(transform);
        camFPS.Init(transform);
    }

    private void Update()
    {
        if(isInit==false)
        {
            Debug.Log("아직 CameraController.Init()이 호출되지 않았음 ");
            return;
        }

        switch(target)
        {
            case FilmType.Player_Follow:
                camFollow.OnUpdate();
                break;

            case FilmType.Player_Observe:
                camObserve.OnUpdate();
                break;

            case FilmType.Objects:
                camObject.OnUpdate();
                break;

            case FilmType.FPS:
                camFPS.OnUpdate();
                break;

            default:
                Debug.Log("카메라의 타겟이 정해지지 않았음");
                break;
        }
        
    }

    public void Clear()
    {
        camObject.Clear();
        camFollow.Clear();
        camObserve.Clear();
        isInit = false;
        target = FilmType.Unknown;
    }
}
