using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public enum color { 
        red,
        orange,
        yellow,
        green,
        cyan,
        blue,
        purple,
        pink,
    
    }

    public color currentColor;


    public bool isValidColor(color c)
    {
        switch (currentColor) {
            case color.red:
                if (c == color.orange || c == color.pink)
                {
                    return true;
                } else
                {
                    return false;
                }
                break;
            case color.orange:
                
                break;
        
        }
        return false;
    }
}
