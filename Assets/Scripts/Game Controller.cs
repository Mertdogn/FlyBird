using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;
    public bool gameOver;

    public void birdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1) && gameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Time.timeScale = 1;
        }
    }

}
