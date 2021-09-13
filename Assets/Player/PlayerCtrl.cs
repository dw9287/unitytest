using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    //�ړ��ƃW�����v
    private float move;
    public float runSpeed;
    private Rigidbody2D rb;
    private bool facingRight = true;    
    public float jumpForce = 10;

    //�W�����v�̍�������
    private float jumpTime;
    public float jumpStartTime;
    private bool isJumping = false;

    //���n����
    private bool isGround = false;

    //�A�j���[�V�����R���g���[���p
    public Animator animCtrl;
    
    // ���ꂽ���̃G�t�F�N�g
    public GameObject playerDeathFx;

    //SoundEffect
    public AudioSource audioSource;
    public AudioClip jumpSound;

    

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animCtrl = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
         move = Input.GetAxisRaw("Horizontal");

         animCtrl.SetFloat("toRun", Mathf.Abs(move));
         animCtrl.SetFloat("yVelocity", rb.velocity.y);


         //�����̕ύX
         if (move < 0 && facingRight)
         {
             Flip();
         }
         else if (move > 0 && !facingRight)
         {
             Flip();
         }

          //�W�����v�J�n
         if (Input.GetButtonDown("Jump") && isGround)
         {
           �@isJumping = true;
             jumpTime = jumpStartTime;
             Jump();
                
             animCtrl.SetBool("Jump", true);
         }
         //�W�����v�̍�������
         else if (Input.GetButton("Jump") && isJumping == true)
         {
           �@if (jumpTime > 0)
             {
                rb.velocity = Vector2.up * jumpForce;
                jumpTime -= Time.deltaTime;
             }
             else
             {
                 isJumping = false;
             }
         }
         else if (Input.GetButtonUp("Jump")&&isJumping==true)
         {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0) * Time.deltaTime;
             isJumping = false;
         }

    }

    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jumpSound);
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
    }

    public void IsGroundToTrue()
    {
        isGround = true;
        animCtrl.SetBool("Jump", false);
    }
    public void IsGroundToFalse()
    {
        isGround = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (transform.position.y > collision.transform.position.y+0.003f)
            {
                collision.GetComponent<EnemyCtrl>().DestroyEnemy();
                Jump();
            }
            else if(transform.position.y <= collision.transform.position.y + 0.003f)
            {
                PlayerDeath();
            }
        }
        
        else if (collision.CompareTag("PlayerKiller"))
        {
            Destroy(collision);
            PlayerDeath();
        }

    }


    public void PlayerDeath()
    {
        Destroy(this.gameObject);
        Instantiate(playerDeathFx, this.transform.position, this.transform.rotation);
        rb.velocity = Vector2.up * jumpForce;
        GetComponent<BoxCollider2D>().isTrigger = true;        
    }

    public void ChangetoGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }


}
