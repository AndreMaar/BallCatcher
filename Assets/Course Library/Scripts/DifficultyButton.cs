using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button button;
    private Main main;
    private GameObject gameName;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameName = GameObject.Find("GameName");
        main = GameObject.Find("GameManager").GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        gameName.gameObject.SetActive(false);
        switch(gameObject.name)
        {
            case "Easy":
                main.minSpawnTime += 1;
                main.maxSpawnTime += 2;
                break;
            case "Medium":
                main.minSpawnTime -= 0;
                main.maxSpawnTime -= 0;
                break;
            case "Hard":
                main.minSpawnTime -= 0.5f;
                main.maxSpawnTime -= 2;
                break;
        }
        main.StartGame();


    }
}
