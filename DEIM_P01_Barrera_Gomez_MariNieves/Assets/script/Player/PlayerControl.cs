using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    [SerializeField] private float speed;

    [SerializeField] private float FuerzaSalto;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector2.left * speed);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(Vector2.up * FuerzaSalto);
        }
    }

}
