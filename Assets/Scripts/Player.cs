using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float yVelocity = 1.5f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip dieSFX;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
            rb.velocity = Vector2.up * yVelocity;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == UnityEngine.TouchPhase.Began)
            {
                AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
                rb.velocity = Vector2.up * yVelocity;
            }
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(dieSFX, Camera.main.transform.position);
        GameManager.instance.GameOver();
    }
}
