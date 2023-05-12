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

    public float meters = 0;

    private void Start()
    {
        resetPosObject = GameObject.Find("moving");
        resetPosScript = resetPosObject.GetComponent<ResetPos>();
    }

    void Update()
    {
        meters += Time.deltaTime * (resetPosScript.speedValue * 1.2f);
        textPro.text = "Meters: " + ((int)meters);
    }
}
