using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _zoomCam;


    public void SwitchCenterCam()
    {
        for (int i = 0; i < _zoomCam.Length; i++)
        _zoomCam[i].SetActive(false);
    }

    public void SwitchNumberCam()
    {
        _zoomCam[0].SetActive(true);
    }

    public void SwitchQuerisCam()
    {
        _zoomCam[1].SetActive(true);
    }

    public void SwitchMazeCam()
    {
        _zoomCam[2].SetActive(true);
    }


}
