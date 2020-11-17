using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnManeger : MonoBehaviour
{
    public GameObject enemy;
    public float delaytime=3f;
    public float repeatRate=2f;
    public Transform[] spwnPoint;
    private bool playerIsDead = false;

    private void playerDeathAction()
    {
        playerIsDead = true;

    }
    private void spawn()
    {
        if (playerIsDead)
        {
            CancelInvoke("spawn");
            return;
        }////////////////////////////////////////////////
        int pointIndex = Random.Range(0, spwnPoint.Length);
        Instantiate(enemy, spwnPoint[pointIndex].position, spwnPoint[pointIndex].rotation);
    }//////////////////////////////////////////////////
    private void OnEnable()
    {
        HealthUI.PlayerDeathEvent += playerDeathAction;


    }

    private void OnDisable()
    {
        HealthUI.PlayerDeathEvent -= playerDeathAction;

    }
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating (執行方法,延遲時間,頻率);

        InvokeRepeating("spawn",delaytime,repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
