
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] levelPieces;

    [SerializeField] private int pieceHeight;

    [SerializeField] private int levelHeight;

    [SerializeField] private GameObject[] endPieces;

    [SerializeField] private GameObject[] startPieces;

    [SerializeField] private List<GameObject> piecesToUse;

    // Start is called before the first frame update
    void Start()
    {

        Instantiate(startPieces[Random.Range(0, startPieces.Length)],Vector3.zero, Quaternion. identity, transform);

        piecesToUse = new List<GameObject>();
        int piecesPerType = Mathf.CeilToInt(((float)levelHeight / pieceHeight) / (float) levelPieces.Length);

        for (int lp = 0 ; lp<levelPieces.Length ; lp++)
        {
            for (int p = 0; p < piecesPerType; p++)
            {
                piecesToUse.Add(levelPieces[lp]);
            }
        }



        //for (int p = 0; p < levelHeight/pieceHeight; p ++)
        //{
        //    Instantiate(levelPiece, new Vector3(0, -p * pieceHeight, 0), Quaternion.identity, transform);
        //}

        Instantiate(startPieces[Random.Range(0, startPieces.Length)], Vector3.zero, Quaternion.identity, transform);

        for (int p = pieceHeight; p < levelHeight; p += pieceHeight)
        {
            //Elige aleatoriamente una de las piezas a usar
            int pieceIndex= Random.Range(0, piecesToUse.Count);

            //instancia una copia de la pieza elegida, poniendola acorde a las anteriores
            Instantiate(piecesToUse[Random.Range(0,piecesToUse.Count)], new Vector3(0, -p, 0), Quaternion.identity, transform);

            //elimina la pieza usada en la bolsa para no volverse a usar 
            piecesToUse.RemoveAt(pieceIndex);   
        }
        Instantiate(endPieces[Random.Range(0, endPieces.Length)], new Vector3(0, -levelHeight,0), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
