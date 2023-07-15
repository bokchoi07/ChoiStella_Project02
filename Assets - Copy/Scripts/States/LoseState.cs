using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseState : GameState
{
    [SerializeField] Image menuImage;
    [SerializeField] Text winLoseText;
    [SerializeField] AudioClip loseSFX;

    public override void Enter()
    {
        Debug.Log("entering lose state");
        AudioHelper.PlayClip2D(loseSFX, .8f);
        menuImage.gameObject.SetActive(true);
        winLoseText.text = "you lose.";
        winLoseText.color = Color.red;
        winLoseText.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("exiting lose state");
        menuImage.gameObject.SetActive(false);
        winLoseText.gameObject.SetActive(false);
    }
}
