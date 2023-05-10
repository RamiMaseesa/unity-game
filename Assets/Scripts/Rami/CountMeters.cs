using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountMeters : MonoBehaviour
{
    [SerializeField] TMP_Text textPro;
    private float meters = 0;


    void Update()
    {
        textPro.text = "Meters: " + meters;

        meters += Time.deltaTime * 3;
    }
}
