using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }     
    }

}
