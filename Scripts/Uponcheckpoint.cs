using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uponcheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController playerController; 
    void Start()
    {
        playerController=GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject checkpoint = GameObject.Find("Checkpoint");
        if (this.gameObject.transform.position.z<=1000f && this.gameObject.transform.position.z - checkpoint.transform.position.z > 5f)
        {
            playerController.gameOver = true;
        }
    }
}
