using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    AudioClip _audio;

    [SerializeField]
    private Image myGetItemDisplay;

    [SerializeField]
    private QueriController myPlayer;

    [SerializeField]
    private Transform myGetItemFrame;

    [SerializeField]
    private GameObject explanatoryText;

    [SerializeField]
    private GameObject myGetItemFalseButton;

    [SerializeField]
    private GameObject _moveWall;

    [SerializeField]
    private GameObject myWallMoveCam;

    public Image[] myStockItemImage;

    public int myItemCount = default;

    private ItemDetail _getItem;

    private Tweener myTweener;

    private bool myWAllMove;

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
            Debug.DrawRay(_ray.origin, _ray.direction, Color.white);
            RaycastHit _hit;
            if (Physics.Raycast(_ray, out _hit))
            {
                Debug.Log(_hit);
                //クリックしたオブジェクトにItemDetailスクリプトがアタッチされていたら起動
                if(_hit.collider.TryGetComponent(out ItemDetail _itemDetail))
                {
                    AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);

                    //FPS時のアイテム取得
                    if (_itemDetail.ItemType == ItemType.sprite)
                    {
                        myStockItemImage[myItemCount].sprite = _itemDetail.itemImage;
                        myItemCount++;
                        myGetItemDisplay.gameObject.SetActive(true);
                        myGetItemDisplay.sprite = _itemDetail.itemImage;
                    }
                    //TPS時のアイテム取得
                    if (_itemDetail.ItemType == ItemType.obj)
                    {
                        myPlayer.GetItemMotion();
                        StartCoroutine(GetItemPosition());

                        //ItemDetail型で代入し100行目でGetCompornentせずに活用する
                        _getItem = Instantiate(_itemDetail,myGetItemFrame);
                        _getItem.gameObject.GetComponent<Collider>().enabled = false;
                        myStockItemImage[myItemCount].sprite = _itemDetail.itemImage;
                        Debug.Log("アイテム獲得");
                        myItemCount++;
                    }

                    explanatoryText.SetActive(true);
                    _itemDetail.txtMessage.text = _itemDetail.ItemName.ToString()+"を手に入れた。";
                    Destroy(_hit.collider.gameObject);
                }
                if (_hit.collider.gameObject.tag == "WallMove")
                {
                    myWAllMove = true;
                }
            }
        }
        
    }
    private IEnumerator GetItemPosition()
    {
        yield return new WaitForSeconds(1);
        _getItem.transform.localPosition = Vector3.zero;
        myTweener=_getItem.transform.DORotate(new Vector3(0, -360, 0), 7f)
            .SetRelative(true)
            .SetLoops(-1);
        _getItem.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        yield return new WaitForSeconds(3);
        myGetItemFalseButton.SetActive(true);
    }

    public void GetItemImageFalse()
    {
        myGetItemDisplay.gameObject.SetActive(false);
        explanatoryText.SetActive(false);
    }

    public void GetItemMotionFalse()
    {
        myTweener.Kill();
        myPlayer.GetItemMotionEnd();
        Destroy(_getItem.gameObject);

        if (myWAllMove == true)
        {
            myWallMoveCam.SetActive(true);

            StartCoroutine(MoveWall());
        }

        myGetItemFalseButton.SetActive(false);
    }

    private IEnumerator MoveWall()
    {
        yield return new WaitForSeconds(1);
        _moveWall.transform.DOLocalMoveX(1, 1.5f);

        yield return new WaitForSeconds(2.5f);
        myWallMoveCam.SetActive(false);
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
