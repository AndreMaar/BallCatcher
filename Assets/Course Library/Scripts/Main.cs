using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject[] goodObjects;
    public GameObject badObject;
    public float maxSpawnTime = 3;
    public float minSpawnTime = 1;
    private float spawnInterval;
    private float badSpawnInterval;
    public float maxSpawnPos = 4.5f;
    public float minSpawnPos = -4.5f;
    private float spawnPos;
    private int ball;

    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button resetButton;

    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval = Randomize(maxSpawnTime, minSpawnTime);
        spawnInterval = Randomize(maxSpawnTime, minSpawnTime);
    }

    float Randomize(float max, float min)
    {
        float res = Random.Range(min, max);
        return res;
    }

    void Spawn()
    {
        if (isGameActive == true)
        {
            ball = Random.Range(0, goodObjects.Length);
            spawnPos = Randomize(maxSpawnPos, minSpawnPos);

            Instantiate(goodObjects[ball], new Vector3(spawnPos, -1.2f, 0), goodObjects[ball].transform.rotation);
        }
    }

    public void UpdateScore(int a)
    {
        score += a;
        scoreText.text = "Score: " + score;
    }
    void SpawnBad()
    {
        if(isGameActive == true)
        {
            spawnPos = Randomize(maxSpawnPos, minSpawnPos);
            Instantiate(badObject, new Vector3(spawnPos, -1.2f, 0), badObject.transform.rotation);
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;

        spawnInterval = Randomize(maxSpawnTime, minSpawnTime);
        badSpawnInterval = Randomize(maxSpawnTime + 5, minSpawnTime + 8);

        InvokeRepeating("Spawn", 2, spawnInterval);
        InvokeRepeating("SpawnBad", 5, badSpawnInterval);

        scoreText.text = "Score: " + score;
    }
}
