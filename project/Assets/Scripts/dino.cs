using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rig;

    public GameObject GameOver;
    public GameObject GameStart;
    public GameObject DinoRun;
    public GameObject DinoDown;

    // Update is called once per frame
    void Update()
    {
        if(!GameOver.activeSelf && !DinoDown.activeSelf && (transform.localPosition.y < 0.52) && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))) {     // se a tecla pra cima ou a barra de espaço for clicado
            rig = GameObject.FindGameObjectWithTag("DinoRun").GetComponent<Rigidbody2D>();
            rig.velocity = Vector2.up * speed;  // a classe velocity do rigidbody vai sofrer aumento na velocidade na direção do Vector2.up que é pra cima
        }

        if(!GameOver.activeSelf && (Input.GetKeyDown(KeyCode.DownArrow))) {     // se a tecla pra cima ou a barra de espaço for clicado
            DinoDown.SetActive(true);
            GameObject.FindGameObjectWithTag("DinoDown").transform.position = GameObject.FindGameObjectWithTag("DinoRun").transform.position;
            DinoRun.SetActive(false);

            rig = GameObject.FindGameObjectWithTag("DinoDown").GetComponent<Rigidbody2D>();
            rig.velocity = Vector2.down * speed;  // a classe velocity do rigidbody vai sofrer aumento na velocidade na direção do Vector2.down que é pra baixo
        }

        if(!GameOver.activeSelf && (Input.GetKeyUp(KeyCode.DownArrow))) {
            DinoRun.SetActive(true);
            GameObject.FindGameObjectWithTag("DinoRun").transform.position = GameObject.FindGameObjectWithTag("DinoDown").transform.position;
            DinoDown.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D colisor) {      // quando o dino bater em qualquer parada ele aciona isso
        GameOver.SetActive(true);   // aquele gameobject gameover aparece
        Time.timeScale = 0;     // pausa o jogo pois a escala de tempo ta como 0, ou seja, o tempo n passa
    }
}
