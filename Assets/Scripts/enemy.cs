using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public int maxHealth = 20;
    public int health;
    public float movementSpeed;
    public Slider healthSlider;
    public GameObject waypointParent;
    public Transform[] waypoints; 
    public Transform endWaypoint;

    private int waypointIndex = 0;
    private Vector2 movementVec;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        // int i = 0;
        // foreach (Transform waypoint in waypointParent.transform) {
        //     if (!waypoint.gameObject.activeInHierarchy) {
        //         continue;
        //     }
        //     waypoints[i] = waypoint;
        //     Debug.Log("Put waypoint in space: " + i);
        //     i++;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = waypoints[waypointIndex].position - transform.position;
        direction.Normalize();
        movementVec = direction;
    }

    private void FixedUpdate() {
        moveEnemy(movementVec);
    }

    private void moveEnemy(Vector2 direction) {
        transform.position = ((Vector2)transform.position + (direction*movementSpeed*Time.deltaTime));
    }

    public void takeDamage(int hit) {
        health -= hit;
        //Debug.Log("Enemy HP: " + health);
        if (health <= 0) {
            FindObjectOfType<economy>().addCoins(5);
            Debug.Log("Enemy Killed");
            // Destroy(this.gameObject);
            die();
        }
        
        healthSlider.value = (float)health / (float)maxHealth;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Waypoint")) {
            if (waypointIndex >= (waypoints.Length-1)) {
                Destroy(this.gameObject);
            }
            waypointIndex++;
            //Debug.Log("Waypoint: " + waypointIndex);
        }
        if (waypointIndex > 3) {
            FindObjectOfType<HealthManager>().loseHealth();
            // Destroy(this.gameObject);
            die();
        }
    }

    private void die() {
        FindObjectOfType<AudioManager>().playSound("enemy death");
        Destroy(this.gameObject);
    }
}
