using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    AudioClip _audio;

    [SerializeField]
    public Image myGetItemDisPlay;

    [SerializeField]
    private QueriController myPlayer;

    [SerializeField]
    private Transform myGetItemFrame;

    [SerializeField]
    private GameObject myGetItemImage;

    public Image[] myItemImage;

    public int myItemCount = default;

    private GameObject _getItem;

    [SerializeField]
    private GameObject myQuery;

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
                //クリックしたオブジェクトにItemDetailスクリプトがアタッチされていたら起動
                if(_hit.collider.TryGetComponent(out ItemDetail _itemDetail))
                {
                    AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);

                    //FPS時のアイテム取得
                    if (_itemDetail.ItemType == ItemType.sprite)
                    {
                        myItemImage[myItemCount].sprite = _itemDetail.itemImage;
                        myItemCount++;
                        myGetItemImage.SetActive(true);
                        myGetItemDisPlay.sprite = _itemDetail.itemImage;
                    }
                    //TPS時のアイテム取得
                    if (_itemDetail.ItemType == ItemType.obj)
                    {
                        myPlayer.GetItemMotion();
                        StartCoroutine(GetItemPosition());

                        _getItem = Instantiate(_itemDetail.gameObject,myGetItemFrame);
                        myItemImage[myItemCount].sprite = _itemDetail.itemImage;
                        myItemCount++;
                    }

                    _itemDetail.txtMessage.text = _itemDetail.ItemName.ToString()+"を手に入れた。";
                    Destroy(_hit.collider.gameObject);
                }
            }
        }
        
    }
    private IEnumerator GetItemPosition()
    {
        yield return new WaitForSeconds(1);
        _getItem.transform.localPosition = Vector3.zero;
        _getItem.transform.DORotate(new Vector3(0, -360, 0), 8f);
        _getItem.transform.localScale=new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void GetItemImageFalse()
    {
        myGetItemImage.SetActive(false);
        myGetItemDisPlay.sprite = null;
        Destroy(_getItem.gameObject);
        myPlayer.GetItemMotionEnd();
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
