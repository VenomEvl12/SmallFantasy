using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public LayerMask enemyLayer;
    private int radiusSpawner = 5;
    public Transform[] locations;
    public GameObject enemy;
    private readonly bool[] enemySpawn = new bool[] { false, false };

    private void Start()
    {
        locations[0] = GameObject.Find("EnemySpawner").transform;
        locations[1] = GameObject.Find("EnemySpawner2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(gameObject.transform.position, radiusSpawner, enemyLayer);
        Collider2D[] collider2 = Physics2D.OverlapCircleAll(locations[1].position, radiusSpawner, enemyLayer);
        if(collider.Length == 0)
        {
            if(enemySpawn[0] == false)
            {
                StartCoroutine(SpawnTime(0));
            }
        }
        if (collider2.Length == 0)
        {
            if (enemySpawn[1] == false)
            {
                StartCoroutine(SpawnTime(1));
            }
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(gameObject.transform.position, radiusSpawner);
    }

     private IEnumerator SpawnTime(int location)
    {
        enemySpawn[location] = true;
        yield return new WaitForSeconds(3f);
        Instantiate(enemy, locations[location].position, locations[location].rotation);
        enemySpawn[location] = false;
    }
}
