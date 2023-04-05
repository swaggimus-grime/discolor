using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void Disappear()
    {
        anim.SetBool("gameStarted", true);
    }
}
