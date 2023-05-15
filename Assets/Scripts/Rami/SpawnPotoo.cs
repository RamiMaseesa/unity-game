using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPotoo : MonoBehaviour
{
    private int spawnRate = 0;
    [SerializeField] GameObject potoo;
    [SerializeField] GameObject spawnPos;

    private GameObject text;
    private CountMeters countMeters;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Canvas");
        countMeters = text.GetComponent<CountMeters>();
        spawnRate = Random.Range(1, 10);

    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = Random.Range(1, 300);
        if (countMeters.meters > 300 && !GameObject.Find("potoo(Clone)") && spawnRate == 1)
        {
            Instantiate(potoo, spawnPos.transform.position, Quaternion.identity);
        }
    }
}
