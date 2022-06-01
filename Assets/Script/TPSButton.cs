using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _textT;

    [SerializeField]
    private ItemHolder _itemHolder;

    [SerializeField]
    private TButton _tButton;

    [SerializeField]
    AudioClip _audio;

    public bool _TPSMode = false;

    public void TPSChange()
    {
        if (_tButton._activeItem == true)
        {
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
            _textT.SetActive(true);
            _itemHolder.myItemImage[_itemHolder.myItemCount-1].sprite = null;
            //_itemHolder.myItemImage[_itemHolder.myItemCount-1].sprite = null;
            _itemHolder.myItemCount--;
            _TPSMode = true;
        }
    }
}
