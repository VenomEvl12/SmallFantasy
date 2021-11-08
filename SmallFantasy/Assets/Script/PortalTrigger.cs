using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject portal;
    public Vector3 locationVisible, locationHide;

    public bool firstTime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        portal.transform.position = locationVisible;
 
        anim.SetTrigger("Open");
        anim.SetBool("Stop", false);
        anim.SetBool("Idle", true);
        if (firstTime)
        {
            anim.SetBool("Stop", true);
            portal.transform.position = locationHide;
            firstTime = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(StopPortal());
        anim.SetBool("Idle", false);
        anim.SetBool("Stop", true);
    }

    private IEnumerator StopPortal()
    {
        yield return new WaitForSeconds(0.5f);
        portal.transform.position = locationHide;
    }
}
