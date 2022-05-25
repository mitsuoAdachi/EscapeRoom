using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPanel : MonoBehaviour
{
    [SerializeField]
    public Slider[] _sliders;

    [SerializeField]
    private Button[] _buttons;

    private void Start()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            int index = i;
            _buttons[i].onClick.AddListener(() => SliderPlus(index));
        }
    }
    public void SliderPlus(int index)
    {
         _sliders[index].value += 1f;
        if (_sliders[index].value > 4f)
        {
            _sliders[index].value = 0;
        }
    }
}

