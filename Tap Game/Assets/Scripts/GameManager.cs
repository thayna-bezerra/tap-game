using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //propriedades/dados da classe
    public static int score = 0;

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
    }

    private void StartGame()
    {
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
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
