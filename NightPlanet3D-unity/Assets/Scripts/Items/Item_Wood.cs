using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Wood : ItemBase
{
    public override void Init()
    {
        id = Define.ItemID.wood;
        isUsed = false;
        itemName = "나무";
        description = "마른 나무이다,\n 무기로는 쓸수 없어 보인다.\n 마른 천을 감싸서 불을 붙이면 횃불이 될지도...";
        path = "Wide Icons/Wide Icon Staff Skill";
    }

}
