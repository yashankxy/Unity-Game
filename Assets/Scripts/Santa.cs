using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Santa : MonoBehaviour
{

    public float speed = 5.0f;
    public int numPresents;
    public bool facesRight;
    public bool isIdle;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start(){
        
        SpriteRenderer initialSprite = gameObject.GetComponent<SpriteRenderer>();
        if(initialSprite.name == "character_walk_right_01")
        {
            facesRight = true;
        }
        else if(initialSprite.name == "character_walk_left_01")
        {
            facesRight = false;
        }
        isIdle = true;

        numPresents = 0;
      
    }

    public int GetPresents()
    {
        return this.numPresents;
    }
    // Update is called once per frame
    void Update(){

        Vector3 initial_pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
            // Debug.Log("Left Arrow");
            facesRight = false;
            transform.Translate(-speed*Time.deltaTime, 0, 0);
        }   
        if(Input.GetKey(KeyCode.RightArrow) ||Input.GetKey(KeyCode.D)){
            // Debug.Log("Right Arrow");
            facesRight = true;
            transform.Translate(speed*Time.deltaTime, 0, 0);
        }   
        if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)){
            // Debug.Log("Up Arrow");
 
            transform.Translate(0, speed*Time.deltaTime, 0);
        }   
        if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
            // Debug.Log("Down Arrow");

            transform.Translate(0, -speed*Time.deltaTime, 0);
        }

        Vector3 final_pos = transform.position;
        if(initial_pos-final_pos == Vector3.zero)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }

        // Animation
        animator.SetBool("Is_Idle", isIdle);
        animator.SetBool("Faces_Right", facesRight);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "present"){
            numPresents++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "Tree" ){
            // Debug.Log("Wall Hit"); 
            // if this function is empty then it doesnt collide
            // to bounce back
            if(Input.GetKey(KeyCode.LeftArrow) ||Input.GetKey(KeyCode.A) ){
                transform.Translate(speed*Time.deltaTime, 0, 0);
            }   
            if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
                // Debug.Log("Right Arrow");
                transform.Translate(-speed*Time.deltaTime, 0, 0);
            }   
            if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)){
                // Debug.Log("Up Arrow");
                transform.Translate(0, -speed*Time.deltaTime, 0);
            }   
            if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
                // Debug.Log("Down Arrow");
                transform.Translate(0, speed*Time.deltaTime, 0);
            }   
        }
    }
}
