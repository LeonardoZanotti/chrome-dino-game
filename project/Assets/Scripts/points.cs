using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    public float timer = 0f;        // timer como float
    public float maxtimer = 0f;
    public float pontos = 0f;
    public float growspeed = 1f;
    public GameController controller;   // gamecontroller definido na variável controller
    public GameObject DinoRun;
    public GameObject DinoDown;
    public GameObject GameOver;

    void Start() {
        controller.maxscore.text = PlayerPrefs.GetInt("MaxPoints", 0).ToString();   // o texto de maxscore é os pontos armazenados ou se n tiver nada é 0
    }

    // Update is called once per frame
    void Update()
    {
        if(DinoRun.activeSelf || DinoDown.activeSelf) {
            timer += Time.deltaTime;
            pontos += Time.deltaTime * growspeed;    // timer é a passagem de tempo mesmo
            controller.score.text = ((int)(pontos)).ToString();        // o text definido no gamecontroller recebe o time como string, formatado como float ("F")
        }

        if(timer > maxtimer) {
            growspeed = growspeed * 2;
            timer = 0f;
        }

        if(GameOver.activeSelf) {
            if(pontos > PlayerPrefs.GetInt("MaxPoints", 0)) {   // se os pontos forem maiores que os pontos já armazenados (ou 0 se n tiver nada)
                PlayerPrefs.SetInt("MaxPoints", ((int)(pontos)));   // armazena os pontos obtidos como inteiros na string "MaxPoints" numa memória do player
            }
        }
    }
}
