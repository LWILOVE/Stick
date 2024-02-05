using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinH : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinH")
        {
            GameObject.Find("GameManager").GetComponent<GameManagerX>().GameOver();
        }
    }
}
