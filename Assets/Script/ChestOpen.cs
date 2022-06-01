using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField]
    private Animator myChestUpper;

    [SerializeField]
    private ParticleSystem _particle1, _particle2;

    [SerializeField]
    private GameObject myKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            myChestUpper.SetTrigger("open");
            _particle1.Play();
            _particle2.Play();
            StartCoroutine(ActiveKey());
        }
    }
    private IEnumerator ActiveKey()
    {
        yield return new WaitForSeconds(2);
        myKey.SetActive(true);
    }
}
