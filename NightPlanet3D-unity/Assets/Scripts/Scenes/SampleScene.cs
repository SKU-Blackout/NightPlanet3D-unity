using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : BaseScene
{
    public Dictionary<string, GameObject> goDict = new Dictionary<string, GameObject>();
    //<키가 될 자료형, 저장할 객체>
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Sample;

        //Start함수처럼 사용
        //이 씬에 머무르는 동안 사용할 오브젝트를 Dictionary에 담아놓거나 초기설정들을 한다


        UI_Sample sampleUI = GameManager.UI.ShowSceneUI<UI_Sample>("SampleUI");

        //GameObject go = GameManager.Resource.Instantiate("Cube");
        ////Destroy()
        //go.AddComponent<Poolable>();
        //GameManager.Resource.Destroy(go);
        //goDict.Add("MyKey",go);

        
    }

    public override void Clear()//오브젝트들을 삭제하는 등, 메모리 정리를 해준다
    {

    }
}
