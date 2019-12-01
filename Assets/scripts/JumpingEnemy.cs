using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
   public float speedX=1;
    public float speedY = 1;
    int direction=1;
    float movingX=0;
    float movingY = 0;
    Vector3 start;
    
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    [SerializeField] Vector3 endpos=Vector3.zero;
    [SerializeField] float g=9.8f;
    BoxCollider2D box;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        start = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
   public Vector2 v=new Vector2(1,5);
   
    void Update()
    {
        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        movingX+= direction * speedX * Time.deltaTime;
            movingY+= direction * speedY * Time.deltaTime * Mathf.Sqrt(3) / 2;
            float x = start.x + movingX;
            float y = start.y + speedY * movingY - (g * (float)Mathf.Pow(movingY, 2)) / 2;
        Vector2 vector = new Vector2(1.5f, 15);
       
            rigidbody.AddForce(vector*15);
        if (endpos.x <= transform.position.x)
            vector.x*= -1;





    }
  
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(start, endpos);
    }
 
}
