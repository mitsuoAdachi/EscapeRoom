using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UseItem : MonoBehaviour
{
    public bool activeItem_T = false;

    void Update()
    {
        //EventSystemで選択したUIの情報を取得
        var selectItem = EventSystem.current.currentSelectedGameObject;
        Debug.Log(selectItem);
        if (selectItem.TryGetComponent(out Image _itemImage))
        {
            //選択したUIのスプライトの名前がcooltext_Tであれば
            if (_itemImage.sprite.name == "cooltext_T")
            {
                activeItem_T = true;
            }
            else
            {
                activeItem_T = false;
            }

            //選択したUIのスプライトの名前がcooltext_Tでなければ
            //if (_itemImage.sprite.name != "cooltext_T")
            //{
            //    activeItem_T = false;
            //}
            //else
            //{
            //    activeItem_T = true;
            //}

            //if (_itemImage.sprite == null)
            //{
            //    activeItem_T = false;
            //}
        }
    }
}
