using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
  
    public bool canHit=true;
    
   
    // Start is called before the first frame update
    void Start()
    {  
     
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {
        
    }
   
    public bool EnemyCollision(Collision2D col)
    {
     
        if (col.collider.tag == "Player")
        {
            col.rigidbody.velocity = Vector2.up * col.rigidbody.GetComponent<move>().JumpForce / 2;
            col.collider.GetComponent<Hp>().TakeDamage();
           
            return true;
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (canHit)
            EnemyCollision(col);
        
    }
   
}
