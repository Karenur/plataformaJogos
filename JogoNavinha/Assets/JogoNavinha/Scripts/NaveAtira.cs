using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAtira : MonoBehaviour
{
    [SerializeField] Pooling poolingTiro;
    [SerializeField] float cadenciaDeTiro = 0.2f;
      

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("apertei");
            Atirar();

        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            CancelInvoke();
        }
        
    }

    void Atirar()
    {
        GameObject tiroDisponivel = poolingTiro.EncontraObjetoPraMim();
        if(tiroDisponivel != null)
        {
            tiroDisponivel.transform.position = transform.position;
            tiroDisponivel.SetActive(true);
        }
        

        //Instantiate(tiroPrefab,transform.position,transform.rotation);
        Invoke("Atirar", cadenciaDeTiro);
    }

    


}
