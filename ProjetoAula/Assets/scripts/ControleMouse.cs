using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMouse : MonoBehaviour
{





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //so se o jogador clicou com o botao esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posicaoMouse = Input.mousePosition;
            posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);
            transform.position = posicaoMouse;
        }
    }
}
