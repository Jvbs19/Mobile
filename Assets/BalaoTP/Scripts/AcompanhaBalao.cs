using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcompanhaBalao : MonoBehaviour
{
    public GameObject Balao;
    public bool cam = false, gerador = false;
    void Update()
    {
        if (Balao != null)
        {
            if (cam)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Balao.transform.position.y + 3f, gameObject.transform.position.z);
            }
            if (gerador)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Balao.transform.position.y + 20f, gameObject.transform.position.z);
            }
            if (!cam && !gerador)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Balao.transform.position.y, gameObject.transform.position.z);
            }
        }
    }
}
