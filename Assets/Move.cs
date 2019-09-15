using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
  [SerializeField]private float speed = 3f;
    private Rigidbody2D body;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        float delta=Input.GetAxisRaw("Horizontal") *speed*Time.deltaTime;            
        Vector2 movement = new Vector2(delta, body.velocity.y);
        body.velocity = movement;
        if (delta < 0 && facingRight)
            Flip();
        else if(delta>0 && !facingRight)Flip(); 
    }
    private void Flip()
    {
            facingRight=!facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
    }
}
