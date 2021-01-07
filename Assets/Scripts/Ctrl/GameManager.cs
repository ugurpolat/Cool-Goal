using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public bool activeMove;
    //private Touch touch;
    public Animator anim;
    public Text txtCoinCount;
    public GameData data;

    string dataFilePath;
    BinaryFormatter bf;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        bf = new BinaryFormatter();

        dataFilePath = Application.persistentDataPath + "/game.dat";
        
    }
    void Start()
    {
        anim = player.GetComponent<Animator>();
        anim.enabled = false;
        activeMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            activeMove = true;
        }
        else
        {
            activeMove = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetData();
        }
    }
    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (GameData)bf.Deserialize(fs);
            txtCoinCount.text = "x " + data.coin.ToString();
            fs.Close();
        }
    }
    void OnEnable()
    {
        LoadData();
    }
    void OnDisable()
    {
        SaveData();
    }
    void ResetData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);

        data.coin = 0;
        txtCoinCount.text = "x 000" + data.coin.ToString();
        bf.Serialize(fs,data);
        fs.Close();
    }
    public void UpdateCoinCount()
    {
        data.coin += 10;
        txtCoinCount.text = "x" + data.coin.ToString();
    }
}
