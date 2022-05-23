using System.Collections;　　　//　コルーチンを利用する際に必要になります(利用していると System ～ の文字の色が変わります)
using System.Collections.Generic;
using UnityEngine;

public class PasswardCustom : MonoBehaviour
{
    [SerializeField]
    int[] _correctNumbers = default;
    [SerializeField]
    PasswardButton[] _passwardButtons = default;
    void Start()
    {
        // パスワード入力状態の監視
        StartCoroutine(CheckClear());
    }
    /// <summary>
    /// パスワード入力状態の監視
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckClear()
    {        Debug.Log("クリア状態の監視　スタート");

        // IsClear メソッドの戻り値が false の間、ループを繰り返す。true になったらループを抜ける
        while (!IsClear())
        {
            yield return null;
        }

        Debug.Log("クリア");}
    /// <summary>
    /// 入力された番号が設定された番号とすべて一致するか判定
    /// </summary>
    /// <returns></returns>
    private bool IsClear()
    {
        // ここの一連の処理に、日本語でコメントを書いてみてください。読み解けていれば書けると思います
        // _correctNumber(正解の数値)の配列をfor文で順番に参照し_passwardButtons(実際に打ち込数値)の
        // 配列の数値と同じか調べる処理。配列の数値同士が一致していなければfalseを返し、全て一致していればtrueを返す。
        for (int i = 0; i < _correctNumbers.Length; i++)
        {
            if (_passwardButtons[i].number != _correctNumbers[i])
            {
                return false;
            }
        }
        return true;
    }
}