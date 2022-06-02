using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QueriController : MonoBehaviour
{
    //private Vector3 _startPos, _currentPos;

    [SerializeField]
    private float _limitSpeedX;
    [SerializeField]
    private float _limitSpeedY;
    [SerializeField]
    private float _rotSpeed;

    [SerializeField]
    private GameObject myGetItemCam;

    private NavMeshAgent _agent;

    private Vector3 _latestPos;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ////タッチ関数を使用した移動処理
        //foreach (var touch in Input.touches)
        //{
        //    if (touch.position.x < 800)
        //    {
        //        int _moveFingerId;
        //        if (touch.phase == TouchPhase.Began)
        //        {
        //            _moveFingerId = touch.fingerId;
        //            //_rigid.isKinematic = false;
        //            _startPos = touch.position;
        //        }
        //        if (touch.phase == TouchPhase.Moved)
        //        {
        //            _currentPos = touch.position;
        //        }

        //        if (touch.fingerId == _moveFingerId)
        //        {
        //            var _changeVector = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        //            Vector2 _move = _currentPos - _startPos;
        //            float _moveX = Mathf.Clamp(_move.x, -_limitSpeedX, _limitSpeedX);
        //            float _moveY = Mathf.Clamp(_move.y, -_limitSpeedY, _limitSpeedY);
        //            //Debug.Log("_move distance" + _move);
        //            _move3 = new Vector3(_moveX, 0, _moveY);

        //            _agent.Move(_changeVector * _move3);
        //        }
        //        if (touch.phase == TouchPhase.Ended)
        //        {
        //            _animator.SetBool("run", false);
        //        }
        //    }
        var _horizontal = Input.GetAxis("Horizontal");
        var _vertical = Input.GetAxis("Vertical");

        float MoveX = Mathf.Clamp(_horizontal, -_limitSpeedX, _limitSpeedX);
        float MoveY = Mathf.Clamp(_vertical, -_limitSpeedY, _limitSpeedY);

        //Y軸に対する入力をカメラ奥へのベクトルに変換
        var _changeVector = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        //NavMeshで移動処理
        _agent.Move(_changeVector * new Vector3(MoveX, 0, MoveY));

        //移動方向を向く
        Vector3 _diff = transform.position - _latestPos;
        _latestPos = transform.position;

        if (_diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_diff), Time.deltaTime * _rotSpeed);
        }
        //走るアニメーション
        if (MoveX != 0 || MoveY != 0)
        {
            _animator.SetFloat("running", 0.5f);
        }
        else
        {
            _animator.SetFloat("running", 0);
        }
    }
    public void GetItemMotion()
    {
        myGetItemCam.SetActive(true);
        _animator.SetTrigger("getItem");
        StartCoroutine(StopMotion());
    }
    private IEnumerator StopMotion()
    {
        yield return new WaitForSeconds(1.7f);
        _animator.speed = 0;
    }

    public void GetItemMotionEnd()
    {
        _animator.speed += 0.5f;
        _animator.ResetTrigger("getItem");
        myGetItemCam.SetActive(false);
    }
}
