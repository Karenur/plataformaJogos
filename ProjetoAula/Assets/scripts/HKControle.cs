using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HKControle : MonoBehaviour
{

    Rigidbody2D fisica;
    SpriteRenderer desenhista;
    Animator animacao;
    public CapsuleCollider2D colisorPe;
    public CapsuleCollider2D colisorLagarta;

    public Transform posPezim;
    public LayerMask oQueEhchao;

    public float velociade;
    float forcaPulo = 500;
    public float timeMimir = 0;
    public float raioPezim = 0.2f;
    bool estouNoChao;


    // Start is called before the first frame update
    void Start()
    {

        fisica = GetComponent<Rigidbody2D>();
        desenhista = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {

        float taApetando = Input.GetAxis("Horizontal");
        bool pulei = Input.GetKeyDown(KeyCode.Space);

        fisica.velocity = new Vector2(taApetando*velociade, fisica.velocity.y);

        //verificar se esta no chao
        
        if(Physics2D.OverlapCircle(posPezim.position, raioPezim, oQueEhchao) == null)
        {
            estouNoChao = false;
        }
        else
        {
            estouNoChao = true;
        }
        



        //pular
        if (pulei == true && estouNoChao == true)
        {
            fisica.AddForce(new Vector2(0, forcaPulo));
        }
        //flipar personagem
        if(taApetando < 0)
        {
            desenhista.flipX = true;
        }
        else if(taApetando >0)
        {
            desenhista.flipX = false;
        }

        //animacao
        if(taApetando == 0)
        {
            animacao.SetBool("walk", false);
            animacao.SetBool("idle", true);
            if (timeMimir <= 20 && fisica.velocity == new Vector2(0,0))
            {
                timeMimir += Time.deltaTime;
            }
            if (timeMimir >= 20)
            {
                animacao.SetBool("mimir",true);
            }

        }
        else
        {
            timeMimir = 0;
            animacao.SetBool("walk", true);
            animacao.SetBool("idle", false);
            animacao.SetBool("mimir", false);
        }


        //animacao Lagarta
        if(Input.GetKey(KeyCode.DownArrow) && estouNoChao == true)
        {
            animacao.SetBool("lagarta", true);
            velociade = 2;
            colisorLagarta.enabled = true;
            colisorPe.enabled = false;
        }
        else
        {
            animacao.SetBool("lagarta", false);
            velociade = 10;
            colisorLagarta.enabled = false;
            colisorPe.enabled = true;
        }
        

    }








}
