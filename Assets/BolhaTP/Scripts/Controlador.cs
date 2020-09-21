using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public Camera Camera;
    public LayerMask Layers;
    public float Pts;
    public Text PtsTexto;
    public Text Mensagem;
    public Text Ttimer;
    int Tempo = 20;
    float Vidas = 5;
    bool Morto = false;
    public Transform FinalTela;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ControlaTimer", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Controles();
        Vitoria();
        Derrota();
    }

    void Controles()
    {
        //CONTROLADORES----------------------------------------
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 50f, Layers))
            {
                Destroy(hit.collider.gameObject);
                Pts++;
                PtsTexto.text = Pts.ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 50f, Layers))
            {
                Destroy(hit.collider.gameObject);
                Pts++;
                PtsTexto.text = Pts.ToString();
            }
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount == 1)
        {

            Ray ray = Camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 50f, Layers))
            {
                Destroy(hit.collider.gameObject);
                Pts++;
                PtsTexto.text = Pts.ToString();
            }
        }
        if (Input.touchCount == 2)
        {

            Ray ray = Camera.ScreenPointToRay(Input.GetTouch(1).position);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 50f, Layers))
            {
                Destroy(hit.collider.gameObject);
                Pts++;
                PtsTexto.text = Pts.ToString();
            }
        }

#endif


    }
    void Vitoria()
    {
        if (Tempo <= 1)
        {
            Mensagem.text = "Vitoria";
            Invoke("Restart", 3f);

        }
    }
    void Restart()
    {
        SceneManager.LoadScene("Game");

    }
    void Derrota()
    {
        if (Tempo >= 1)
        {
            RaycastHit hitDerrota;
            if (Physics.Raycast(FinalTela.position, FinalTela.forward, out hitDerrota, 20f, Layers))
            {
                Destroy(hitDerrota.collider.gameObject);
                Vidas--;

            }
            if (Vidas <= 0)
            {
                Mensagem.text = "Derrota";
                Morto = true;
                Invoke("Restart", 5f);
            }
        }
    }
    public float GetVidas()
    {
        return Vidas;
    }
    public bool GetMorto()
    {
        return Morto;
    }
    void ControlaTimer()
    {
        if (Vidas > 0)
        {
            if (Tempo > 0)
            {
                Tempo--;
                Ttimer.text = Tempo.ToString();
                Invoke("ControlaTimer", 1);
            }
        }
    }
}
