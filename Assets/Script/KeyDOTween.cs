using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyDOTween : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var tweener1 = transform.DOLocalMoveY(-3.7f, 0.5f);
        var tweener2 = transform.DORotate(new Vector3(0, -360, 0),8f);

        //DOTweenがtweenwe1から順番に起動する
        DOTween.Sequence().Append(tweener1).Append(tweener2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
