using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムの名前と種類
/// </summary>
public enum ItemName
{
    大文字のT,
    Item_1,
}
public class ItemDetail : MonoBehaviour
{
    [SerializeField]
    public Text txtMessage;

    [SerializeField]
    private ItemName itemName;

    public ItemName ItemName { get => itemName; }

    public Sprite itemImage;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}