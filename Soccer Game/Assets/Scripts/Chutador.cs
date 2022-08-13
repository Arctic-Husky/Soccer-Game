using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chutador : MonoBehaviour
{
    [SerializeField] private GameObject BolaAssociada;
    [SerializeField] private Animation animacaoChute;

    public Transform pontoChute; // setar com clique na tela

    public float ForcaChute; // atributo de personagem

    public static event Action<Chutador ,Transform, float> OnChute; // fazer tocar animacao de chute tambem
    
    public void Chutar()
    {
        //Forca = 10;

        if(BolaAssociada == null)
        {
            return;
        }


        OnChute?.Invoke(this,pontoChute, ForcaChute);

        BolaAssociada = null;
    }

    public void ReceberBola(GameObject bola)
    {
        BolaAssociada = bola;
    }
}
