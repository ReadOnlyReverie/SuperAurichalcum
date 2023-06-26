using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public bool dead = false;

    [SerializeField] AudioSource deathSound;

    private void Update()
    {
        if (transform.position.y < -1f && !dead) //is dead false 
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        Invoke(nameof(ReLoadLevel), 1.3f);
        dead = true;
        deathSound.Play();
    }

    void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
