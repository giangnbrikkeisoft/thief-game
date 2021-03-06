﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header ("Win UI")]
    [SerializeField]
    private GameObject winUI;

    [Header ("Death UI")]
    [SerializeField]
    private GameObject deathUI;
    [SerializeField]
    private Text textCoin, textCarrot, textPear;
    

    [Header ("Shop UI")]
    [SerializeField]
    private GameObject shopUI;


    [Header ("Home UI")]
    [SerializeField]
    private GameObject homeUI;
    [SerializeField]
    private Image homeSoundImage;


    [Header ("Pause UI")]
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private Image pauseSoundImage;


    [Header ("Play UI")]
    [SerializeField]
    private GameObject playUI;
    [SerializeField]
    private Button btnJump;
    [SerializeField]
    private Button btnFire;


    [Header ("UI Manager")]
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    Sprite muteSound, turnOnSound;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    //death
    public void ShowDeathUI()
    {
        SetFruitPoint();
        playerController.DisableCollider();
        StartCoroutine(ActiveCollider());
        deathUI.SetActive(true);
    }

    IEnumerator ActiveCollider()
    {
        yield return new WaitForSeconds(1f);
        playerController.EnableCollider();
    }

    public void HideDeathUI()
    {
        Time.timeScale = 1;
        deathUI.SetActive(false);
    }

    //shop
    public void ShowShopUI()
    {
        shopUI.SetActive(true);
    }

    public void HideShopUI()
    {
        shopUI.SetActive(false);
    }

    //home
    public void ShowHomeUI()
    {
        LevelManager.instance.RestartLevel();
        homeUI.SetActive(true);
    }

    public void HideHomeUI()
    {
        Time.timeScale = 1;
        homeUI.SetActive(false);
    }

    //pause
    public void ShowPauseUI()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void HidePauseUI()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    //win
    public void ShowWinUI()
    {
        winUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideWinUI()
    {
        winUI.SetActive(false);
        Time.timeScale = 1;
    }


    //button sound
    public void PressSound()
    {
        if (homeSoundImage.sprite == turnOnSound && pauseSoundImage.sprite == turnOnSound)
        {
            homeSoundImage.sprite = muteSound;
            pauseSoundImage.sprite = muteSound;
        }
        else
        {
            homeSoundImage.sprite = turnOnSound;
            pauseSoundImage.sprite = turnOnSound;
        }
    }

    //disable button jump and fire
    public void DisableJumpAndFire()
    {
        btnJump.interactable = false;
        btnFire.interactable = false;
    }

    //enable button jump and fire
    public void EnableJumpAndFire()
    {
        btnJump.interactable = true;
        btnFire.interactable = true;
    }

    //set point hit fruit to display
    void SetFruitPoint()
    {
        textCoin.text = GameManager.instance.hitCoin.ToString();
        textCarrot.text = GameManager.instance.hitCarrot.ToString();
        textPear.text = GameManager.instance.hitPear.ToString();
    }
}
