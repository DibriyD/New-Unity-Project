using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy : MonoBehaviour
{
    [SerializeField] enemy enemy;
    [SerializeField] float speed=5f;
    float move = 0;
    Vector3 start;
    BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move -= speed * Time.fixedDeltaTime;
        box.transform.position = new Vector3(move + start.x, transform.position.y);
        StartCoroutine(Dest());
    }
    void Update()
    {
       
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        enemy.EnemyCollision(col);
    }
    IEnumerator Dest()
    {
        yield return new WaitForSecondsRealtime(2f);
       Destroy(gameObject);
    }
}
