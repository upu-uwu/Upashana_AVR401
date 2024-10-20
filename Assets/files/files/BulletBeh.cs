using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBeh : MonoBehaviour
{
    void Start()
    {
        Invoke("DestoryGameObj", 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealthSystem>().bulletHit();
            DestoryGameObj();
        }
    }

    void DestoryGameObj()
    {
        Destroy(gameObject);
    }
}