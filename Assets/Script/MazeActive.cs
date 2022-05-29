using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeActive : MonoBehaviour
{
    [SerializeField]
    private GameObject _mazeImage;

    private void OnTriggerEnter(Collider other)
    {
        _mazeImage.SetActive(true);
    }
}
