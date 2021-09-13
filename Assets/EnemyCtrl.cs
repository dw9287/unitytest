using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public float enemySpeed = 5;
    private int direction = -1;
    private Rigidbody2D rb;
    public Animator animCtrl;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        rb.velocity = new Vector2(enemySpeed*direction, rb.velocity.y);
    }

    public void EnemyDirection()
    {
        direction *= -1;
        Flip();
        
    }
    public void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    public void DestroyEnemy()
    {
        Instantiate(explosion, this.transform.position,this.transform.rotation);
        Destroy(this.gameObject);
    }
   
}
