using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpawning : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public bool selecting = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject point in spawnPoints) {
            point.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (selecting == true)
                selecting = false;
            else 
                selecting = true;
            showSelections();
        }
    }

    private void showSelections() {
        if (selecting == true) {
            foreach (GameObject point in spawnPoints) {
                point.SetActive(true);
            }
        } else {
            foreach (GameObject point in spawnPoints) {
                point.SetActive(false);
            }
        }
    }
}
