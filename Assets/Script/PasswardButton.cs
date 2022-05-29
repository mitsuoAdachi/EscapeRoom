using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswardButton : MonoBehaviour
{
    [SerializeField]
    TMP_Text numberText = default;

    [SerializeField]
    AudioClip _audio;

    public int number;

    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        numberText.text = number.ToString();
    }

    public void OnClickThis()
    {
        AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
        number++;
        if (number > 9)
        {
            number = 0;
        }
        numberText.text = number.ToString();
    }
}
