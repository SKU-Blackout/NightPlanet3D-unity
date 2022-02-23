using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarry
{
    private Transform player;
    private Rigidbody targetRigid = null;
    private Transform target = null;
    private Vector3 dir;
    private PlayerAnimation playerAni;
    private PlayerMovement playerMove;

    private float originMoveSpeed;
    private float originRotateSpeed;

    public void Init(Transform _player, PlayerAnimation _playerAni, PlayerMovement _playerMove)
    {
        this.player = _player;
        this.playerAni = _playerAni;
        this.playerMove = _playerMove;
    }

    public void SetCarryObj(string targetName)
    {
        playerAni.SetCarryAni(true);

        originMoveSpeed = playerMove.moveSpeed;
        originRotateSpeed = playerMove.rotateSpeed;
        playerMove.moveSpeed = 2f;
        playerMove.rotateSpeed = 0f;

        targetRigid = GameManager.Carry.Get(targetName);
        targetRigid.isKinematic = true;
        target = targetRigid.transform;

        dir = Vector3.Normalize(new Vector3(
            target.position.x - player.position.x,
            0,
            target.position.z - player.position.z
        ));
    }

    public void OnUpdate()
    {
        if (target == null)
            return;

        Vector3 dest = player.position + dir * 0.8f + Vector3.up;
        //target.position = Vector3.Lerp(target.position, dest, 5.0f * Time.deltaTime);
        target.position = dest;

        if (GameManager.Input.shiftUp)
        {
            targetRigid.isKinematic = false;
            targetRigid = null;
            target = null;

            playerAni.SetCarryAni(false);
            playerMove.moveSpeed = originMoveSpeed;
            playerMove.rotateSpeed = originRotateSpeed;
            return;
        }
    }
    
}
