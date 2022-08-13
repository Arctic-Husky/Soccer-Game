using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;

    public static event Action<Goleiro,float, float> OnChegouNoGoleiro;

    public float speed = 10.0f;

    //public bool PossuiFisica;
    private bool estaSendoChutado;

    private Vector3 direcaoDoChute;
    private float step;

    public float Potencia { get; private set; }
    // efeito

    private void Start()
    {
        Chutador.OnChute += SerChutado;
    }

    private void SerChutado(Chutador chutador, Transform pontoChute, float forca)
    {
        var step = speed * Time.deltaTime;

        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
        Potencia = forca;
        estaSendoChutado = true;
        direcaoDoChute = transform.position + (pontoChute.position - transform.position).normalized * 1000;
        this.step = step;

        //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direcaoDoChute.position, step);
    }

    private void deslocarAPosicao(Vector3 direcaoDoChute, float step)
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, direcaoDoChute, step);
    }

    void FixedUpdate()
    {
        if (estaSendoChutado)
        {
            deslocarAPosicao(direcaoDoChute, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        //var tempStep = step;

        //step = 0;

        var goleiro = other.GetComponent<Goleiro>();
        Debug.Log(goleiro);

        if(goleiro != null)
        {
            OnChegouNoGoleiro?.Invoke(goleiro, goleiro.ForcaCatch, Potencia);
        }
        
        /*other.enabled = false;

        if (goleiro != null)
        {
            if (goleiro.ForcaCatch >= Potencia)
            {
                Debug.Log("Parou o chute!");
                estaSendoChutado = false;
                Potencia = 0;
            }
            else
            {
                Debug.Log("Continuar chute");
                step = tempStep;
            }
        }*/
    }

    public void PararBola()
    {
        step = 0;
        estaSendoChutado = false;
    }
}
