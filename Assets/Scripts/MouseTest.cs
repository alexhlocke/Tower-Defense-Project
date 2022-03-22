using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    public Transform enemySpawn;
    public GameObject enemyPrefab;

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
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            var tempObject = Instantiate(enemyPrefab);
            tempObject.transform.position = enemySpawn.position;
        }
    }
}
