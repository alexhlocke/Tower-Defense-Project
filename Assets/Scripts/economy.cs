using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class economy : MonoBehaviour
{
    public int coins = 0;
    public GameObject coinsText;
    
    public void addCoins(int toBeAdded) {
        coins += toBeAdded;
        refreshCoinDisplay();
    } 

    public void subtractCoins(int toBeSubtracted) {
        coins -= toBeSubtracted;
        refreshCoinDisplay();
    }

    public void resetCoins() {
        coins = 0;
        refreshCoinDisplay();
    }

    private void refreshCoinDisplay() {
        coinsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + coins;
    }
}
