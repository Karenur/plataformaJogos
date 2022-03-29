using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle4x : MonoBehaviour
{

    Animator animacao;
    Rigidbody2D fisica;

    public float velocidade;


    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Animator>();
        fisica = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float taApetandoH = Input.GetAxisRaw("Horizontal");
        float taApertandoV = Input.GetAxisRaw("Vertical");
        
        if (taApetandoH != 0)
        {
            fisica.velocity = new Vector2(taApetandoH * velocidade, 0);
            if (taApetandoH > 0)
            {
                animacao.SetBool("up", false);
                animacao.SetBool("right", false);
                animacao.SetBool("left", true);
                animacao.SetBool("down", false);
            }
            if (taApetandoH < 0)
            {
                animacao.SetBool("up", false);
                animacao.SetBool("right", true);
                animacao.SetBool("left", false);
                animacao.SetBool("down", false);
            }
        }
        else if (taApertandoV != 0)
        {
            fisica.velocity = new Vector2(0, taApertandoV * velocidade);
            if (taApertandoV > 0)
            {
                animacao.SetBool("up", true);
                animacao.SetBool("right", false);
                animacao.SetBool("left", false);
                animacao.SetBool("down", false);
            }
            if (taApertandoV < 0)
            {              
                animacao.SetBool("up", false);
                animacao.SetBool("right", false);
                animacao.SetBool("left", false);
                animacao.SetBool("down", true);
            }
        }
        else
        {
            fisica.velocity = new Vector2(0, 0);
            animacao.SetBool("up", false);
            animacao.SetBool("right", false);
            animacao.SetBool("left", false);
            animacao.SetBool("down", false);
        }
    }


   


}
