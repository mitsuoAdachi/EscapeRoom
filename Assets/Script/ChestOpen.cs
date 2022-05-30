using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField]
    private Animator myChestUpper;

    [SerializeField]
    private ParticleSystem _particle;

    [SerializeField]
    private GameObject myKey;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player1")
        {
            myChestUpper.SetTrigger("open");
            _particle.Play();
            StartCoroutine(ActiveKey());
        }
    }
    private IEnumerator ActiveKey()
    {
        yield return new WaitForSeconds(2);
        myKey.SetActive(true);
    }
}
