using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    BoxCollider2D box;
    Renderer sprite;
    float time=2;
    float currTime;
    [SerializeField] enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<Renderer>();
        currTime = time;
    }
    bool on;
    // Update is called once per frame
    void Update()
    {
       if(currTime<=0)
        {
            on = !on;
            if(on)
            {
                box.isTrigger = false;
                sprite.material.color = Color.white;
            }
            if(!on)
            {
                box.isTrigger = true;
                sprite.material.color = Color.green;
            }
            currTime = time;
        }
        
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        enemy.EnemyCollision(col);
    }
    void FixedUpdate()
    {
        currTime -= Time.fixedDeltaTime;  
    }
}
