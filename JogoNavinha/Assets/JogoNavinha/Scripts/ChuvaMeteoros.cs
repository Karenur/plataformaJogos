using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuvaMeteoros : MonoBehaviour
{
    [SerializeField] Transform pontoA;
    [SerializeField] Transform pontoB;
    [SerializeField] GameObject meteoroGrande;
    [SerializeField] GameObject meteoroMedio;
    [SerializeField] GameObject meteoroPequeno;
    [SerializeField] float tempoSpawInicial;
    [SerializeField] List<GameObject> poolingMeteoroGrande;
    [SerializeField] List<GameObject> poolingMeteoroMedio;
    [SerializeField] List<GameObject> poolingMeteoroPequeno;
    [SerializeField] int quandidadeInicial = 20;
    [SerializeField] float tempoParaSpawnar;
    // Start is called before the first frame update
    void Start()
    {
        tempoParaSpawnar = tempoSpawInicial;
        poolingMeteoroGrande = new List<GameObject>();
        poolingMeteoroMedio = new List<GameObject>();
        poolingMeteoroPequeno = new List<GameObject>();

        for (int i = 0; i < quandidadeInicial; i++)
        {
            GameObject novoMeteoroGrande = Instantiate(meteoroGrande);
            poolingMeteoroGrande.Add(novoMeteoroGrande);
            novoMeteoroGrande.SetActive(false);
        }
        for (int i = 0; i < quandidadeInicial; i++)
        {
            GameObject novoMeteoroMedio = Instantiate(meteoroMedio);
            poolingMeteoroMedio.Add(novoMeteoroMedio);
            novoMeteoroMedio.SetActive(false);
        }
        for (int i = 0; i < quandidadeInicial; i++)
        {
            GameObject novoMeteoroPequeno = Instantiate(meteoroPequeno);
            poolingMeteoroPequeno.Add(novoMeteoroPequeno);
            novoMeteoroPequeno.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (tempoParaSpawnar <= 0)
        {
            tempoParaSpawnar = tempoSpawInicial;
            GameObject meteoroDisponivel;
            int escolheMeteoro = Random.Range(0, 3);
            if(escolheMeteoro == 0)
            {
                meteoroDisponivel = EncontraObjetoPraMim(0);
                meteoroDisponivel.transform.position = new Vector2(Random.Range(pontoA.position.x, pontoB.position.x), transform.position.y);
                meteoroDisponivel.SetActive(true);
            }
            if (escolheMeteoro == 1)
            {
                meteoroDisponivel = EncontraObjetoPraMim(1);
                meteoroDisponivel.transform.position = new Vector2(Random.Range(pontoA.position.x, pontoB.position.x), transform.position.y);
                meteoroDisponivel.SetActive(true);
            }
            if (escolheMeteoro == 2)
            {
                meteoroDisponivel = EncontraObjetoPraMim(2);
                meteoroDisponivel.transform.position = new Vector2(Random.Range(pontoA.position.x, pontoB.position.x), transform.position.y);
                meteoroDisponivel.SetActive(true);
            }           
        }
        else
        {
            tempoParaSpawnar -= Time.deltaTime;
        }
    }

    public GameObject EncontraObjetoPraMim(int escolheMeteoro_)
    {
        
        if(escolheMeteoro_ == 0)
        {
            for (int i = 0; i < poolingMeteoroGrande.Count; i++)
            {
                if (!poolingMeteoroGrande[i].activeInHierarchy)
                {
                    return poolingMeteoroGrande[i];
                }
            }
        }
        if (escolheMeteoro_ == 1)
        {
            for (int i = 0; i < poolingMeteoroMedio.Count; i++)
            {
                if (!poolingMeteoroMedio[i].activeInHierarchy)
                {
                    return poolingMeteoroMedio[i];
                }
            }
        }
        if (escolheMeteoro_ == 2)
        {
            for (int i = 0; i < poolingMeteoroPequeno.Count; i++)
            {
                if (!poolingMeteoroPequeno[i].activeInHierarchy)
                {
                    return poolingMeteoroPequeno[i];
                }
            }
        }
        return null;
    }

}
