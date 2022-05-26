using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QueriController : MonoBehaviour
{
    [SerializeField]
    private float _limitSpeedX;
    [SerializeField]
    private float _limitSpeedY;
    [SerializeField]
    private float _rotSpeed;

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

        if (MoveX > 0.01f || MoveY > 0.01f)
        {
            _animator.SetFloat("running", 0.5f);
        }
        else
        {
            _animator.SetFloat("running", 0);
        }
    }
}
