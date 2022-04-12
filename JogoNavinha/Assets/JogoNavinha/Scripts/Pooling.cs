using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{

    [SerializeField] List<GameObject> listaDeObjetos;
    [SerializeField] GameObject objetoPrefab;
    [SerializeField] int quandidadeInicial = 20;

    [SerializeField] bool vaiAdicionar = true;


    // Start is called before the first frame update
    void Start()
    {
        listaDeObjetos = new List<GameObject>();
        for (int i = 0; i < quandidadeInicial; i++)
        {
            GameObject novoTiro = Instantiate(objetoPrefab);
            listaDeObjetos.Add(novoTiro);
            novoTiro.SetActive(false);

        }
    }

    public GameObject EncontraObjetoPraMim()
    {
        for (int i = 0; i < listaDeObjetos.Count; i++)
        {
            if (!listaDeObjetos[i].activeInHierarchy)
            {
                return listaDeObjetos[i];
            }            
        }

        if(vaiAdicionar)
        {
            GameObject novoTiro = Instantiate(objetoPrefab);
            listaDeObjetos.Add(novoTiro);
            return novoTiro;
        }




        return null;
    }
}
