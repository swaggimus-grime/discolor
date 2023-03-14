using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour
{  

    
    public TMP_Text MyScoreText;
    private int ScoreNum;

    public TMP_Text MyComboText;
    private int ComboNum;

private void OnTriggerCollid2D (Collider2D other) {
     MyScoreText.text = "Score" + ScoreNum;
}
    public void UpdateScore(){
       MyScoreText.text = "Score: " + 
        ScoreNum++;
       
    }


  public void UpdateCombo(){
        ComboNum++;
      //  MyComboText.text =  ComboNum;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
