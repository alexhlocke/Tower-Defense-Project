using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 50;
    public GameObject healthText;

    public void loseHealth() {
        health -= 5;
        refreshHealthDisplay();
        if (health <= 0) {
            gameover();
        }
    }

    private void gameover() {
        Time.timeScale = 0f;
        FindObjectOfType<RestartLogic>().showRestartMenu();
    }

    private void refreshHealthDisplay() {
        healthText.GetComponent<TMPro.TextMeshProUGUI>().text = "Health: " + health;
    }
}
