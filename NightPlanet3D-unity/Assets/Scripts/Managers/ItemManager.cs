using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : InteractionBase<ItemBase>
{
    private int[] itemArr = new int[(int)Define.ItemID.Count];

    public void Eat(string name)
    {
        ItemBase item = Get(name);
        if (item.isUsed)
            return;

        ++itemArr[(int)item.id];
        Debug.Log(name + "획득 | 갯수 : " + itemArr[(int)item.id]);

        item.isUsed = true;
        ShowItemUI(item.itemName, item.description, item.path);
        GameManager.Resource.Destroy(item.gameObject);
    }

    private UI_GetItem item;
    private void ShowItemUI(string itemName, string description, string spritePath)
    {
        if (item == null)
            item = GameManager.UI.ShowSceneUI<UI_GetItem>("ItemGet");

        item.SetImage(itemName, description, "Images/Icons Package/" + spritePath);
    }


    public void Use<T>(Define.ItemID id) where T:ItemBase
    {
        //int count;
        //if (itemDict.TryGetValue(id, out count) == false)
        //    return;

        //if (count < 1)
        //    return;

        //--count;
    }

    public override void Clear()
    {
        base.Clear();
        item.Clear();
        item = null;
        //itemArr = null;   -> 아이템들은 씬이 넘어가도 갯수가 유지되어야 하기 때문에 초기화 안한다.
        //부모 Clear를 통해서 Dictionary만 정리해줄것
    }
}
