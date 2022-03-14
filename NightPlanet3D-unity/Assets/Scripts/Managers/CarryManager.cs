using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryManager : InteractionBase<Rigidbody>
{
    private readonly int maxCount = 20;
    private Transform box = null;

    private void Init()
    {
        if (box == null)
            box = new GameObject { name = "Carrier" }.transform;
    }

    public override Rigidbody Instantiate(string path)
    {
        Init();
        if (idx > maxCount)
            return null;

        Rigidbody rb = base.Instantiate(path);
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        rb.drag = 1f;
        rb.transform.SetParent(box);
        return rb;
    }

    public void PushAllCarry()
    {
        Init();
        FallBoxTrigger[] objs = UnityEngine.GameObject.FindObjectsOfType<FallBoxTrigger>();
        foreach (FallBoxTrigger obj in objs)
        {
            Rigidbody rb = obj.gameObject.GetOrAddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
            rb.drag = 1f;
            rb.transform.SetParent(box);
            obj.name += idx++;
            objDict.Add(obj.name, rb);
        }
    }

    public override void Clear()
    {
        base.Clear();
        GameManager.Resource.Destroy(box.gameObject);
        box = null;
    }
}
