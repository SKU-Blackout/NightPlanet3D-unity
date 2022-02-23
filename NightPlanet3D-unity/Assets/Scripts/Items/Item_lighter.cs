using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_lighter : ItemBase
{
    public override void Init()
    {
        id = Define.ItemID.lighter;
        isUsed = false;
        itemName = "라이터";
        description = "싸구려 라이터\n가스가 얼마 남지 않았다\n아마 한번밖에 사용할수 없어 보인다.";
        path = "Spell Icons/Spell Icon Fire Explosion";
    }

}
