using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ript : MonoBehaviour
{
    Vector2 start;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }
    float speed;
    // Update is called once per frame
    void Update()
    {
        
         speed+= 1f * Time.deltaTime;
        Vector2 v = new Vector2(speed, transform.position.y);
        if (transform.position.x - start.x <= 5)
        {
            transform.position = v;

        }
        else
        {
            Debug.Log("yes");
            v *= 0;
            start = transform.position;
        }
    }
}
