using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goleiro : MonoBehaviour
{
    [SerializeField] private GameObject BolaAssociada;

    public float ForcaCatch;

    public void ReceberBola(GameObject bola)
    {
        BolaAssociada = bola;
    }
}
