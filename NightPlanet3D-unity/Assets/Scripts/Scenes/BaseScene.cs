using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour//모든 씬클래스의 Base
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;//씬을 옮길때마다 Init에서 수정할것

    void Awake()
    {
        Init();
    }

    protected virtual void Init()//씬을 옮길때마다 
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)//EventSystem이 없다면 추가함
        {
            GameObject eventSystem = GameManager.Resource.Instantiate("UI/EventSystem");
            eventSystem.name = "@EventSystem";
            DontDestroyOnLoad(eventSystem);
        }
            

    }

    public abstract void Clear();
}
