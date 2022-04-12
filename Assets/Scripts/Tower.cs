using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function was made largely with a very usefull brackeys tutorial
    void FindTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestTarget = null;
        float shortestDistance = Mathf.Infinity;
        
        //Find closest enemy
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = (float)Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                closestTarget = enemy; 
            }
        }

        //If closest enemy exist and is in range target it
        if (closestTarget != null && shortestDistance <= range) {
            target = closestTarget;

            //Damage enemy
            target.GetComponent<enemy>().takeDamage(2);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
