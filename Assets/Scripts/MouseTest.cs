using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    public Transform enemySpawn;
    public GameObject enemyPrefab;
    public GameObject towerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
                //Debug.Log("hit " + hitInfo.transform.name);
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    //FindObjectOfType<economy>().addCoins(2);
                    hitInfo.transform.gameObject.GetComponent<enemy>().takeDamage(5);
                }
                if (hitInfo.transform.CompareTag("TowerSpawn")) {
                    spawnTower(hitInfo.transform);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            var tempObject = Instantiate(enemyPrefab);
            tempObject.transform.position = enemySpawn.position;
        }
    }

    void spawnTower(Transform spawnPoint) {
        if (FindObjectOfType<economy>().getCoins() > 4) {
            var newTower = Instantiate(towerPrefab);
            Vector3 newSpawnPos = spawnPoint.position;
            newSpawnPos.y += 0.6f;
            newTower.transform.position = newSpawnPos;
            FindObjectOfType<economy>().subtractCoins(4);
        } else {
            Debug.Log("Not enough coins to build");
        }
    }
}
