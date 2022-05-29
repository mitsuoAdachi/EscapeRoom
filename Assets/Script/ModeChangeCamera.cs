using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ModeChangeCamera : MonoBehaviour
{
    CinemachineTrackedDolly _dolly1, _dolly2;

    [SerializeField]
    CinemachineVirtualCamera _dollyCam1,_dollyCam2;

    [SerializeField]
    private TPSButton _tpsButton;

    [SerializeField]
    private float _dolly1Speed = 1f;
    [SerializeField]
    private float _dolly2Speed = 0.1f;


    [SerializeField]
    private QueriJump _queriChan;

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _passivePlayer;

    [SerializeField]
    private  GameObject[] _playBGM;

    // Start is called before the first frame update
    void Start()
    {
        _dolly1 = _dollyCam1.GetCinemachineComponent<CinemachineTrackedDolly>();
        _dolly2 = _dollyCam2.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_tpsButton._TPSMode == true)
        {
            StartCoroutine(Dolly1Start());
            StartCoroutine(AudioStart());
            _playBGM[0].SetActive(false);
        }
    }
    private IEnumerator Dolly1Start()
    {
        yield return new WaitForSeconds(2);
        _dollyCam1.gameObject.SetActive(true);
        _dolly1.m_PathPosition += _dolly1Speed * Time.deltaTime;
        _playBGM[2].SetActive(true);

        yield return new WaitForSeconds(1.5f);
        _dollyCam2.gameObject.SetActive(true);
        _dolly2.m_PathPosition += _dolly2Speed * Time.deltaTime;

        yield return new WaitForSeconds(4);
        _queriChan._animator[6].SetTrigger("pose");
        _playBGM[1].SetActive(true);

        yield return new WaitForSeconds(5);
        _passivePlayer.SetActive(false);
        _player.SetActive(true);
    }
    private IEnumerator AudioStart()
    {
        yield return new WaitForSeconds(3.5f);
        _playBGM[3].SetActive(true);

        yield return new WaitForSeconds(4);
        _playBGM[4].SetActive(true);


    }
}
