using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Rotate());
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime);
    }
    IEnumerator Rotate()
    {
     while (true)
        {
            
            for (int i = -100; i <= 100; i++)
            {
                transform.Rotate(new Vector3(0, 0, 0.5f) * Time.deltaTime);
                yield return new WaitForSeconds(0.01f);
            }

            for (int i = 100; i >= -100; i--)
            {
                transform.Rotate(new Vector3(0, 0, -0.5f) * Time.deltaTime);
                yield return new WaitForSeconds(0.01f);
            }
            
        }
    }
}
