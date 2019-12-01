using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_Next_level : MonoBehaviour
{
    int s;
  void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            s= SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(s + 1);
        }
    }
}
