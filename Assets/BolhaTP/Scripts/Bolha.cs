using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolha : MonoBehaviour
{
    float Velocidade;
    float Tamanho;
    float Squish;
    void Start()
    {
        Velocidade = Random.Range(1f, 3f);
        Tamanho = Random.Range(1f, 2f);
        transform.localScale = new Vector3(Tamanho, Tamanho, Tamanho);
    }

    void FixedUpdate()
    {

        Squish = Random.Range(0.1f, 0.3f);
        transform.Translate(new Vector3(0, Velocidade * Time.fixedDeltaTime, 0));
        float BolhaAnim = Mathf.PingPong(Time.fixedDeltaTime * (30 * Squish), 0.3f);
        transform.localScale = new Vector3(Tamanho + BolhaAnim, Tamanho + BolhaAnim, Tamanho + BolhaAnim);

    }
}
