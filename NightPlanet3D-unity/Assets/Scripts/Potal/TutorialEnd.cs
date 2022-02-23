using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnd : PotalBase
{
    public override void Next()
    {
        GameObject ui = GameManager.Resource.Instantiate("UI/Scene/TutorialPotalUI");
        //GameManager.Input.Clear();
    }
}
