using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockIncreaseScore : MonoBehaviour
{
    [SerializeField] AudioClip scoreSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(scoreSFX, Camera.main.transform.position);
            Score.instance.UpdateScore();
        }
    }
}
