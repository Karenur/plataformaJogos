using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleNavinha : MonoBehaviour
{

    [SerializeField] float velocidadeNave = 5;

     


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoY = Input.GetAxis("Vertical");

        Vector3 novoMovimento = new Vector3(movimentoX,movimentoY,0);
        Vector3 porcentagem = Camera.main.WorldToViewportPoint(transform.position);
        
        if (porcentagem.x <= 1 && porcentagem.x >= 0 && porcentagem.y <= 1 && porcentagem.y >= 0)
        {
            transform.Translate(Time.deltaTime * velocidadeNave * novoMovimento);
        }
        else
        {
            transform.position = new Vector3(0, -4, 0);
        }
    }

}
