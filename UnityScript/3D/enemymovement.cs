using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注意這次腳本有用到NavMeshAgent 屬於AI，所以要加入AI
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    //定義要追蹤的目標
    private Transform player;
    //定義NavMeshAgent
    private NavMeshAgent nav;

    private void Awake()
    {
        //使用FindGameObjectWithTag的方式找到Tag為Player的目標
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //取得NavMeshAgent元件
        nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //NavMeshAgent.destination獲取目標的座標
        nav.destination = player.position;
    }
}
