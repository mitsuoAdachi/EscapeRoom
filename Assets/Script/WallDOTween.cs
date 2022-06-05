using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallDOTween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOLocalMove(new Vector3(3, 0, 0),1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
