using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGroundCheckerCtrl : MonoBehaviour
{
    public EnemyCtrl enemyCtrl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            enemyCtrl.EnemyDirection();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
           enemyCtrl.EnemyDirection();
        }


    }
}
