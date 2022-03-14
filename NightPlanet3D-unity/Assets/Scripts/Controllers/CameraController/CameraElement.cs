using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraElement : MonoBehaviour
{
    public Vector3 camPos;
        //observe일땐 월드 스페이스
        //Follow일땐 의미없음(나중에 의미있게 할지도?)
        //object일땐 관찰할 오브젝트의 로컬스페이스
    public CameraController.FilmType camType = CameraController.FilmType.Unknown;

    public PlayerMovement.MoveStyle moveStyle = PlayerMovement.MoveStyle.UnKnown;




#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (camType == CameraController.FilmType.Player_Observe)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawSphere(camPos, 0.5f);
        }
        else if (camType == CameraController.FilmType.Objects)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawSphere(transform.position, 0.5f);
            Gizmos.DrawSphere(transform.position + camPos, 0.5f);
        }



    }

#endif
}
