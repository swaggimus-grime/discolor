using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Slider timerFill;

    void Update()
    {
        timerFill.value = GameManager.Instance.timeLimit;
    }
}
