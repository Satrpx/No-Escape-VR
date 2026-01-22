using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggercheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource checkpointAudioSource;
    private PlayerController playerController;
    private CarController carController;
    void OnTriggerEnter(Collider other)
    {
        GameObject myCheckpoint = this.gameObject;
        // Debug.Log("Collision detected with: " + other.name);
        if (other.CompareTag("Player"))
        {
            //Debug.Log(playerController+"");
            if (playerController != null)
            {
                //Debug.Log("collision");
                carController.Pre_pos = myCheckpoint.transform.position;
                if (myCheckpoint.transform.position.z > 950)
                {
                    playerController.gameWon = true;
                    Destroy(gameObject);
                }
                else myCheckpoint.transform.position += new Vector3(0, 0, 200);
            }
            if (!checkpointAudioSource.isPlaying) checkpointAudioSource.Play();
        }
	}
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        // if(playerController!=null)Debug.Log("YEAH");
        carController = GameObject.Find("Car").GetComponent<CarController>();
        checkpointAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
