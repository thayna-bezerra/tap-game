using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //propriedades/dados da classe
    public static int score = 0;

    //propriedades/dados do objeto
    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;
     
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        Debug.Log(GameManager.score);
    }

    private void StartGame()
    {
        //inicia o spawn dos targets (itens)
        StartCoroutine(SpawnTargets());
        //zera o score
        GameManager.score = 0;
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
