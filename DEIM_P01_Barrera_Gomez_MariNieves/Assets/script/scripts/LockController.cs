using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockController : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private PlayerInventory inventory;

    private void Start()
    {
       
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            inventory =collision.gameObject.GetComponent<PlayerInventory>();

            if (inventory.key)
            {
                SceneManager.LoadScene(sceneToLoad);
            }

        }
        
    }
}
