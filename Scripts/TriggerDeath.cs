using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    private PlayerController playerController; // 玩家控制器引用
    private AudioSource audioSource;
	// Start is called before the first frame update
	void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Collision detected with: " + other.name);
		if(other.CompareTag("Player"))
        {
            Debug.Log("Player has hit the laser.");
            if(!audioSource.isPlaying) audioSource.Play();
            if (playerController != null)
            {
                playerController.gameOver = true;
            }
        }
	}
	void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
