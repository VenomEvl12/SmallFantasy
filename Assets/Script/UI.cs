using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject level;
    // Start is called before the first frame update
    void Start()
    {
        level.GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<HeroAttribute>().GetLevel().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
