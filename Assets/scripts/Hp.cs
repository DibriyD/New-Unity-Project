using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    [SerializeField] int hp=3;
    int current_Hp=3;
    public float invinsible = 2;
    public int coin = 0;
    Animator anim;

    public Image[] images = new Image[2];
    public Sprite OneImagehp;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<BoxCollider2D>().usedByEffector = true;
        current_Hp = hp;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_Hp <= 0)
            Die();

        for (int i = 0; i < images.Length; i++)
        {
            if (i < current_Hp)
                images[i].enabled = true;
            else images[i].enabled = false;
        }
    }
    public void TakeDamage()
    {
        StartCoroutine(HurtTime());
        anim.SetBool("damaged", true);
        current_Hp--;
       
        Debug.Log(current_Hp);
       
        if (current_Hp <= 0)
            Die();
    }
    public void Heal()
    {
        current_Hp++;
        
        if (current_Hp >= hp)
            current_Hp = hp;
    }
    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
    public void GetCoin()
    {
        coin++;
    }
    IEnumerator HurtTime()
    {
        transform.GetComponent<BoxCollider2D>().usedByEffector = false;
        int layer = LayerMask.NameToLayer("enemyLayer");
        int playerLayer = LayerMask.NameToLayer("playerLayer");
        Physics2D.IgnoreLayerCollision(layer, playerLayer);
        yield return new WaitForSeconds(invinsible);
        Physics2D.IgnoreLayerCollision(layer, playerLayer, false);
        transform.GetComponent<BoxCollider2D>().usedByEffector = false;
        anim.SetBool("damaged", false);
    }
}
