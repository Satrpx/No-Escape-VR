using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Triggerovalcheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource checkpointAudioSource;
    private PlayerController playerController;
    private CarController carController;
    private int num;
    void OnTriggerEnter(Collider other)
    {
        num++;
        GameObject myCheckpoint = this.gameObject;
        Debug.Log("Collision detected with: " + other.name);
        if (other.CompareTag("Player"))
        {
            //Debug.Log(playerController+"");
            if (playerController != null)
            {
                //Debug.Log("collision");
                if (num==6)
                {
                    // Successful_scene();
                    playerController.gameWon = true;
                }
                carController.Pre_pos = myCheckpoint.transform.position;
                carController.Pre_rot = myCheckpoint.transform.rotation;
                if (myCheckpoint.transform.position.x < 0)
                {
                    myCheckpoint.transform.position = new Vector3(0, 0, -28);
                    myCheckpoint.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else
                {
                    myCheckpoint.transform.position = new Vector3(-130.8683f, 0.0015f, -293.3189f);
                    myCheckpoint.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                if (!checkpointAudioSource.isPlaying) checkpointAudioSource.Play();
            }
        }
    }
    void Start()
    {
        num = 0;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        // if(playerController!=null)Debug.Log("YEAH");
        carController = GameObject.Find("Car").GetComponent<CarController>();
        checkpointAudioSource = gameObject.GetComponent<AudioSource>();
        carController.Pre_pos = new Vector3(0, 0, -28);
        carController.Pre_rot = Quaternion.Euler(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // public void Successful_scene()
    // {
    //     GameObject Successful_Mark = new GameObject("SuccessfulMark");
    //     TMP_Text successful_mark = Successful_Mark.AddComponent<TextMeshProUGUI>();
    //     successful_mark.text = "Successful";
    //     RectTransform rectTransform = Successful_Mark.GetComponent<RectTransform>();
    //     rectTransform.sizeDelta = new Vector2(300, 40);
    //     GameObject canvasObj = new GameObject("Canvas");
    //     Canvas canvas = canvasObj.AddComponent<Canvas>();
    //     canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    //     canvasObj.AddComponent<CanvasScaler>();
    //     canvasObj.AddComponent<GraphicRaycaster>();
    //     Successful_Mark.transform.SetParent(canvas.transform);
    //     rectTransform.anchoredPosition = new Vector2(0, 40);
    // }
}
