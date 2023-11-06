using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    [SerializeField] ParticleSystem lostEfect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrach = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !hasCrach)
        {
            hasCrach = true;
            FindAnyObjectByType<PlayrControl>().DisableMove();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("GameOver", 1f);
            lostEfect.Play();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
