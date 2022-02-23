using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RopeTrigger : TriggerBase
{
    [Range(0, 10)]
    public float distance;
    [Range(0, 90)]
    public float angle;
    [Range(-1,1)]
    public int angleDirection;

    private Transform endPos;
    private RopeRendering render = new RopeRendering();
    private RopeMoving move = new RopeMoving();
    
    protected override void Init()
    {
        endPos = new GameObject { name = "EndPos" }.transform;
        endPos.SetParent(transform);
        endPos.localPosition = Vector3.down * distance;

        move.Init(transform, angle, angleDirection, endPos, distance);
        render.Init(gameObject);
    }
    
    public override void OnTrigger(Transform shooter)//밧줄을 붙잡을 때
    {
        if (isUsed)
            return;

        isUsed = true;//true가 됨
        move.OnTrigger(shooter);
    }

    private void Update()
    {
        render.OnUpdate(endPos);

        if (isUsed == false)
            return;

        move.OnUpdate();
        if (GameManager.Input.jump)
            isUsed = false;
    }









#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Quaternion leftRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        Vector3 leftRay = leftRotation * Vector3.down;

        Handles.color = new Color(1f, 1f, 1f, 0.1f);
        Handles.DrawSolidArc(transform.position, Vector3.forward, leftRay, angle * 2f, distance);
    }

#endif

}
