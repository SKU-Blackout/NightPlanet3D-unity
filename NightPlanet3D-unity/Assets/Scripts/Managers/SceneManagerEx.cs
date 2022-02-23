using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }//이 객체를 통해 현재 씬스크립트에 접근(CurrentScene as 현재씬)
    //Find계열 함수지만 씬 시작할때와 넘어갈때만 사용하기 때문에 부담없음

    public void LoadScene(Define.Scene type)//다른 씬으로 넘기는 함수(인자는 Define스크립트의 enum값)
    {
        GameManager.Clear();//씬이 넘어가기전 초기화

        SceneManager.LoadScene(GetSceneName(type));//다음 씬 호출
    }

    private string GetSceneName(Define.Scene type)//enum -> string
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }


}
