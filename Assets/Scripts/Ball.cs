using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public bool launchball = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Launch();
    }

    // Update is called once per frame
    void Update()
    {
        Checkinput();
    }

    void Init(){
        
    }

    void Checkinput(){
        if(Input.GetKeyDown(KeyCode.B) && !launchball){
            Launch();
        }
        //Debug.Log(Input.GetKeyDown(KeyCode.B));
    }

    void Launch(){
        launchball = true;
        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x, y).normalized * speed;
    }

    public void Reset(){
        launchball = false;
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "LeftGoal"){
            LevelManager.instance.Scored(Scorer.Left);
        } else if(other.tag == "RightGoal"){
            LevelManager.instance.Scored(Scorer.Right);
        }
    }
}
