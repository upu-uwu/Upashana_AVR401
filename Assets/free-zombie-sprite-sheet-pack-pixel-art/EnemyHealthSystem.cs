using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int numofbullTokill = 4;
    int numofbullTaken = 1;
    gameManager gameGM;

    private void Start()
    {
        gameGM = FindAnyObjectByType<gameManager>();
    }

    public void bulletHit()
    {
        if (numofbullTokill > numofbullTaken)
        {
            numofbullTaken++;
            Debug.Log("Arrow Hit : " + numofbullTaken);

        }
        else
        {
            gameGM.AddKills();
            Destroy(gameObject);
        }
    }
}