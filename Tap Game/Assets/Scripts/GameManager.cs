using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //propriedades/dados da classe
    public static int score = 0; //score do jogo
    public static string nickname = "";
    public static int highScore = 0; //score do jogo
    public static string nicknameHighScore = "Tap Game";
    public static float timer = 0f; //vida do player

    //banco de dados na web
    public static User player;
    public static User playerHighScore;

    //metodos da classe

    //pega os dados do jogador
    public static async void GetPlayer(string nick)
    {
        player = await ServiceAPI.GetUser(nick);
    }

    //pega os dados do jogador com a maior pontuacao
    public static async void GetPlayerHighScore()
    {
        playerHighScore = await ServiceAPI.GetUser();
        if(playerHighScore != null)
        {
            highScore = playerHighScore.score;
            nicknameHighScore = playerHighScore.nick;
        }
    }

    //grava os dados jogador no banco de dados
    public static async void SetScore()
    {
        ServiceAPI.SetScore(nickname, score);
    }


    //propriedades/dados do objeto
    [SerializeField, Tooltip("Define os itens do jogo")]
    private List<GameObject> targets;
    private int qtdTargets = 0; //quantidade de targets para criar
    private float timeToSpawn = 0; //quantidade tempo de spawn dos targets

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
        if (timer <= 0)
        {
            //GoGameOver();
            Invoke("GoGameOver", 1);
        }
    }

    private void StartGame()
    {
        //tempo que o player poder� jogar
        GameManager.timer = 20;
        //qtd de targts
        qtdTargets = 1;
        //tempo de spawn
        timeToSpawn = 1.5f;
        //inicia o spawn dos targets (itens)
        StartCoroutine(SpawnTargets());
        StartCoroutine(ChangeDifficulty());
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
            //tempo de espera
            yield return new WaitForSeconds(timeToSpawn);

            //spawn targets
            for (int i = 1; i <= qtdTargets; i++)
            {
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }
    }

    private IEnumerator ChangeDifficulty()
    {
        //enquanto tiver tempo spawn targets
        while (timeToSpawn > 1)
        {
            //tempo de espera
            yield return new WaitForSeconds(20);
            timeToSpawn -= 0.1f; //diminui o tempo de spawn
            qtdTargets += 1; //incrementa a quantidade de targets que ser�o criados
        }
    }

    private void GoGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
