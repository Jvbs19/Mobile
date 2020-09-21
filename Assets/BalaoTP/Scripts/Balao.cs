using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Balao : MonoBehaviour
{
    public bool Vivo = true;
    float direcao;
    public float VelSubida =5, VelLateral =10, Rotacao=5;
    public float pontuacao;
    public Text ControlaPontuacao;
    float velMax = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AumentaVelocidade", 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Controles();
    }
    private void Update()
    {
        if(VelSubida >= velMax)
        {
            VelSubida = velMax;
        }
    }
    void Controles()
    {

        if (Vivo == true)
        {


#if UNITY_EDITOR


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direcao = -1f;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direcao = 1f;

            }
            else
            {
                direcao = 0f;
            }

            transform.Translate(new Vector3(VelLateral * direcao, VelSubida, 0) * Time.fixedDeltaTime);

#endif

#if UNITY_ANDROIDE

        multiplicador = Input.acceleration.x;
            
            Balao.transform.Translate(new Vector3(VelocidadeLateral * multiplicador*2, VelocidadeSubida, 0) * Time.deltaTime);

#endif
            if (direcao > 0.1f || direcao < -0.1f)
            {
                if (transform.localRotation.z < 50f && transform.localRotation.z > -50f)
                {
                    transform.Rotate(new Vector3(0, 0, -direcao * Rotacao) * Time.fixedDeltaTime);
                }
            }
            else
            {
                if (transform.rotation.z < 0.01f && transform.rotation.z > -0.01f)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                }
                else if (transform.rotation.z > 0f)
                {
                    transform.Rotate(new Vector3(0, 0, -Rotacao * 2) * Time.fixedDeltaTime);

                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, Rotacao * 4) * Time.fixedDeltaTime);
                }

            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Parede"))
        {
            Vivo = false;
           
            Invoke("ReIniciaCena", 3f);
        }

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Parede"))
        {
            Vivo = false;

            Invoke("ReIniciaCena", 3f);
        }

    }
    void ReIniciaCena()
    {
        SceneManager.LoadScene("Balao", LoadSceneMode.Single);

    }
    void AumentaVelocidade()
    {
        if (Vivo == true)
        {
            pontuacao++;
            VelSubida += 0.2f;
            ControlaPontuacao.text = pontuacao.ToString();
            Invoke("AumentaVelocidade", 1f);
        }
    }
}
