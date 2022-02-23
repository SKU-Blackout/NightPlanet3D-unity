using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : InteractionBase<TriggerBase>
{
   public void OnTrigger(string name, Transform shooter)
    {
        TriggerBase trigger = Get(name);
        trigger.OnTrigger(shooter);
    }

    public override void Clear()
    {
        base.Clear();
    }
}
