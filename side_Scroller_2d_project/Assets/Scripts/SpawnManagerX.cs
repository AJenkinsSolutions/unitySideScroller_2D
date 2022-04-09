using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject obstaclePreFab;
    private float repeatInterval = 2f;
    private float startDelay = 1.5f;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();

        InvokeRepeating("SpawnObject", startDelay, repeatInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnObject()
    {
        if(!playerControllerScript.gameOver)
        { Instantiate(obstaclePreFab, transform.position, Quaternion.identity); }
    }
}
