using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreTextScript.coinAmout += 1;
        Destroy(gameObject);
        
    }

    
}
