using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class SistemaPuntos : MonoBehaviour
{

    private float puntos;

    private TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        textMesh.text = puntos.ToString("0");
        
    }

    
}
