using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;
    private TMP_Text tmpText;
    private float start_time;
	// void OnS()
	// {
	// 	SceneManager.LoadScene(1);
	// }

	// Start is called before the first frame update
	void Start()
    {
        leftHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftHand);
        rightHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
        tmpText = gameObject.GetComponent<TMP_Text>();
        tmpText.text = "Track 1: Press X to enter\nTrack 2: Press Y to enter\nExit Game: Press B";
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        bool game1;
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out game1) && game1) SceneManager.LoadScene(1);
        bool game2;
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out game2) && game2) SceneManager.LoadScene(2);
        bool exit;
        if ((Time.time - start_time > 0.5) && rightHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out exit) && exit)
		{
            #if UNITY_EDITOR
                // 在编辑器模式下，退出播放模式
                UnityEditor.EditorApplication.isPlaying = false;
                Debug.Log("已在编辑器下退出播放模式。");
            #else
                // 在打包后的应用程序中，退出程序
                Application.Quit();
            #endif
		}
    }
}
