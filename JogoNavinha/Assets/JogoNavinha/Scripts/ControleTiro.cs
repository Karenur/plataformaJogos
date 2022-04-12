using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTiro : MonoBehaviour
{
    [SerializeField] float velocidade = 10;
    [SerializeField] Rigidbody2D fisica;
    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.velocity = new Vector2(0, velocidade);
        Vector3 porcentagem = Camera.main.WorldToViewportPoint(transform.position);
        if (porcentagem.y > 1)
        {
            MeDestroi();
        }

    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void MeDestroi()
    {
        gameObject.SetActive(false);
    }
}
