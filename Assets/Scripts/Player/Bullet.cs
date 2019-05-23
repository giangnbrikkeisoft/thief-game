using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);

        Destroy(gameObject, 2f);
    }
}
