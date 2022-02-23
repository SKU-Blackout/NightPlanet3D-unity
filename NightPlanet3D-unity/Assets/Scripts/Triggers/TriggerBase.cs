using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerBase : MonoBehaviour
{
    protected bool isUsed;

    protected abstract void Init();
    public abstract void OnTrigger(Transform shooter);

    private void Start()
    {
        Init();
    }
}
