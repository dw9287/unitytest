using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newplayer : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move , rb.velocity.y);
    }
}
