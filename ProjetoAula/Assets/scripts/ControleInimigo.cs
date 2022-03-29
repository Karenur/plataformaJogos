using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigo : MonoBehaviour
{
    Rigidbody2D fisica;
    Animator animacao;
    public Transform[] caminho;

    public int pontoAtual = 0;
    public float velocidade = 5;

    public float distanciaAceitavel = 1;

    public Vector2 direcao;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direcao = caminho[pontoAtual].position - transform.position;
        float distancia = Vector2.Distance(transform.position, caminho[pontoAtual].position);

        if(distancia <= distanciaAceitavel)
        {
            pontoAtual++;
            if (pontoAtual >= caminho.Length)
            {
                pontoAtual = 0;
            }
        }
        



        direcao.Normalize();
        
        fisica.velocity = direcao * velocidade;








        if (direcao.x > 0.5f)
        {
            animacao.SetBool("cima", false);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("direita", true);
            animacao.SetBool("baixo", false);
        }
        if (direcao.x < -0.5f)
        {
            animacao.SetBool("cima", false);
            animacao.SetBool("esquerda", true);
            animacao.SetBool("direita", false);
            animacao.SetBool("baixo", false);
        }
        if (direcao.y > 0.5f)
        {
            animacao.SetBool("cima", true);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("direita", false);
            animacao.SetBool("baixo", false);
        }
        if (direcao.y < -0.5f )
        {
            animacao.SetBool("cima", false);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("direita", false);
            animacao.SetBool("baixo", true);
        }

    }
}
