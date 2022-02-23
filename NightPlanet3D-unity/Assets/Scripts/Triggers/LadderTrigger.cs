using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : TriggerBase
{
    private Transform lift;
    public Vector3 originPos;
    public float untilHeight;
    private PlayerMovement.MoveStyle before;
    private readonly float moveSpeed = 3f;
    private Transform player;

    protected override void Init()
    {
        lift = new GameObject { name = "Lift" }.transform;
        lift.gameObject.AddComponent<BoxCollider>();
        lift.SetParent(transform);
        lift.position = originPos;
    }

    public override void OnTrigger(Transform shooter)
    {
        if (isUsed)
            return;

        lift.position = originPos;
        isUsed = true;
        //player = shooter;
        before = PlayerMovement.style;
        PlayerMovement.style = PlayerMovement.MoveStyle.UnKnown;

        Debug.Log("Lift가 내려갈때 문제점 + Lift를 이용하지 말고 Player를 직접 움직일지 고민중...");
    }
    

    private void Update()
    {
        if (isUsed == false)
            return;

        if (lift.position.y > untilHeight)
        {
            PlayerMovement.style = before;
            lift.position = originPos;
            isUsed = false;
            return;
        }

        lift.Translate(0f, Time.deltaTime * GameManager.Input.inputZ * moveSpeed, 0f);

        //if(player.position.y > untilHeight)
        //{
        //    PlayerMovement.style = before;
        //    isUsed = false;
        //    player = null;
        //    return;
        //}

        //player.Translate(0f, Time.deltaTime * GameManager.Input.inputZ * moveSpeed, 0f);
    }

    


#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawCube(new Vector3(originPos.x,untilHeight + 0.5f, originPos.z), new Vector3(5f, 0.1f, 5f));
    }

    

#endif
}
