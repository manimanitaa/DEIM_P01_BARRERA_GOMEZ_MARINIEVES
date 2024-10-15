using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    [SerializeField] private float vida;

    
    public void TomarDanio(float danio)
    {

        vida -= danio;
        if(vida <= 0)
        {
            Muerte();
        }

    }

    private void Muerte()
    {
        Destroy(gameObject);
    }
}
