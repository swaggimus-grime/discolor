using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{



    //Enumerator
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

    public TileInfo(color c)
    {
        currentColor = c;
    }

    public color GetColor()
    {
        return currentColor;
    }

    //This class makes sure that the color is complementary to another.
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
               
            case color.orange:

                if (c == color.red || c == color.yellow)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
            case color.yellow:

                if (c == color.orange || c == color.green)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case color.green:

                if (c == color.yellow || c == color.cyan)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            case color.cyan:

                if (c == color.green || c == color.blue)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case color.blue:

                if (c == color.cyan || c == color.purple)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case color.purple:

                if (c == color.blue || c == color.pink)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case color.pink:

                if (c == color.purple || c == color.red)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        return false;
    }
}
