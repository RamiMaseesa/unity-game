using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script spawns clouds
public class SpawnClouds : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    private int spawnRate;
    private int spawnCloud;
    private float spawnYPos;
    private Vector3 spawnPos;
    private int spawnRateModifire;

    private GameObject text;
    private CountMeters countMeters;

    private void Start()
    {
        text = GameObject.Find("Canvas");
        countMeters = text.GetComponent<CountMeters>();
    }
    void Update()
    {
        // change spawn rate

        spawnRate = Random.Range(1, 400);


        if (spawnRate == 1)
        {
            spawnCloud = Random.Range(1, 3);
            spawnYPos = Random.Range(2f, 4f);
            spawnPos = new Vector3(11, spawnYPos, 0);
            Instantiate(clouds[spawnCloud], spawnPos, Quaternion.identity);
        }
    }
}
