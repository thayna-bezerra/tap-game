using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class ServiceAPI
{
    //endereco da api
    const string URL = "https://tap-game.onrender.com";

    //objeto para interagir com a api
    public static HttpClient GetClient()
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("Connection", "close");
        return client;
    }

    //retorna um usuario com base no nickname
    public static async Task<User> GetUser(string nick)
    {
        HttpClient client = GetClient();
        var responsive = await client.GetAsync(URL + "user/" + nick);

        //pegou os dados da api?
        if (responsive.IsSuccessStatusCode == true)
        {
            string content = await responsive.Content.ReadAsStringAsync();
            return JsonUtility.FromJson<User>(content); 
        }
        return new User();
    }

    //retorna o usuario com a maior pontuação
    public static async Task<User> GetUser()
    {
        HttpClient client = GetClient();
        var responsive = await client.GetAsync(URL + "highscore");

        //pegou os dados da api?
        if (responsive.IsSuccessStatusCode == true)
        {
            string content = await responsive.Content.ReadAsStringAsync();
            return JsonUtility.FromJson<User>(content); // Substituição aqui
        }
        return new User();
    }

    public static async void SetScore(string nick, int score)
    {
        HttpClient client = GetClient();
        HttpContent content = null;
        await client.PutAsync(URL + "user/" + nick + "/score/" + score, content);
    }
}
