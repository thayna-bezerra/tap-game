using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;

    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    void Update()
    {
        
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
