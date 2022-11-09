using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinState : GameState
{
    // if player takes last piece(s) they win! prompt play again, main menu, or exit game
    [SerializeField] Image menuImage;
    [SerializeField] Text winLoseText;
    [SerializeField] AudioClip winSFX;

    public override void Enter()
    {
        Debug.Log("entering win state");
        AudioHelper.PlayClip2D(winSFX, 1f);
        menuImage.gameObject.SetActive(true);
        winLoseText.text = "you win!";
        winLoseText.color = Color.blue;
        winLoseText.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("exiting win state");
        menuImage.gameObject.SetActive(false);
        winLoseText.gameObject.SetActive(false);
    }
}
