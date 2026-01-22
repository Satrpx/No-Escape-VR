using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class CarController : MonoBehaviour
{
    // 车轴枚举，用于区分前轮和后轮
    public enum Axel
    {
        Front,
        Rear
    }
    public bool VREnabled = true;

    // 车轮结构体，将车轮模型、碰撞器和所属车轴关联
    [System.Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;      // 车轮视觉模型
        public WheelCollider wheelCollider; // 车轮碰撞器
        public Axel axel;                   // 所属车轴（前轮或后轮）
    }

    [Header("车辆参数")]
    public float maxAcceleration = 50.0f;    // 最大加速度
    public float brakeAcceleration = 500.0f;   // 刹车强度
    public float turnSensitivity = 1.0f;      // 转向灵敏度
    public float maxSteerAngle = 30.0f;       // 最大转向角度
    public Vector3 centerOfMass;               // 车辆重心，用于调整稳定性

    [Header("车轮设置")]
    public List<Wheel> wheels;                 // 车轮列表

    private float moveInput;                   // 移动输入（前进/后退）
    private float steerInput;                  // 转向输入（左/右）
    private float lastSteerInput;
    
    private bool jumping;                     // 跳跃状态
    private Rigidbody carRb;                   // 车辆刚体

    private PlayerController playerController; // 玩家控制器引用

    private GameObject cameraObject;

    public Vector3[] cam_pos = { new Vector3(0, 2, -8), new Vector3(-0.35f, 1.1f, 0f) }; 
    public int cam_mode = 0;
    public Vector3 Pre_pos;
    public Quaternion Pre_rot;
    public AudioClip engineSound;
    private AudioSource engineAudioSource;
    private GameObject steeringWheel;
    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;
    private float reset_cooldown;
    private float cam_change_cooldown;
    private float start_time;
    void Start()
    {
        steerInput = 0;
        reset_cooldown = cam_change_cooldown = -1;
        Pre_rot = Quaternion.identity;
        carRb = GetComponent<Rigidbody>();
        // 设置车辆重心，降低重心可以增加稳定性，防止翻车
        carRb.centerOfMass = centerOfMass;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        cameraObject = GameObject.Find("Camera Offset");
        engineAudioSource = gameObject.AddComponent<AudioSource>();
        engineAudioSource.clip = engineSound;
        engineAudioSource.playOnAwake = false;
        steeringWheel = GameObject.Find("Steer");
        if (VREnabled)
        {
            leftHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.LeftHand);
            rightHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);
        }
        start_time = Time.time;
    }

    void Update()
    {
        // if(gameObject.GetComponent<PlayerController>().gameOver)
        // {
        //     // 如果游戏结束，停止所有车辆运动
        //     foreach (var wheel in wheels)
        //     {
        //         wheel.wheelCollider.motorTorque = 0;
        //         wheel.wheelCollider.brakeTorque = Mathf.Infinity; // 施加无限制刹车
        //     }
        //     return; // 跳过后续更新
        // }
        if (VREnabled) VRGetInputs();
        else GetInputs();        // 获取玩家输入
        AnimateWheels();    // 更新车轮视觉模型的位置和旋转
    }

    void FixedUpdate()
    {
        Move();             // 控制车辆加速和刹车
        Steer();            // 控制车辆转向
        // Uponcheckpoint();
    }
    
    void VRGetInputs()
	{
        Vector2 input = new Vector2(0,0);
        rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out input);
        moveInput = input.y;//右手纵轴
        input = new Vector2(0,0);
        lastSteerInput = steerInput;
        leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out input);//左手横轴
        steerInput = input.x;
        steeringWheel.transform.RotateAround(steeringWheel.GetComponent<MeshRenderer>().bounds.center, steeringWheel.transform.forward, -(steerInput - lastSteerInput) * maxSteerAngle * 3);
        // jumping = Input.GetKey(KeyCode.Space); // 空格键用于跳跃
        jumping = false;
        rightHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out jumping);//右扳机
        bool reset;
        if (Time.time - start_time > 0.5 && reset_cooldown < Time.time)//x键重开
        {
            leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out reset);
            if (reset)
            {
                playerController.gameOver = true;
                reset_cooldown = Time.time + 0.5f;
            }
        }
        bool cam_change;
        if (Time.time - start_time > 0.5 && cam_change_cooldown < Time.time && leftHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out cam_change) && cam_change)//Y键切视角
        {
            cam_mode = cam_mode ^ 1;
            cameraObject.transform.localPosition = cam_pos[cam_mode];
            cam_change_cooldown = Time.time + 0.2f;
        }
        if(Time.time - start_time < 0.5) cameraObject.transform.localPosition = cam_pos[cam_mode];
	}

    // 获取玩家输入
    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");  // W/S 或 上/下 箭头键
        lastSteerInput = steerInput;
        steerInput = Input.GetAxis("Horizontal"); // A/D 或 左/右 箭头键
        steeringWheel.transform.RotateAround(steeringWheel.GetComponent<MeshRenderer>().bounds.center, steeringWheel.transform.forward, -(steerInput-lastSteerInput) * maxSteerAngle * 3);
        jumping = Input.GetKey(KeyCode.Space); // 空格键用于跳跃
        if (Input.GetKeyDown(KeyCode.R)) playerController.gameOver = true;
        if (Input.GetKeyDown(KeyCode.V))
        {
            cam_mode = cam_mode ^ 1;
            cameraObject.transform.localPosition = cam_pos[cam_mode];
        }
    }

    // 控制车辆加速和刹车
    void Move()
    {
        bool isGrounded = true;
        //if(moveInput!=0)Debug.Log("Move Input: " + moveInput);
        foreach (var wheel in wheels)
        {
            // 设置车轮马达扭矩（驱动轮）
            if (moveInput == 0)
            {
                wheel.wheelCollider.brakeTorque = 2000 * brakeAcceleration;
                wheel.wheelCollider.motorTorque = 0;
            }
            else if( Math.Abs(carRb.velocity.magnitude) < 3 || ((moveInput > 0) == (Vector3.Dot(carRb.velocity, carRb.rotation * Vector3.forward)>0)) ) // 前进
            {
                if(!engineAudioSource.isPlaying) engineAudioSource.Play();
                // Debug.Log(carRb.velocity.magnitude);
                wheel.wheelCollider.brakeTorque = 0;
                wheel.wheelCollider.motorTorque = moveInput * 2000 * maxAcceleration;
			}
            else // 刹车
            {
                // Debug.Log(carRb.velocity.magnitude);
                wheel.wheelCollider.motorTorque = 0;
                wheel.wheelCollider.brakeTorque = 1000 * brakeAcceleration;
            }
            // 检查车轮是否接触地面
            if (!wheel.wheelCollider.isGrounded)
            {
                isGrounded = false;
            }
        }
        if (jumping && isGrounded)
        {
            // 简单跳跃实现，通过施加一个向上的力
            carRb.AddForce(Vector3.up * 100000);
        }
        // if(gameObject.transform.position.y < 0) transform.position = new Vector3(transform.position.x,0,transform.position.z);
    }

    // 控制车辆转向（通常只控制前轮）
    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)  // 只对前轮进行转向
            {
                var steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                // 使用线性插值让转向更平滑
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steerAngle, 0.6f);
            }
        }
        // steeringWheel.transform.localRotation = Quaternion.Euler(0, 0, -steerInput * maxSteerAngle);
    }

    // 更新车轮视觉模型的位置和旋转，使其与WheelCollider同步
    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            // 从WheelCollider获取当前的世界位置和旋转
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            // 应用给视觉模型
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
    public void ResetCarPosition()
    {
        carRb.velocity = Vector3.zero;
        carRb.angularVelocity = Vector3.zero;
        transform.localPosition = Pre_pos;
        transform.rotation = Pre_rot;
    }
    // public void Uponcheckpoint()
    // {
    //     GameObject checkpoint = GameObject.Find("Checkpoint");
    //     if (this.gameObject.transform.position.z - checkpoint.transform.position.z > 5f)
    //     {
    //         playerController.gameOver = true;
    //     }
    // }
}
