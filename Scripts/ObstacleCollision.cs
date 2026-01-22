using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody carRb;
    private PlayerController playerController;
    private AudioSource audioSource;
    public AudioClip crashSound;
    // private GameObject musicManager;
    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Enter collision");
        if (collision.collider.name != "Road" && collision.collider.name != "Checkpoint" && collision.collider.name != "Laser")
        {
            Vector3 relativePosition = collision.GetContact(0).point - transform.position;
            relativePosition.y = 0; // 忽略垂直分量
            relativePosition.Normalize();
            // Debug.Log(Vector3.Dot(collision.relativeVelocity, relativePosition));
            float impactForce = Mathf.Abs(Vector3.Dot(collision.relativeVelocity, relativePosition)) * carRb.mass;
            // Debug.Log("Impact Force: " + impactForce);
            if (impactForce > 15000f){
                // Debug.Log("Collided with: " + collision.collider.name);
                {
                    if (playerController != null) playerController.gameOver = true;
                }
            }
            if(!audioSource.isPlaying) audioSource.Play();
            // musicManager.GetComponentAtIndex<AudioSource>(1).Play();
        }
    }
    // void OncollisonStay(Collision collision)
    // {
    //     // Debug.Log("Stay collision");
    //     if (collision.collider.name != "Road" && collision.collider.name != "Checkpoint" && collision.collider.name != "Laser")
    //     {
    //     }
    // }
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        // musicManager = GameObject.Find("MusicManager");
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = crashSound;
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
