using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEfect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finishEfect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("FinishReload", 1f);
        }
    }

    private void FinishReload()
    {
        SceneManager.LoadScene("Level1");
    }

}
