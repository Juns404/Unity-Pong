using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayerR, isPlayerL, isAi;
    public float speed;
    Rigidbody2D rb;
    float movement;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPaddle();
    }

    void MovementPaddle(){
        if(isPlayerR){
            movement = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        }
        else if(isPlayerL){
            movement = Input.GetAxisRaw("Vertical2");
            rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        }
        else if(isAi){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, target.position.y), speed * Time.deltaTime);
        }
        //rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    void Reset(){
        rb.velocity = Vector2.zero;
        if(isPlayerR){
            transform.position = new Vector2(7,8);
            }
        else{
            transform.position = new Vector2(1,1);
        }
    }
}
