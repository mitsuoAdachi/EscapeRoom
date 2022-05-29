using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    AudioClip _audio;

    [SerializeField]
    //private GameObject _getImage;
    private TextMeshProUGUI _textGetItem;

    public Image[] _item;

    public int _itemCount = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit))
            {
                //if (_hit.collider.gameObject.tag == "Item")
                if(_hit.collider.TryGetComponent(out ItemDetail _itemDetail))
                {
                    _item[_itemCount].sprite = _itemDetail.itemImage;
                    //Image _itemImage= _hit.collider.gameObject.GetComponent<Image>();
                    //_item[_itemCount].sprite = _itemImage.sprite;
                    _itemCount++;
                    //Debug.Log("hit");
                    Destroy(_hit.collider.gameObject);
                    //_getImage.SetActive(true);
                    _textGetItem.transform.parent.gameObject.SetActive(true);
                    _textGetItem.text = _itemDetail.ItemName.ToString()+"を手に入れた。";
                    AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
                }
            }
        }
        
    }

    public void GetItemImageFalse()
    {
        _textGetItem.transform.parent.gameObject.SetActive(false);
    }
    //public void GetItem()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit _hit;
    //        if (Physics.Raycast(_ray, out _hit))
    //        {
    //            if (_hit.collider.gameObject.tag == "Item")
    //            {
    //                //Debug.Log("hit");
    //                Destroy(_hit.collider.gameObject);
    //                //_item[_itemCount] = _hit.collider.gameObject;
    //                _itemCount++;
    //            }
    //        }
    //    }
    //}
}
