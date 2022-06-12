using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの判別
/// </summary>
public enum StockItemIdentity
{
    obj_T,
    obj_F,
    key
}

public class StockItemStatus : MonoBehaviour
{
    [SerializeField]
    private StockItemIdentity stockItemIdentity;
    public StockItemIdentity StockItemIdentity { get => stockItemIdentity; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
