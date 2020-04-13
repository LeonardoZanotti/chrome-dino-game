using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject GameStart;        // gameobject start
    public GameObject GameOver;     // gameobject gameover
    public GameObject DinoRun;
    public GameObject DinoDown;
    public GameObject pter;
    public GameObject cacto;
    public Text score;              // text score pra marcar os pontos
    public Text maxscore;           // text maxscore pra marcar o maior score obtido

    void Start() {
        pter.SetActive(false);
        cacto.SetActive(false);
        GameStart.SetActive(true);
    }

    void Update() {
        if(!GameOver.activeSelf && !DinoDown.activeSelf && (transform.localPosition.y < 0.52) && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))) {     // se a tecla pra cima ou a barra de espaço for clicado
            GameStart.SetActive(false);
            DinoRun.SetActive(true);
            pter.SetActive(true);
            cacto.SetActive(true);
            Time.timeScale = 1;
        }
    }
    
    public void RestartGame() {     // botão de reiniciar o game
        SceneManager.LoadScene(0);      // carrega a cena 0 -> só há uma cena no game que fica na posição 0
        DinoRun.SetActive(false);
        pter.SetActive(false);
        cacto.SetActive(false);
        Time.timeScale = 1;
    }
}
