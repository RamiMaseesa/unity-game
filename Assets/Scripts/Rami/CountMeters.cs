using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountMeters : MonoBehaviour
{
    private GameObject resetPosObject;
    private ResetPos resetPosScript;
    [SerializeField] TMP_Text textPro;
    private float metersPerSec = 3;
    private float meters = 0;

    private void Start()
    {
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    void Update()
    {
        if (resetPosScript.increaseSpeed)
        {
            metersPerSec *= 1.1f;
        }

        meters += Time.deltaTime * metersPerSec;
        textPro.text = "Meters: " + ((int)meters);
        resetPosScript.increaseSpeed = false;
    }
}
