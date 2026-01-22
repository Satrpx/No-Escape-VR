using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// using UnityEditor.Experimental.GraphView;

public class Showtimer : MonoBehaviour
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
        // AdaptUISize();
    }
    // void OnRectTransformDimensionsChange()
	// {
    //     // AdaptUISize();
	// }

    // void AdaptUISize()
    // {
    //     // 获取屏幕分辨率[2](@ref)
    //     int screenWidth = Screen.width;
    //     int screenHeight = Screen.height;

    //     // 获取Canvas Scaler的参考分辨率与匹配设置[1,4](@ref)
    //     // Vector2 referenceResolution = canvasScaler.referenceResolution;
    //     // float matchRatio = canvasScaler.matchWidthOrHeight;

    //     // // 计算缩放因子
    //     // float scaleFactorX = screenWidth / referenceResolution.x;
    //     // float scaleFactorY = screenHeight / referenceResolution.y;
    //     // float scaledFactor = Mathf.Lerp(scaleFactorX, scaleFactorY, matchRatio);

    //     // // 调整RectTransform的尺寸（示例：设置为屏幕高度的20%）
    //     // float targetHeight = screenHeight * 0.2f;
    //     // // 转换为Canvas空间中的尺寸
    //     // float canvasSpaceHeight = targetHeight / scaledFactor;
    //     // rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasSpaceHeight);
    //     rectTransform.position = new Vector3(screenWidth/2, screenHeight/2, -100);
    // }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameWon)
        {
            rectTransform.localPosition = new Vector3(0, 0.2f, 0);
            tmpText.text = "You Won! You Spent " + time + " seconds\nYou died " + playerController.deathCount +" times";
        } else {
            time = Time.time - start_time;
            tmpText.text = "Time: " + time + "s";
        }
    }
}
