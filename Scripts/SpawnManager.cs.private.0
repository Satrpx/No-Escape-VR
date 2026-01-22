using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public enum ObstacleType
    {
        LowLong,
        HighShort,
        Moving,
        Laser
    }
	private GameObject[] obstacle;
	// 生成点的Z坐标，通常在玩家前方一段距离
	private Vector3 spawnPos;
    // 首次生成的延迟时间和重复生成的间隔时间
    // private float startDelay = 2f;
    // private float repeatRate = 2f;
    // 用于引用玩家控制器，判断游戏是否结束
    private PlayerController playerControllerScript;

	void Start()
    {
        obstacle = new GameObject[Enum.GetNames(typeof(ObstacleType)).Length];
        // 获取玩家控制脚本的引用
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // 加载所有障碍物预制体
        for(int i = 0; i < Enum.GetNames(typeof(ObstacleType)).Length; i++)
        {
            obstacle[i] = Resources.Load<GameObject>("Obstacle" + (ObstacleType)i);
            // Debug.Log("Resources/Obstacle" + (ObstacleType)i);
            // Debug.Log("Loaded obstacle: " + obstacle[i].name);
        }
        for (int i = 50; i < 1000; i+=50)
        {
            SpawnObstacle(UnityEngine.Random.Range(0,4),i);
        }
        // 开始重复调用生成方法
        // InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle(int index, float zPos)
    {
        // 如果游戏没有结束，才生成障碍物
        if (playerControllerScript != null && !playerControllerScript.gameOver)
        {
            spawnPos = obstacle[index].transform.position;
            // 实例化（创建）障碍物
            spawnPos.z = zPos;
            // 特殊处理高短障碍物，生成三列
            if (index == ObstacleType.HighShort.GetHashCode())
            {
                for (int i = -1; i <= 1; i++)
                {
                    Vector3 offsetPos = spawnPos;
                    offsetPos.x += i * 5.0f; // Adjust spacing as needed
                    if(UnityEngine.Random.Range(0,3) != 0) Instantiate(obstacle[index], offsetPos, obstacle[index].transform.rotation);
                }
            }
            // 随机生成障碍物的X轴位置
            else if (index == ObstacleType.LowLong.GetHashCode())
            {
                Instantiate(obstacle[index], spawnPos, obstacle[index].transform.rotation);
                float randomX = UnityEngine.Random.Range(-5f, 5f);
                spawnPos.x = randomX;
            }
            else if (index == ObstacleType.Moving.GetHashCode())
            {
                Instantiate(obstacle[index], spawnPos, Quaternion.Euler(0,UnityEngine.Random.Range(-45f, 45f),90));
            }
            else
            {
                // float randomX = UnityEngine.Random.Range(-5f, 5f);
                // spawnPos.x = randomX;
                Instantiate(obstacle[index], spawnPos, obstacle[index].transform.rotation);
            }
            Debug.Log("Spawned an obstacle at position: " + spawnPos);
        }
    }
}
