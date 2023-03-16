using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txt;

    [SerializeField]
    private int revealThreshold;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.comboCounter >= revealThreshold)
        {
            txt.text = "x" + GameManager.Instance.comboCounter;
        }
        else
        {
            txt.text = "";
        }
    }
}
