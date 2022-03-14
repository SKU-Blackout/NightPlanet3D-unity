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
        PlayerMovement.style = camElement.moveStyle;
        
        if(camElement.camType == CameraController.FilmType.Player_Follow)
            GameManager.Camera.cam.camFollow.SetTarget(transform);
        else if(camElement.camType == CameraController.FilmType.Player_Observe)
            GameManager.Camera.cam.camObserve.SetTarget(transform, camElement.camPos);
        else if(camElement.camType == CameraController.FilmType.FPS)
            GameManager.Camera.cam.camFPS.SetTarget(transform);

        other.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.layer == 11)
        //    PlayerMovement.style = PlayerMovement.MoveStyle.Horizontal;
    }

    private bool LayerCheck(Collider other)//return true면 TriggerEnter에서 다음 코드 생략
    {
        switch(other.gameObject.layer)
        {
            case 11:
                //PlayerMovement.style = PlayerMovement.MoveStyle.Rev_16;
                return false;

            case 12:
                other.GetComponent<PotalBase>().Next();
                return true;

            default:
                return false;
        }
    }
}
