using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMoving
{
    private Transform rope;
    private BoxCollider boxCollider;
    private Transform endPos;
    private Transform player;
    private PlayerMovement.MoveStyle before;
    private float radius;
    public void Init(Transform rope, float angle, int angleDirection, Transform endPos, float distance)
    {
        this.rope = rope;
        velocity = angle;
        radius = distance;
        rope.Rotate(0, 0, angle * angleDirection);
        boxCollider = rope.gameObject.AddComponent<BoxCollider>();
        this.endPos = endPos;
        boxCollider.center = endPos.localPosition;
    }

    public void OnTrigger(Transform player)
    {
        this.player = player;

        before = PlayerMovement.style;
        PlayerMovement.style = PlayerMovement.MoveStyle.UnKnown;
        boxCollider.enabled = false;
        PlayerMovement.GravityOn = false;

        Debug.Log("어차피 쓰는 변수도 많은데 상속하자");
        Debug.Log("상속으로 isUsed컨트롤");
    }


    private float accel = 40f;
    private float velocity;
    private int direction = 1;
    private readonly float angleCont = 0.9f;
    private readonly float power = 10f;
    private float beforeAngle = 0;
    public void OnUpdate()
    {
        float ropeAngle = rope.rotation.eulerAngles.z;
        if (ropeAngle > 180f)
            ropeAngle -= 360f;

        if ((ropeAngle > 0f && direction == 1) || (ropeAngle < 0f && direction == -1))
        {
            accel *= -1;
            direction *= -1;
            velocity *= angleCont;
        }

        velocity += accel;
        if (ropeAngle < 30f && ropeAngle > -30f)
            velocity += (power * GameManager.Input.inputX);
        
        rope.Rotate(0f, 0f, velocity * Time.deltaTime * Time.deltaTime);
        player.transform.position = endPos.position;




        float deltaAngle = Mathf.Abs(ropeAngle - beforeAngle);
        float jumpRange = Mathf.Sin(deltaAngle) * radius;
        
        if(GameManager.Input.jump)//밧줄을 놓을때
        {
            Vector3 dest;
            dest = endPos.position + (endPos.transform.right * jumpRange * -direction);
            //dest = endPos.position + (endPos.transform.right * direction * -1.5f);
            dest += Vector3.up* 0.5f;
            player.position = dest;

            PlayerMovement.style = before;
            PlayerMovement.GravityOn = true;

            //isUsed = false;
            beforeAngle = 0;
            return;
        }

        beforeAngle = ropeAngle;//이전 각의 차이로 팅겨져 나가는 거리 결정하자
        //방향도 각도에 따라서? : 0도를 기준으로 어느정도의 각도인가 or  (지금 위치 - 0도일때 벡터)만큼 더한다?
    }
}
