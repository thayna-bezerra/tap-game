using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //velocidade dos objetos
    private float minSpeed = 14f;
    private float maxSpeed = 19f;
    private float maxTorque = 10f; //rota��o dos objetos

    //local que o objeto ser� spawnado
    private float xRange = 5f;
    private float ySpawnPos = -6f;

    //corpo do objeto
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    void Update()
    {
        
    }

    private Vector3 RandomForce() 
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
