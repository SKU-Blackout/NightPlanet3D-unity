using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBoxTrigger : TriggerBase
{

    protected override void Init()
    {
        isUsed = false;
    }

    public override void OnTrigger(Transform shooter)
    {
        Vector3 pos = new Vector3(0, 5f, transform.position.z + 1.5f);
        Rigidbody cube = GameManager.Carry.Instantiate("DropBox");
        if(cube != null)
            cube.transform.position = pos;
    }
}
