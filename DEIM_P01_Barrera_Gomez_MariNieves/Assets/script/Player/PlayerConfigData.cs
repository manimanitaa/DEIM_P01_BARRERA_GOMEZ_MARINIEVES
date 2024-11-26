using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = " Data/Player Configuration Data")]
public class PlayerConfigData : ScriptableObject
{
    [Tooltip("Velocidad de movimeinto del personaje")]
    [SerializeField] private float movementSpeed;

    public RuntimeAnimatorController animatorController;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            if (value > 0)
            {
                movementSpeed = value;
            }
            else
            {
                Debug.LogError("la velocidad de m,ovimiento no puede ser negativa");
            }
        }

    }
}
