using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_TutorialPotalUI : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("게임종료");
            Application.Quit();
        }
            
    }
}
