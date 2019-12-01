using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPlayerMovement : MonoBehaviour
{
    Vector3 start;
    [SerializeField] Vector2 end = Vector2.zero;
    [SerializeField] float speed=1;
    float moving = 0;
    int direction = 1;
    [SerializeField] bool CanFlip=true;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }
    void FixedUpdate()
    {
        moving += direction * speed * Time.fixedDeltaTime;
        float x = (end.x - start.x) * moving + start.x;
        float y = (end.y - start.y) * moving + start.y;
        transform.position = new Vector3(x, y, start.z);
        if ((direction ==1 && moving > 0.9f) ||(direction==-1 && moving < 0.01f))
        {
            direction *= -1;
            if (CanFlip)
                transform.Rotate(0, 180, 0);
        }
      
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, end);
    }
}
