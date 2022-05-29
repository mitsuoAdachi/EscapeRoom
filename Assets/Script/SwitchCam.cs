using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class SwitchCam : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _zoomCam;

    [SerializeField]
    private Button[] _buttons;


    private void Start()
    {
        for (int i = 0; i < _zoomCam.Length; i++)
        {
            int index = i;
            _buttons[i].onClick.AddListener(() => SwitchOtherCam(index));
            _buttons[0].onClick.AddListener(SwitchCenterCam);
        }
    }
    public void SwitchCenterCam()
    {
        for (int i = 0; i < _zoomCam.Length; i++)
        _zoomCam[i].SetActive(false);
        _zoomCam[0].SetActive(true);
    }

    public void SwitchOtherCam(int index)
    {
        _zoomCam[index].SetActive(true);
    }

}
