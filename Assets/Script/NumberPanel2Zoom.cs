using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPanel2Zoom : MonoBehaviour
{
    [SerializeField]
    private GameObject myNumberPanel2Cam;

    private void OnTriggerStay(Collider other)
    {
        myNumberPanel2Cam.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        myNumberPanel2Cam.SetActive(false);

    }

}
