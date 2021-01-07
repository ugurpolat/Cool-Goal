using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class AudioCtrl : MonoBehaviour
{   
    public static AudioCtrl instance;
    public Audios audios;
    
    public Sprite imgMusicOn, imgMusicOff;

    public GameObject btnMusic;
    public GameObject backgrundMusic;
    public bool soundOn;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Coin(UnityEngine.Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(audios.coin, pos);
        }
    }
    public void FootballKick(UnityEngine.Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(audios.kickball, pos);
        }
    }
    public void Hit(UnityEngine.Vector3 pos)
    {
        if (soundOn)
        {
            AudioSource.PlayClipAtPoint(audios.hit, pos);
        }
    }
    
    public void ToggleMusic()
    {
        if (GameManager.instance.data.playMusic)
        {
            soundOn = false;
            btnMusic.GetComponent<Image>().sprite = imgMusicOff;
            GameManager.instance.data.playMusic = false;
            backgrundMusic.SetActive(false);
        }
        else
        {
            soundOn = true;
            btnMusic.GetComponent<Image>().sprite = imgMusicOn;
            backgrundMusic.SetActive(true);
            GameManager.instance.data.playMusic = true;
        }
    }
    
}
