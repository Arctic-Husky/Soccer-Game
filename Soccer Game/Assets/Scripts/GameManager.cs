using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject bolaObjeto;

    public Bola Bola { get; private set; }

    private bool estaPausado;

    // outros managers

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        Bola = bolaObjeto.GetComponent<Bola>();

        // pegar referencia de outros managers

        Bola.OnChegouNoGoleiro += HandleGoalStruggle;
        Chutador.OnChute += HandleChute;
    }

    private void HandleChute(Chutador chutador, Transform direcaoBola, float forcaChute)
    {
        Animacao anim;
        anim.jogadorUm = chutador.gameObject;

        //associar jogadores
        //associar animacao

        //tocar animacao
    }

    private void HandleGoalStruggle(Goleiro goleiro, float forcaCatch, float potenciaBola)
    {
        bool pegou = false;

        PauseGame();

        if(goleiro.ForcaCatch >= potenciaBola)
        {
            // tocar animacao
            Debug.Log("Goleiro pegou bola");
            Bola.PararBola();
            goleiro.ReceberBola(bolaObjeto);
            pegou = true;
        }
        if (!pegou)
        {
            Debug.Log("Goleiro falhou");
            // tocar animacao
        }

        PauseGame();
    }

    public void PauseGame() // fazer um pause melhor pra escolha do goleiro de qual poder usar
    {
        if (!estaPausado)
        {
            Time.timeScale = 0f;
            Debug.Log("Jogo pausado!");
            estaPausado = true;
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("Jogo despausado!");
            estaPausado = false;
        }
    }
}
