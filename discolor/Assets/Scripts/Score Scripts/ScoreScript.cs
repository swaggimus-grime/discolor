using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript2 : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    public TextMeshProUGUI MycomboText;
    private int ScoreNumber;
    private int ComboNumber;

    // Start is called before the first frame update
    void Start()
    {
        
        ScoreNumber = 0;
        ComboNumber = 1;
        MyscoreText.color = Color.red;
        MyscoreText.color = Color.red;
        MyscoreText.text = "Score: " + ScoreNumber;
        MycomboText.text = " ";
        MycomboText.color = Color.white;
    }

    
    private void OnTriggerEnter2D(Collider2D Tile)
    {
        if (Tile.tag == "MyTile")
        {
            ScoreNumber++;
            MyscoreText.text = "Score:" + ScoreNumber;
            MycomboText.text = "Combo:" + ScoreNumber;
        }



        if (ScoreNumber >200)
        {
            switch (ScoreNumber)
            {
                case 202:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.blue;
                    break;

                case 203:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.yellow;
                    break;

                case 204:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.cyan;
                    break;
                case 205:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.green;
                    break;
                case 206:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.magenta;
                    break;
                case 207:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.black;
                    break;
                case 208:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.red;
                    break;
                case 209:
                    ComboNumber = ComboNumber + 1;
                    MycomboText.color = Color.red;
                    break;

            }


        }
    }

    private void Update()
    {
        MyscoreText.text = ScoreNumber.ToString();
        ScoreNumber++;

        //MycomboText.text = ComboNumber.ToString();
        //ComboNumber++;

        if (ScoreNumber > 200)
        {
            MycomboText.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);


            //switch (ScoreNumber)
            //{
            //    case 202:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.blue;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;

            //    case 303:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.yellow;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;

            //    case 404:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.cyan;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;
            //    case 505:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.green;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;
            //    case 606:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.magenta;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;
            //    case 707:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.black;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;
            //    case 808:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.red;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;
            //    case 909:
            //        ComboNumber = ComboNumber + 1;
            //        MycomboText.color = Color.red;
            //        MycomboText.text = ComboNumber.ToString();
            //        break;

            //}


        }
    }

}