using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _centerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RightDirection()
    {
        _centerCam.transform.Rotate(new Vector3(0, 90, 0));
    }

    public void LeftDirection()
    {
        _centerCam.transform.Rotate(new Vector3(0, -90, 0));
    }

}
