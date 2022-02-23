using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager
{
    private Dictionary<string, CameraElement> elementDict = new Dictionary<string, CameraElement>();//레벨디자인에 있는 CameraElement컴포넌트를 담을 Dictionary
    public List<CameraElement> objectTypeList { get; private set; } = new List<CameraElement>();//CameraElement들중 Objects타입만 따로 담을 리스트
    public CameraController cam { get; set; } = null;

    public void Init()//테스트를 위해 잠시 public으로 둠, 나중에 private할 것
    {
        if (cam != null)
            return;

        cam = Camera.main.gameObject.GetOrAddComponent<CameraController>();
        cam.Init();
    }

    public void Push(CameraElement element)//CameraElement컴포넌트를 지닌 오브젝트들을 Type에 따라 Dictionary or List로 분류
    {
        Init();
        switch(element.type)
        {
            case CameraController.FilmType.Player_Follow:
            case CameraController.FilmType.Player_Observe:
                elementDict.Add(element.name, element);//Follow와 Observe는 Dictionary행
                break;

            case CameraController.FilmType.Objects:
                objectTypeList.Add(element);//Objects타입은 List행
                break;

            default:
                Debug.Log(element.name + " 의 FilmType이 설정되어 있지 않음");
                break;
        }
    }

    public CameraElement Get(string elementName)//Object의 이름으로 Dictionary에 담긴 CameraElement컴포넌트 return
    {
        CameraElement element;
        if(elementDict.TryGetValue(elementName,out element)==false)
        {
            Debug.Log(elementName + "(은)는 등록된 적이 없음");
            return null;
        }
        return element;
    }

    public void Clear()//다음 씬으로 넘어갈때 모든것을 초기화
    {
        cam.Clear();
        cam = null;
        elementDict.Clear();//Dictionary초기화
        objectTypeList.Clear();//List초기화
    }
}
