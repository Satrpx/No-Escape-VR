using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;
    public bool gameWon;
    public string language = "en";
    public int deathCount;
    private CarController carController;
    private InputDevice rightHandDevice;
    public AudioClip winClip;
    private float winTime;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameWon = false;
        deathCount = 0;
        winTime = -1;
        foreach (var obj in gameObject.GetComponentsInChildren<Transform>()) obj.gameObject.tag = "Player";
        carController = GameObject.Find("Car").GetComponent<CarController>();
        rightHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.G))
        // {
        //     gameOver = true;
        //     Debug.Log("Game Over triggered.");
        // }
        if (gameOver)
        {
            // Handle game over state (e.g., stop player movement)
            // Debug.Log("Game is over. Player cannot move.");
            gameOver = false;
            deathCount++;
            // GameObject.Find("SpawnManager").GetComponent<SpawnManager>().Start();
            carController.ResetCarPosition();
            // Debug.Log("You Died. Resetting Car Position.");
        }
        if (gameWon)
            if (winTime == -1)
            {
                // Debug.Log("You have won the game.");
                carController.ResetCarPosition();
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = winClip;
                audioSource.Play();
                winTime = Time.time;
                // GameObject Successful_Mark = new GameObject("SuccessfulMark");
                // TMP_Text successful_mark = Successful_Mark.AddComponent<TextMeshProUGUI>();
                // successful_mark.text = "You have won the game!\nYou spent " + winTime + " seconds.";
                // RectTransform rectTransform = Successful_Mark.GetComponent<RectTransform>();
                // rectTransform.sizeDelta = new Vector2(300, 40);
                // GameObject canvasObj = new GameObject("Canvas");
                // Canvas canvas = canvasObj.AddComponent<Canvas>();
                // canvas.renderMode = RenderMode.WorldSpace;
                // canvasObj.AddComponent<CanvasScaler>();
                // canvasObj.AddComponent<GraphicRaycaster>();
                // Successful_Mark.transform.SetParent(canvas.transform);
                // rectTransform.localPosition = Vector3.zero;
            }
            else if (Time.time - winTime > 5)
            {
                SceneManager.LoadScene(0);
            }
        bool exit;
        if (rightHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out exit) && exit)
		{
            SceneManager.LoadScene(0);
		}
    }
}
