using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Test//Json -> class 변형 형태, DataManager에서 이 클래스를 통해 List로 변경시켜줌(Json -> class -> list)
{
	public string name;
	public int dataA;
	public int dataB;
}

[Serializable]
public class TestData : ILoader<string, Test>
{
	public List<Test> dataList = new List<Test>();//DataManager에서 Json으로 부터 받은 데이터가 저장되어 있을 예정

	public Dictionary<string, Test> MakeDict()//List -> Dictionary
	{
		Dictionary<string, Test> dict = new Dictionary<string, Test>();
		foreach (Test data in dataList)
			dict.Add(data.name, data);
		return dict;
	}
}
