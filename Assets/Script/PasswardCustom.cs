using System.Collections;　　　//　コルーチンを利用する際に必要になります(利用していると System ～ の文字の色が変わります)
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PasswardCustom : MonoBehaviour
{
    [SerializeField]
    private int[] _correctNumbers = default;
    [SerializeField]
    private PasswardButton[] _passwardButtons = default;

    [SerializeField]
    private int[] _sliderValues = default;
    [SerializeField]
    private Slider[] _sliderPanels;

    [SerializeField]
    private GameObject _queriChans;

    [SerializeField]
    private GameObject _queriCam;

    [SerializeField]
    private GameObject _tObject;

    [SerializeField]
    private GameObject _wallT;

    [SerializeField]
    private GameObject _TCam;

    [SerializeField]
    private GameObject _particleT;


    void Start()
    {
        // パスワード入力状態の監視
        StartCoroutine(CheckClearGimmick1());
        StartCoroutine(CheckClearGimmick2());
    }
    /// <summary>
    /// パスワード入力状態の監視
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckClearGimmick1()
    {        Debug.Log("ギミック１クリア状態の監視　スタート");

        // IsClear メソッドの戻り値が false の間、ループを繰り返す。true になったらループを抜ける
        while (!IsClearGimmick1())
        {
            yield return null;
        }

        Debug.Log("ギミック１クリア");

        StartCoroutine(QueriChansStandby());

    }
    private IEnumerator QueriChansStandby()
    {
        yield return new WaitForSeconds(1);
        _queriCam.SetActive(true);

        yield return new WaitForSeconds(2);
        var _qPos = _queriChans.transform.position;
        _queriChans.transform.DOMove(new Vector3(_qPos.x, 1.351f, _qPos.z), 1f);

        yield return new WaitForSeconds(2);
        _queriCam.SetActive(false);
    }
    /// <summary>
    /// 入力された番号が設定された番号とすべて一致するか判定
    /// </summary>
    /// <returns></returns>
    private bool IsClearGimmick1()
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

    private IEnumerator CheckClearGimmick2()
    {
        Debug.Log("ギミック２クリア状態の監視　スタート");

        while (!IsClearGimmick2())
        {
            yield return null;
        }

        Debug.Log("ギミック２クリア");

        StartCoroutine(T_Action());

    }
    private IEnumerator T_Action()
    {
        yield return new WaitForSeconds(1);
        _TCam.SetActive(true);
        yield return new WaitForSeconds(2);
        _particleT.SetActive(true);
        _wallT.SetActive(false);
        _tObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _TCam.SetActive(false);


    }

    private bool IsClearGimmick2()
    {
        for (int i = 0; i < _sliderValues.Length; i++)
        {
            if (_sliderPanels[i].value != _sliderValues[i])
            {
                return false;
            }
        }
        return true;
    }
}