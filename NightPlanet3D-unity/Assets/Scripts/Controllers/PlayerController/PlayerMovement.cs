using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public enum MoveStyle
    {
        UnKnown,
        Horizontal,
        Vertical,
        Direction16,
        Rev_16,
        FPS,
    }

    private Transform _transform;
    private CharacterController charCtrl;
    private float nowGravity = 0f;
    private Vector3 moveDir;
    public static MoveStyle style = MoveStyle.UnKnown;
    private readonly float jumpVelocity = 7f;
    public static bool GravityOn = true;

    public void Init(Transform player)
    {
        _transform = player;
        charCtrl = player.gameObject.AddComponent<CharacterController>();
        charCtrl.center = Vector3.up;
        charCtrl.radius = 0.25f;
    }

    public void OnUpdate()
    {
        Move();    
        Jump();
    }

    public float rotateSpeed { get; set; } = 10f;
    public float moveSpeed { get; set; } = 5f;

    private void SetMoveDirByStyle()//스타일에 따라 움직일 방향 설정
    {
        //움질일 방향설정
        switch (style)
        {
            case MoveStyle.Direction16:
                moveDir = Vector3.forward * GameManager.Input.inputZ + Vector3.right * GameManager.Input.inputX;
                moveDir = Vector3.Normalize(moveDir);
                break;
            case MoveStyle.Horizontal:
                moveDir = Vector3.right * GameManager.Input.inputX;
                break;
            case MoveStyle.FPS:
            case MoveStyle.Vertical:
                moveDir = Vector3.forward * GameManager.Input.inputZ;
                break;
            case MoveStyle.Rev_16:
                moveDir = Vector3.back * GameManager.Input.inputZ + Vector3.left * GameManager.Input.inputX;
                moveDir = Vector3.Normalize(moveDir);
                break;
            default:
                moveDir = Vector3.zero;
                break;
        }
    }

    private void Move()
    {
        if (GameManager.Input.userInput == null)
            return;

        SetMoveDirByStyle();
        nowGravity += Time.deltaTime * Physics.gravity.y * 2f;//속도 =  중력가속도 / 시간

        Vector3 velocity = Vector3.zero;
        if (style == MoveStyle.FPS)
            velocity = (_transform.forward * moveDir.z * moveSpeed) + Vector3.up * nowGravity;
        else
            velocity = moveDir * moveSpeed + Vector3.up * nowGravity;//움직일 방향 + 중력
        charCtrl.Move(velocity * Time.deltaTime);

        if (charCtrl.isGrounded || GravityOn == false)
            nowGravity = 0f;

        if (style == MoveStyle.Horizontal && _transform.position.z != 0f)
            _transform.position = new Vector3(_transform.position.x, _transform.position.y,0f);
    }

    public void Rotate()
    {
        if (style == MoveStyle.UnKnown)
            return;

        if(style == MoveStyle.FPS)
        {
            Vector3 rotateAngle = Vector3.up * GameManager.Input.inputX * 120f;
            if(rotateAngle != Vector3.zero)
                _transform.Rotate(rotateAngle * Time.deltaTime);
            return;
        }
        
        Vector3 rotateDir = Vector3.right * GameManager.Input.inputX + Vector3.forward * GameManager.Input.inputZ;
        if (rotateDir == Vector3.zero)
            return;

        if (style == MoveStyle.Rev_16)
            rotateDir *= -1;

        Quaternion lookAt = Quaternion.LookRotation(rotateDir);//vector -> Quaternion
        _transform.rotation = Quaternion.Slerp(_transform.rotation, lookAt, rotateSpeed * Time.deltaTime);//자연스럽게 회전
    }

    private void Jump()
    {
        if (charCtrl.isGrounded == false)
            return;

        if (style == MoveStyle.UnKnown)
            return;

        if (GameManager.Input.jump)
        {
            nowGravity = jumpVelocity;
            charCtrl.Move(Vector3.up * nowGravity * Time.deltaTime);//거리 = 속도 /시간
        }
    }


}
