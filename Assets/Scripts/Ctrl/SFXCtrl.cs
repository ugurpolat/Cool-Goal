using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl instance;
    
    public SFX sfx;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCoinSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_coin_pickup, pos, Quaternion.identity);
    }
    public void DustSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_dust, pos, Quaternion.identity);
    }
    public void ExplosionSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_explosion, pos, Quaternion.identity);
    }
}
