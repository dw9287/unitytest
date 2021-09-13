using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoalCtrl : MonoBehaviour
{
    public GameObject goalObj;
    public Animator animCtrl;
    public BGMCtrl bgmCtrl;
    public float countTime = 1;

    //複数回ゴールポイントに接触しても大丈夫なようにする
    private bool isGoal;
    
   

    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem")&&isGoal==false)
        {
            StartCoroutine(GameClear(collision));
            isGoal = true;
        }
    }


    IEnumerator GameClear(Collider2D collision)
    {
        animCtrl.SetFloat("toRun", 0);
        animCtrl.SetTrigger("Goal");
        
        GetComponent<PlayerCtrl>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.5f);
        bgmCtrl.StopBgm();
        Instantiate(goalObj, transform.position , transform.rotation);
        yield return new WaitForSeconds(countTime);
        animCtrl.SetTrigger("StartGoalAnim");
        
    }
    
}
