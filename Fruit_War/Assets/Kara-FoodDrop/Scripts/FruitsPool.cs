using UnityEngine;

using System.Collections.Generic;
using System.Collections;
using System;
using Unity.Mathematics;
using UnityEngine.UIElements;

public class FruitsPool : MonoBehaviour
{
    [SerializeField]
    GameObject[] fruitsPrefab = default;
   
    Vector2 fruitsPosition;
    GameObject newFruit;
    GameObject fruit;
   
    private System.Random randomGenerator = new System.Random();





    List<GameObject> fruitPool = new List<GameObject>();
    int poolSize = 7; // Havuzda bulunmas� gereken meyve say�s�
    float maxWidth = 2.0f;
    float minWidth =-2.0f;
    

    float minTimeBetweenFalls = 1.5f;
    float maxTimeBetweenFalls = 2.0f;

    void Start()
    {

       
        InitializeFruitPool();
        StartCoroutine(DropFruits());
       

    }

    void InitializeFruitPool()
    {
        // fruits object pooling
        for (int i = 0; i < poolSize; i++)
        {
            int randomFruitIndex = randomGenerator.Next(0, fruitsPrefab.Length);
            GameObject selectedFruitPrefab = fruitsPrefab[randomFruitIndex];
             newFruit = Instantiate(selectedFruitPrefab, Vector3.zero, Quaternion.identity,transform);
            newFruit.SetActive(false); // Ba�lang��ta meyveleri devre d��� b�rak
            fruitPool.Add(newFruit);
        }
    }
    void FruitsProduce()
    {
        float heightY = ScreenCalculators.instance.Height + Camera.main.transform.position.y;//!!!!
        if (fruit != null)
        {
            FruitsDestroy(fruit); // E�er bir meyve nesnesi varsa, �nceki meyveyi havuza geri koy
        }
        if (fruitPool.Count > 0)
        {
            GameObject newFruit = fruitPool[0];
            fruitPool.RemoveAt(0);// havuzdaki meyveyi sil. di�er meyveler kullan�ls�n diye 

            float randomX = UnityEngine.Random.Range(minWidth, maxWidth);
            fruitsPosition = new Vector2(randomX, heightY);

            newFruit.transform.position = fruitsPosition;
            newFruit.SetActive(true);
            fruit = newFruit;


        }
    }
    void FruitsDestroy(GameObject fruit)
    {
        // Meyveyi devre d��� b�rak ve havuza geri koy
        fruit.SetActive(false);
        fruitPool.Add(fruit);
    }
    IEnumerator DropFruits()
    {
        while (true)
        {
            // Rastgele bir zaman aral��� se�
            float timeBetweenFalls = UnityEngine.Random.Range(minTimeBetweenFalls, maxTimeBetweenFalls);

            // Bekleme i�lemi
            yield return new WaitForSeconds(timeBetweenFalls);

            // Meyve olu�tur ve d���r
            FruitsProduce();

            
        }
    }
   







}



