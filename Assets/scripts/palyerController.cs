using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyerController : MonoBehaviour
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
        enemy enemy = col.collider.GetComponent<enemy>();
        if (enemy!=null)
        {
           foreach(ContactPoint2D contactPoint in col.contacts)
            {
                Debug.DrawLine(contactPoint.point, contactPoint.point + contactPoint.normal, Color.red, 10);
            }
        }
    }
}
