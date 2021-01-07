using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour
{
    public enum CoinFX
    {
        Vanish,
        Fly
    }

    public CoinFX coinFX;
    public float speed;
    public bool startFlying;

    GameObject coinMeter;

    void Start()
    {
        startFlying = false;
        if (coinFX == CoinFX.Fly)
        {
            coinMeter = GameObject.Find("img_Coin");
        }
    }
    private void Update()
    {
        if (startFlying)
        {
            transform.position = Vector3.Lerp(transform.position, coinMeter.transform.position, speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            
            if (coinFX == CoinFX.Vanish)
            {
                
                Destroy(gameObject);
            }
            else if (coinFX == CoinFX.Fly)
            {
                startFlying = true;
            }
        }
    }
}
