using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TButton : MonoBehaviour
{
    public bool _activeItem = false;

    [SerializeField]
    private GameObject _selectItem;

    public void ChangeBool()
    {
        _activeItem = !_activeItem;
    }

    void Update()
    {
        if (_activeItem)
        {
            _selectItem.SetActive(true);
        }
        else
        {
            _selectItem.SetActive(false);
        }
    }
}
