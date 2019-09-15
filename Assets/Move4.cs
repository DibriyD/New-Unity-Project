using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move4 : MonoBehaviour
{
    private Rigidbody2D body;
    private bool facingRight = true;
    [SerializeField]private float distance =1f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {   
        Vector3 c = body.transform.position;
        if(Input.GetButtonUp("Horizontal"))
        c.x+=distance * Input.GetAxis("Horizontal");
        transform.position = c;
    }
}
