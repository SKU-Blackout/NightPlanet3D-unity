using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Fabric : ItemBase
{
    public override void Init()
    {
        id = Define.ItemID.fabric;
        isUsed = false;
        itemName = "마른 천";
        description = "마른 천이다.\n불에 붙기 쉬워보인다.\n무언가에 감싸서 불을 붙이자";
        path = "Spell Icons/Spell Icon Speed";
    }
}
