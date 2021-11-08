using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPortal : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 location;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.2f);
        player.transform.position = location;
    }
}
