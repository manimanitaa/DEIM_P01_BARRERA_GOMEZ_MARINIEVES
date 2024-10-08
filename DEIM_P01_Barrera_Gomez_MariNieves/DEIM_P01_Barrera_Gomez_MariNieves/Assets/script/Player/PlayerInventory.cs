using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    [Tooltip("referencia al icono del /llave/ en la interfaz")]
    [SerializeField] private GameObject keyIcon;

    [Tooltip("Objeto / llave / del inventario")]
    public bool key;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("llave"))

        {
            key = true;
        }
    }






    private void Update()
    {
        if (key)
        {
            keyIcon.SetActive(true);
        }
        else
        {
            keyIcon.SetActive(false);
        }
    }
}
