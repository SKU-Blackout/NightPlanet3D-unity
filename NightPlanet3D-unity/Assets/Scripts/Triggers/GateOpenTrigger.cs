using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenTrigger : TriggerBase
{
    private Animation ani;
    protected override void Init()
    {
        isUsed = false;
        ani = transform.parent.GetComponentInChildren<Animation>();
    }

    public override void OnTrigger(Transform shooter)
    {
        if (isUsed)
            return;

        ani.Play();
        isUsed = true;
    }
}
