using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private GameObject _startCam,_titleCanvas,_itemCanvas,_queriChans;

    [SerializeField]
    private AudioClip _audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStartButton()
    {
        StartCoroutine(GameStart1());
        AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
    }
    private IEnumerator GameStart1()
    {
        yield return new WaitForSeconds(3);
        _startCam.SetActive(false);
        _titleCanvas.SetActive(false);
        _itemCanvas.SetActive(true);

        yield return new WaitForSeconds(2);
        var _qPos = _queriChans.transform.position;
        _queriChans.transform.DOMove(new Vector3(_qPos.x, 0.85f, _qPos.z), 1f);


    }
}
