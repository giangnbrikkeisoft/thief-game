using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy" || collision.transform.tag == "monster")
        {
            GameManager.instance.isRestart = false;
            UIManager.instance.ShowDeathUI();
        }

        if (collision.transform.tag == "win")
        {
            UIManager.instance.ShowWinUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") || collision.CompareTag("monster"))
        {
            GameManager.instance.isRestart = false;
            UIManager.instance.ShowDeathUI();
        }
    }
}
