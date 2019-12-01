using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnHead : MonoBehaviour
{
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player" && col.rigidbody.velocity.y<=3)
        {
            col.rigidbody.velocity = Vector2.up * col.rigidbody.GetComponent<move>().JumpForce;
            Destroy(collider.transform.parent.gameObject);
        }
    }
}
