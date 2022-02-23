using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemBase : MonoBehaviour
{
    //public static Transform cam;
    public Define.ItemID id;
    public bool isUsed;
    public string itemName;
    public string description;
    public string path;
    void Start()
    {
        Init();
    }

    public abstract void Init();//아이템 ID 입력
}
