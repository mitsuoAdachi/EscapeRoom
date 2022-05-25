using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueriJump : MonoBehaviour
{
    [SerializeField]
    Animator[] _animator;

    [SerializeField]
    private Button[] _buttons;

    // Start is called before the first frame update
    //void Start()
    //{
    //    for (int i = 0; i < _animator.Length; i++)
    //        _buttons[i].onClick.AddListener(() => Jump(i));
    //}
    void Start()
    {
        for (int i = 0; i < _animator.Length; i++)
        {
            int index = i;  // 一度、新しく代入して index に現在の i を保持させる
            _buttons[i].onClick.AddListener(() => Jump(index));　　// index を引数に指定することで、保持している i の値を利用して動く
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Jump(int index)
    {
            _animator[index].SetTrigger("jump");
    }
}
