using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createovalcheckpoint : MonoBehaviour
{
    private AudioSource checkpointAudioSource;
    public AudioClip checkpointSound;
    Mesh CreateWireframeCube()
    {
        // 创建线框立方体网格（仅编辑器用）
        GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Mesh mesh = temp.GetComponent<MeshFilter>().mesh;
        Destroy(temp);
        return mesh;
    }
    void CreateTriggerObject()
    {
        GameObject triggerObject = new GameObject("Checkpoint");
        triggerObject.transform.localScale = new Vector3(20, 1, 10);
        triggerObject.transform.position = new Vector3(-130.8683f, 0.0015f, -293.3189f);
        triggerObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        // 添加碰撞器并设置为Trigger
        BoxCollider collider = triggerObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(1, 10, 1);

        // 添加触发器脚本
        triggerObject.AddComponent<Triggerovalcheckpoint>();
        checkpointAudioSource = triggerObject.AddComponent<AudioSource>();
        checkpointAudioSource.clip = checkpointSound;
        checkpointAudioSource.playOnAwake = false;
        
        triggerObject.AddComponent<MeshRenderer>();
        triggerObject.AddComponent<MeshFilter>().mesh = CreateWireframeCube();
        // Debug.Log(collider.center);
    }
    void Start()
    {
        CreateTriggerObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
