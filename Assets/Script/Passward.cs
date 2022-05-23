using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passward : MonoBehaviour
{
    [SerializeField]
    int[] _correctNumbers = default;

    [SerializeField]
    PasswardButton[] _passwardButtons = default;

    private void Update()
    {
        CheckClear();
    }

    public void CheckClear()
    {
        if (IsClear() == true)
        {
            Debug.Log("クリア");
            for (int i = 0; i < _correctNumbers.Length; i++) ;
              
        }
    }

    bool IsClear()
    {
        for(int i = 0; i < _correctNumbers.Length; i++)
        {
            if(_passwardButtons[i].number != _correctNumbers[i])
            {
                return false;
            }
        }
        return true;
    }
}
