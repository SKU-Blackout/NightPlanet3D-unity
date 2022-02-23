using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (LayerCheck(other))
            return;

        CameraElement camElement = GameManager.Camera.Get(other.name);
        
        if(camElement.type == CameraController.FilmType.Player_Follow)
            GameManager.Camera.cam.camFollow.SetTarget(transform);
        else if(camElement.type == CameraController.FilmType.Player_Observe)
            GameManager.Camera.cam.camObserve.SetTarget(transform, camElement.camPos);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
            PlayerMovement.style = PlayerMovement.MoveStyle.Horizontal;
    }

    private bool LayerCheck(Collider other)//return true면 TriggerEnter에서 다음 코드 생략
    {
        switch(other.gameObject.layer)
        {
            case 11:
                PlayerMovement.style = PlayerMovement.MoveStyle.Direction16;
                return false;

            case 12:
                other.GetComponent<PotalBase>().Next();
                return true;

            default:
                return false;
        }
    }
}
