using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
  
    move child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponentInChildren<move>() != null)
        {

            if (Input.GetKeyDown(KeyCode.S))
                GetComponent<PlatformEffector2D>().rotationalOffset = -180f;


        }
        else { StartCoroutine(Wait()); };

       
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<PlatformEffector2D>().rotationalOffset = 0;
    }
}
