using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    private NavMeshAgent nav;


    void Awake ()
    {
        this.player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        this.nav = GetComponent <NavMeshAgent> ();
    }
    

    void Update ()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            this.nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
