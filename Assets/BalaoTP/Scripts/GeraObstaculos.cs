using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraObstaculos : MonoBehaviour
{
    public GameObject[] Obstaculos;
    public GameObject Balao;
    public int Dado = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Gerar", 2f);
    }

    void Gerar()
    {
        if (Balao != null)
        {
            if (Balao.GetComponent<Balao>().Vivo == true)
            {
                Dado = Random.Range(0, Obstaculos.Length);
                GameObject Obs = Instantiate(Obstaculos[Dado]);
                Obs.transform.position = this.transform.position;

                Destroy(Obs, 20f);
                Invoke("Gerar", 2f);
            }
        }
       
    }
}

