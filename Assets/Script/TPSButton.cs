using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TPSButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _textT;

    [SerializeField]
    private ItemHolder _itemHolder;

    [SerializeField]
    AudioClip _audio;

    [SerializeField]
    private UseItem myUseItem;

    public bool _TPSMode = false;

    //壁の文字をPS⇨TPSに変える
    public void TPSChange()
    {
        if (myUseItem.activeItem_T==true)
        {
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
            _textT.SetActive(true);
            _itemHolder.myStockItemImage[_itemHolder.myItemCount - 1].sprite = null;
            //_itemHolder.myItemImage[_itemHolder.myItemCount-1].sprite = null;
            _itemHolder.myItemCount--;
            _TPSMode = true;
            
        }
    }
}
