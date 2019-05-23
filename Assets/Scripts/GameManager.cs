using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int pointCarrot, pointPear, pointCoin;
    [SerializeField]
    PlayerController playerController;

    public bool isRestart = true;

    int click = 0;

    public int PointCarrot
    {
        get
        {
            return pointCarrot;
        }

        set
        {
            pointCarrot = value;
        }
    }

    public int PointPear
    {
        get
        {
            return pointPear;
        }

        set
        {
            pointPear = value;
        }
    }

    public int PointCoin
    {
        get
        {
            return pointCoin;
        }

        set
        {
            pointCoin = value;
        }
    }

    public int hitCarrot, hitPear, hitCoin;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        PointCarrot = 10;
        PointPear = 10;

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isRestart)
        {   
            click++;
            if (click == 1)
            {
                click = 0;
                StartCoroutine(Restart());
            }
        }
        
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(.5f);
        isRestart = true;
        playerController.isPlay = false;
        Debug.Log("Reset Level");
        LevelManager.instance.RestartLevel();
    }

    public void ResetPoint()
    {
        pointCarrot = 10;
        pointPear = 10;
        pointCoin = 0;

        //current point
        hitCarrot = 0;
        hitPear = 0;
        hitCoin = 0;
    }



}
