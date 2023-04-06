using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Track : MonoBehaviour
{
    public GameObject[]obstacles;
    public Vector2 numberObstacles;
    public List<GameObject> newObstacles;


    public GameObject coin;
    public Vector2 numberOfCoin;
    public List<GameObject> newCoins;
    





    void Start()
    {

        int newNumberOfCoins = (int) Random.Range(numberOfCoin.x, numberOfCoin.y);
        for (int i = 0; i < newNumberOfCoins; i++)
        {
            newCoins.Add(Instantiate(coin, transform));
            newCoins[i].SetActive(false);
        }
      
        int newberOBStacles = (int) Random.Range(numberObstacles.x, numberObstacles.y);
        for (int i = 0; i < newberOBStacles; i++)
        {
            newObstacles.Add(Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform));
            newObstacles[i].SetActive(false);
        }
     
       
        
        Postionobstacles();
        PostionoCoin();



    }

  

    // Update is called once per frame
    void Update()
    {
        
    }

    void Postionobstacles()
    {
        for (int i = 0; i < newObstacles.Count; i++)
        {
             
            float posMin = (194 / newObstacles.Count) + (194 / newObstacles.Count) * i;
            float posMax = (194 / newObstacles.Count) + (194 / newObstacles.Count) * i + 1;
            newObstacles[i].transform.localPosition = new Vector3(0, 0, Random.Range(posMin, posMax));
            if (newObstacles[i].GetComponent<CoinsLane>() != null)
            {
                newObstacles[i].GetComponent<CoinsLane>().postionLane();
            }
            newObstacles[i].SetActive(true);
        }
    }


    void PostionoCoin()
    {
        float minZPos = 10f;
        for (int i = 0; i < newCoins.Count; i++)
        {
            float maxZPos = minZPos + 5f;
            float randomZPos = Random.Range(minZPos, maxZPos);
            newCoins[i].transform.localPosition = new Vector3(transform.position.x, transform.position.y, randomZPos);
            newCoins[i].SetActive(true);
            newCoins[i].GetComponent<CoinsLane>().postionLane();
            minZPos = randomZPos + 1f;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = new Vector3(0, 0, transform.position.z + 194 * 2);
            Postionobstacles();
            PostionoCoin();
            FindObjectOfType<PlayerController>().speedPlayer += 6;

            // Invoke("Postionobstacles", 5f);
        }
      
    }
}
