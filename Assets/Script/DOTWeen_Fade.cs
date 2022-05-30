using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DOTWeen_Fade : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private float _value=1;
    [SerializeField]
    private float _duration = 2;

    void OnEnable()
    {
        _image.DOFade(_value, _duration);
    }
}
