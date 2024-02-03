using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    // Scroll main texture based on time

    public float scrollSpeed = 0.01f;
    Renderer rend;
    
   
    public void Start()
    {
        
        rend = GetComponent<Renderer>();
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }

    void Update()
    {
         float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
    
}