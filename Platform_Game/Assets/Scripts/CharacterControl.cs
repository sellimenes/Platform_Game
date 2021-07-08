using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;






    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
        }
    }
}
