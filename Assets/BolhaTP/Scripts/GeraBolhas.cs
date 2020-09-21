using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraBolhas : MonoBehaviour
{
    public Controlador control;
    public GameObject Bolhas;
    public float Tamanho = 9f;

    void Start()
    {
        Gerar();
    }
    void Gerar()
    {
        if (!control.GetMorto())
        {
            int Quantidade = Random.Range(2, 6);
            for (int i = 0; i < Quantidade; i++)
            {
                Instantiate(Bolhas, new Vector3(transform.position.x + (Random.Range(-Tamanho, Tamanho)), transform.position.y, transform.position.z), Quaternion.identity);
            }

            Invoke("Gerar", Random.Range(1f, 3f));
        }
    }
}
