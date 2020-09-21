using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaVida : MonoBehaviour
{
    public Controlador control;
    public Image Vida;
    float MaxVida = 5;

    void Update()
    {
       Vida.fillAmount = control.GetVidas() /MaxVida;
    }
}
