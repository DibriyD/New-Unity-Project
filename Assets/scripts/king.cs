using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class king : MonoBehaviour
{
    [SerializeField] Slider slider;
    Animator animator;
    int hp = 10;
    public bool damaged;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        slider.value = hp;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Destroy(transform.parent.gameObject);
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.collider.tag == "Player" && col.rigidbody.velocity.y <= 3)
        {
            animator.SetBool("isDamaged", true);
            col.rigidbody.velocity = Vector2.up * col.rigidbody.GetComponent<move>().JumpForce;
            hp--;
           
           
        }
  
           

    }
}
