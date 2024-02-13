using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //propriedades/dados da classe
    public static int score = 0; //score do jogo
    public static float time = 0f; //vida do player

    //propriedades/dados do objeto
    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;

    //PROPRIEDADES DA HUD
    [SerializeField, Tooltip("Informe o score na HUD")]
    private TMP_Text hudScore;
     
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        UpdateHud();

        //diminuir o tempo de jogo
        time -= Time.deltaTime;
        Debug.Log(time);
    }

    private void StartGame()
    {
        //tempo que o player poderá jogar
        GameManager.time = 50;
        //inicia o spawn dos targets (itens)
        StartCoroutine(SpawnTargets());
        //zera o score
        GameManager.score = 0;
    }

    private void UpdateHud()
    {
        hudScore.text = "Score: " + GameManager.score;
    }

    private IEnumerator SpawnTargets() 
    {
        //enquanto tiver tempo spawn targets
        while (GameManager.time > 0)
        {
            yield return new WaitForSeconds(1f);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
