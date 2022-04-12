using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLogic : MonoBehaviour
{
    public GameObject restartMenu;

    void Start()
    {
        restartMenu.SetActive(false);
    }

    public void showRestartMenu() {
        restartMenu.SetActive(true);
    }

    public void restartGame() {
        SceneManager.LoadScene("Main Menu");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
