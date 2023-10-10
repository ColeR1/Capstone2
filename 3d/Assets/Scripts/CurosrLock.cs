using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CurosrLock : MonoBehaviour
{
    private void Update()
    {
        if(!ThirdPersonController.dialouge)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
