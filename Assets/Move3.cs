using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour
{
    private Collider2D collider;
    [SerializeField] private float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (move == (-1))
        {
            collider.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (move ==1)
        {
            collider.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
