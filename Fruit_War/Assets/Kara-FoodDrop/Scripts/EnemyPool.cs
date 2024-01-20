using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPrefabs = default;

    Vector2 enemyPosition;
    float poolSize = 3;
    GameObject newEnemy;
    GameObject enemy;
    private System.Random randomGenerator = new System.Random();
    List<GameObject> enemyPool = new List<GameObject>();
    float maxWidth = 2.0f;
    float minWidth = -2.0f;
    float minTimeBetweenFalls = 1.5f;
    float maxTimeBetweenFalls = 2.0f;
    void Start()
    {
        InitializeEnemyPool();
        StartCoroutine(DropEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeEnemyPool()
    {
        for (int i = 0; i <poolSize; i++)
        {
            int randomEnemyIndex = randomGenerator.Next(0, enemyPrefabs.Length);
            GameObject selectedEnemyPrefabs = enemyPrefabs[randomEnemyIndex];
            newEnemy = Instantiate(selectedEnemyPrefabs, Vector3.zero, Quaternion.identity,transform);
            newEnemy.SetActive(false); // Ba�lang��ta meyveleri devre d��� b�rak
            enemyPool.Add(newEnemy);
        }
        
    }
     void EnemyProduce()
    {
        float heightY = ScreenCalculators.instance.Height + Camera.main.transform.position.y;//!!!!
        if (enemy!= null)
        {
            EnemyDestroy(enemy); // E�er bir enemy nesnesi varsa, �nceki enemyi havuza geri koy
        }
        if (enemyPool.Count > 0)
        {
            GameObject newEnemy = enemyPool[0];
            enemyPool.RemoveAt(0);// havuzdaki enemyi sil. di�er enemyler kullan�ls�n diye . yoksa di�er enemyler kullan�lmaz ve ayn� enemy tekrarlanor

            float randomX =Random.Range(minWidth, maxWidth);
            enemyPosition = new Vector2(randomX, heightY);

            newEnemy.transform.position = enemyPosition;
            newEnemy.SetActive(true);
            enemy = newEnemy;


        }
    }
    void EnemyDestroy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Add(enemy);
    }
    IEnumerator DropEnemy()
    {
        while (true)
        {
            // Rastgele bir zaman aral��� se�
            float timeBetweenFalls = Random.Range(minTimeBetweenFalls, maxTimeBetweenFalls);

            // Bekleme i�lemi
            yield return new WaitForSeconds(timeBetweenFalls);

            // Meyve olu�tur ve d���r
            EnemyProduce();


        }
    }

}
