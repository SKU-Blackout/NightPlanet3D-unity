using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<string, Test> TestDict { get; private set; } = new Dictionary<string, Test>();

    public void Init()//GameManager에서 게임시작시 발동될 함수
    {
        TestDict = LoadJson<TestData, string, Test>("Test").MakeDict();//Loader클래스파일 -> Dictoinary형태
    }

    //리턴값 : Loader제네릭, where : ILoader인터페이스를 가지고 있어야함
    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = GameManager.Resource.Load<TextAsset>($"Data/{path}");//Json의 텍스트형태
        return JsonUtility.FromJson<Loader>(textAsset.text);//json파일 -> json text파일 -> list형태 -> Loader클래스 파일
        //JsonUtility.FromJson<클래스A>(json text파일)
            //파싱하기 위해서는 클래스A에는, json의 파일에서 가장 상위노드의 명칭과 똑같은 list가 존재해야 한다
            //그 후 return은 클래스A로 준다.
    }
}
