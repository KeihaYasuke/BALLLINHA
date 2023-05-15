using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCommands : MonoBehaviour
{

    public int velocidade;                                                          // define a velocidade de movimenta��o
    private Rigidbody2D player;                                             // criar vari�vel para percebeer os componentes de f�sica
    public float forcaPulo;                                              //define a for�a do pulo


    public bool sensor;                                                 // sensor para verificar se est� colidindo com o ch�o
    public Transform posicaoSensor;                                     //posi��o onde o sensor ser� posicionado
    public LayerMask layerChao;                                         // camada de intera��o 
    
    
    void Start()
    {
        player = GetComponent<Rigidbody2D>(); 

    }

    
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(movimentoX * velocidade, player.velocity.y);

        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            player.AddForce(new Vector2(0, forcaPulo));
        }
    }

    private void FixedUpdate()
    { 
        //cria um sensor em posi��o com o raio e layer tambem definida
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);   

    }
}
