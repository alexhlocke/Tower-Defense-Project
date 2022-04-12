using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class economy : MonoBehaviour
{
    public int coins = 5;
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
    
    public int getCoins() {
        return coins;
    }

    private void refreshCoinDisplay() {
        coinsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + coins;
    }
}
