using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //propriedades/dados da classe
    public static int score = 0; //score do jogo
    public static float timer = 0f; //vida do player

    //propriedades/dados do objeto
    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;

    //PROPRIEDADES DA HUD
    [SerializeField, Tooltip("Informe o score na HUD")]
    private TMP_Text hudScore;
    [SerializeField, Tooltip("Informe o timer na HUD")]
    private TMP_Text hudTimer;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        UpdateHud();

        //diminuir o tempo de jogo
        timer -= Time.deltaTime;
    }

    private void StartGame()
    {
        //tempo que o player poderá jogar
        GameManager.timer = 50;
        //inicia o spawn dos targets (itens)
        StartCoroutine(SpawnTargets());
        //zera o score
        GameManager.score = 0;
    }

    private void UpdateHud()
    {
        if (hudScore != null) hudScore.text = "Score: " + GameManager.score;
        if (hudTimer != null)
        {
            hudTimer.text = GameManager.timer > 0 ? "Timer: " + (int)GameManager.timer : "Timer: " + 0;
        }
    }

    private IEnumerator SpawnTargets() 
    {
        //enquanto tiver tempo spawn targets
        while (GameManager.timer > 0)
        {
            yield return new WaitForSeconds(1f);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
