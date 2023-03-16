using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txt;

    // Update is called once per frame
    void Update()
    {
        txt.text = "" + GameManager.Instance.score;
    }
}
