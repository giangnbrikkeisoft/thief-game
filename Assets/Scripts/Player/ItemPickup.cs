using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private Image healthCarrot, healthPear;

    [SerializeField]
    private Text textCoin, textCarrot, textPear;

    float maxCarrot, maxPear;

    // Start is called before the first frame update
    void Start()
    {
        healthCarrot.fillAmount = 0.5f;
        healthPear.fillAmount = 0.5f;
        maxCarrot = 20;
        maxPear = 20;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBalance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("carrot") || collision.CompareTag("pear") || collision.CompareTag("coin"))
        {
            AudioManager.instance.PlaySound("candy");
            if (healthCarrot.fillAmount >= 0 && healthCarrot.fillAmount <= 1 && healthPear.fillAmount >= 0 && healthPear.fillAmount <= 1)
            {
                if (collision.CompareTag("carrot"))
                {
                    AscendingCarrot();
                }
                if (collision.CompareTag("pear"))
                {
                    AscendingPear();
                }
                if (collision.CompareTag("coin"))
                {
                    ValueTextCoin();
                }
            }
            Destroy(collision.gameObject);
        }
    }

    void CheckBalance()
    {
        if (healthCarrot.fillAmount <= .1f || healthPear.fillAmount <= .1f)
        {
            GameManager.instance.isRestart = false;
            UIManager.instance.ShowDeathUI();
        }
    }

    void FillAmountFruitBar()
    {
        if (GameManager.instance.PointCarrot == maxCarrot || GameManager.instance.PointPear == maxPear)
        {
            maxCarrot += 10;
            maxPear += 10;
        }
        healthCarrot.fillAmount = GameManager.instance.PointCarrot / maxCarrot;
        healthPear.fillAmount = GameManager.instance.PointPear / maxPear;
    }

    void AscendingCarrot()
    {
        GameManager.instance.hitCarrot++;
        GameManager.instance.PointCarrot++;
        textCarrot.text = GameManager.instance.PointCarrot.ToString();
        DecreasePear();
        FillAmountFruitBar();
    }

    void AscendingPear()
    {
        GameManager.instance.hitPear++;
        GameManager.instance.PointPear++;
        textPear.text = GameManager.instance.PointPear.ToString();
        DecreaseCarrot();
        FillAmountFruitBar();
    }

    void DecreaseCarrot()
    {
        GameManager.instance.PointCarrot--;
        textCarrot.text = GameManager.instance.PointCarrot.ToString();
    }

    void DecreasePear()
    {
        GameManager.instance.PointPear--;
        textPear.text = GameManager.instance.PointPear.ToString();
    }

    void ValueTextCoin()
    {
        GameManager.instance.hitCoin++;
        GameManager.instance.PointCoin++;
        textCoin.text = GameManager.instance.PointCoin.ToString();
    }

    public void ResetFruitBar()
    {
        healthCarrot.fillAmount = 0.5f;
        healthPear.fillAmount = 0.5f;
        textCarrot.text = "10";
        textPear.text = "10";
        textCoin.text = "0";
        maxCarrot = 20;
        maxPear = 20;
    }
}
