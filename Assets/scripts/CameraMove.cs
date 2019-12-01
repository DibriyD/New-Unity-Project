using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Camera camera;
    [SerializeField] move m;
    [SerializeField] bool moveRight;
    [SerializeField] bool moveDown;
    float cameraSize;
    float cameraSizeY;
    Rigidbody2D rb;
    GameObject player;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        camera = GetComponent<Camera>();
        cameraSize = transform.position.magnitude;
        cameraSizeY = camera.orthographicSize;
    }
    bool dvig = false;
    // Update is called once per frame
    Vector3 v2;
    float speed;
    float add;
    void Update()
    {

        float x = transform.position.x +cameraSize;
        float y = transform.position.y-cameraSizeY;
        speed= 15f * Time.deltaTime;
   


        if (m.transform.position.x >= x || m.transform.position.y<=y)
        {
            dvig = true; player.GetComponent<Rigidbody2D>().constraints =
                RigidbodyConstraints2D.FreezeAll;   
                
        }
    
        if (dvig && player.GetComponent<move>().deltaX!=0 && moveRight)
        {
            player.GetComponent<Rigidbody2D>().velocity *= 0;
            player.GetComponent<move>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            rb.velocity = 25 * Vector2.right;
            if (transform.position.x - startPos.x >=cameraSize+cameraSize/2+2)
            {
                Freeze();
            }
        }
        if (dvig && player.GetComponent<move>().deltaX == 0 && moveDown)
        {
            player.GetComponent<Rigidbody2D>().velocity *= 0;
            player.GetComponent<move>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            rb.velocity = 25 * Vector2.down;
            if (startPos.y - transform.position.y >= Mathf.Abs(27.5f))
            {

                Freeze();
            }
        }


    }
    void Freeze()
    {
        startPos = transform.position;
        rb.velocity *= 0;
        dvig = false;
        player.GetComponent<move>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Rigidbody2D>().constraints =
        RigidbodyConstraints2D.None;
       player.GetComponent<Rigidbody2D>().constraints =
      RigidbodyConstraints2D.FreezeRotation;
    }
}
