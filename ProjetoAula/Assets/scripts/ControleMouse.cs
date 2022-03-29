using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMouse : MonoBehaviour
{

    public Transform seguePonto;

    Rigidbody2D fisica;
    Animator animacao;

    public float velocidade = 5;

    public float distanciaAceitavel = 1;

    public Vector2 direcao;
    public float distancia;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        seguePonto.position = fisica.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //so se o jogador clicou com o botao esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posicaoMouse = Input.mousePosition;
            posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);
            seguePonto.transform.position = posicaoMouse;
        }
        distancia = Vector2.Distance(transform.position, seguePonto.position);
        direcao = seguePonto.position - transform.position;        

        direcao.Normalize();


             

       

        if (direcao.x > 0.5f)
        {
            animacao.SetBool("up", false);
            animacao.SetBool("right", false);
            animacao.SetBool("left", true);
            animacao.SetBool("down", false);
        }
        if (direcao.x < -0.5f)
        {
            animacao.SetBool("up", false);
            animacao.SetBool("right", true);
            animacao.SetBool("left", false);
            animacao.SetBool("down", false);
        }
        if (direcao.y > 0.5f)
        {
            animacao.SetBool("up", true);
            animacao.SetBool("right", false);
            animacao.SetBool("left", false);
            animacao.SetBool("down", false);
        }
        if (direcao.y < -0.5f)
        {
            animacao.SetBool("up", false);
            animacao.SetBool("right", false);
            animacao.SetBool("left", false);
            animacao.SetBool("down", true);
        }


        if (distancia <= distanciaAceitavel)
        {
            animacao.SetBool("up", false);
            animacao.SetBool("right", false);
            animacao.SetBool("left", false);
            animacao.SetBool("down", false);
            fisica.velocity = new Vector2(0, 0);
        }
        else
        {
            fisica.velocity = direcao * velocidade;
        }

    }
}
