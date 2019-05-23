using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Spine.Unity;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    private Transform levelGame;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private ItemPickup itemPickup;

    [SerializeField]
    DataLevel dataLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartLevel()
    {
        foreach (Transform child in levelGame)
        {
            Destroy(child.gameObject);
        }
        Instantiate(dataLevel.levelData, levelGame.transform);
        ResetStatePlayer();
        ResetStateUI();    
        GameManager.instance.ResetPoint();
        
    }

    void ResetStatePlayer()
    {
        player.position = dataLevel.playerPositionData;
        player.GetComponent<SkeletonAnimation>().AnimationName = "gun";
    }

    void ResetStateUI()
    {
        UIManager.instance.DisableJumpAndFire();
        itemPickup.ResetFruitBar();
        UIManager.instance.HideDeathUI();
    }

    public void AddLevel()
    {

    }

}
