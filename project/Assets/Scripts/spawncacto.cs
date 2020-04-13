using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncacto : MonoBehaviour
{
    public GameObject cacto;   // gameobject cacto
    public float height = 1.3f;        // variação
    public float maxtime = 5f;      // vai fazer os cactos spawnarem a cada 5 segundo
    public float maxtime2 = 10f;

    private float timer = 0f;       // usar o f depois do valor é para definir que é float mesmo, se n, podia interpretar como double ou decimal
    private float timer2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newcacto = Instantiate(cacto);     // cria cópias do gameobject cacto
        newcacto.transform.position += new Vector3(Random.Range(-height, height), 0, 0);     // as posições desse novo objeto newcacto (transform.position) vai ser a posição inicial do primeiro conjunto de cactos (transform.position daquele gameobject cactos lá da unity) mais uma variação no eixo x entre mais height ou menos height (Random.Range sorteia um valor entre +height e - height), sendo que nada muda no eixo y e z
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxtime) {       // se o timer for maior que o tempo máximo definido, outro cacto vai spawnar
            GameObject newcacto = Instantiate(cacto);     // cria cópias do gameobject cacto
            newcacto.transform.position += new Vector3(Random.Range(-height, height), 0, 0);     // as posições desse novo objeto newcacto (transform.position) vai ser a posição inicial do primeiro conjunto de cactos (transform.position daquele gameobject cactos lá da unity) mais uma variação no eixo x entre mais height ou menos height (Random.Range sorteia um valor entre +height e - height), sendo que nada muda no eixo y e z
            Destroy(newcacto, 20f);      // depois de 20 segundos o picolé é destruido pra n sobrecarregar o jogo
            timer = 0;  // reiniciar o timer
        }

        timer += Time.deltaTime;    // função que calcula o tempo que passou, então a cada novo loading o timer vai sendo atualizado em tempo real

        if(maxtime > 1) {
            if(timer2 > maxtime2) {     // quando timer2 contar 10 segundos (maxtimer2)
                maxtime -= 0.1f;        // maxtime de spawn de cacto diminui 0.1s
                maxtime2 += 2;          // maxtime2 pra contar isso aumenta 2 segundos
                height += 0.02f;         // altura vai aumentando, então os cactos vem com alturas mais variadas          
                timer2 = 0;             // reiniciar o timer2
            }
        }
        
        timer2 += Time.deltaTime;   // timer2 é o tempo real 
    }
}
