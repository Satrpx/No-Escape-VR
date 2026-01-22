using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// using UnityEditor.Experimental.GraphView;

public class Instuctions : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text tmpText;
    private PlayerController playerController;
    private float time;
    private float start_time;
    private CanvasScaler canvasScaler;
    private RectTransform rectTransform;
    void Start()
    {
        tmpText = gameObject.GetComponent<TMP_Text>();
        start_time = Time.time;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        canvasScaler = GetComponentInParent<CanvasScaler>();
        rectTransform = GetComponent<RectTransform>();
        if (playerController.language == "zh-cn") tmpText.text = "移动：右摇杆\n转向：左摇杆\n跳跃：右扳机\n重置：X\n切换视角：Y\n回到主界面：B\n紫色的是检查点";
        else if (playerController.language == "en") tmpText.text = "Move: Right Joystick\nTurn: Left Joystick\nJump: Right Trigger\nReset: Button X\nChange Perspective: Button Y\nBack to Menu: Button B\nThe Purple Blocks are checkpoints";
        // AdaptUISize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
