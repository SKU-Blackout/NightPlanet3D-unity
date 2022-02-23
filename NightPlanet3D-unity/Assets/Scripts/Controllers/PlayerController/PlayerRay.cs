using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay
{
    private enum rayTarget
    {
        Trigger = 8,
        Item = 9,
        Carry = 10,
    }

    public int mask { get; set; } = (1 << 8) | (1 << 9) | (1<<10);//Trigger와 Item레이어마스크

    private Transform _transform;//player Transform

    public PlayerCarry carry = new PlayerCarry();
    public void Init(Transform player)
    {
        this._transform = player;
    }

    public void RayControll()
    {
        if (GameManager.Input.shiftDown == false)
            return;

        RaycastHit hit;
        float[] heightLevel = new float[3] { 1f, 1.5f, 0.5f };        
        foreach (float height in heightLevel)
        {
            Vector3 pos = _transform.position + Vector3.up * height;
            if (Physics.Raycast(pos, _transform.forward, out hit, 1f, mask))//Ray가 9 or 10 Layer에 닿았으면 true리턴
            {
                Debug.DrawRay(pos, _transform.forward, Color.red,0.5f);
                ActionRay(hit.collider.gameObject);
                break;
            }
        }
    }

    private void ActionRay(GameObject target)
    {
        switch(target.layer)
        {
            case (int)rayTarget.Trigger:
                GameManager.Trigger.OnTrigger(target.name, _transform);
                break;
            case (int)rayTarget.Item:
                GameManager.Item.Eat(target.name);
                break;
            case (int)rayTarget.Carry:
                carry.SetCarryObj(target.name);
                break;
            default:
                Debug.Log("상호작용이 등록되어있지 않음");
                break;
        }
    }

}
