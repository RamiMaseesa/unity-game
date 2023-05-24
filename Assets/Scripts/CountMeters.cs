using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// this cript counts the amount of meters the player has reached
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
        // add the speedvalue to the meters
        meters += Time.deltaTime * (resetPosScript.speedValue * 1.2f);
        // print the meters as an int
        textPro.text = "Meters: " + ((int)meters);
    }
}
