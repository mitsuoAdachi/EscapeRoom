using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムの名前と種類
/// </summary>
public enum ItemName
{
    アルファベットのT,
    アルファベットのF,
    出口の鍵,

}
public enum ItemType
{
    sprite,
    obj
}
public class ItemDetail : MonoBehaviour
{
    [SerializeField]
    public Text txtMessage;

    [SerializeField]
    private ItemName itemName;

    public ItemName ItemName { get => itemName; }

    [SerializeField]
    private ItemType itemType;

    public ItemType ItemType { get => itemType; }

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