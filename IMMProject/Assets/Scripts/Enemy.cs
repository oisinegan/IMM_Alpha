using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private float enemyHealth = 25f;

   

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.freezeRotation = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed,ForceMode.Acceleration);
    }

    //Detect when bullet hits enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            enemyHealth -= 25;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(other);
            }
        }
    }
}
