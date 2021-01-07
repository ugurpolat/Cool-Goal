using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingsCtrl : MonoBehaviour
{
    public RectTransform btnMusic;
    public float moveMusic;
    public float defaultPosX, defaultPosY;
    public float speed;

    bool expanded;
    // Start is called before the first frame update
    void Start()
    {
        expanded = false;
    }

    // Update is called once per frame
    public void Toogle()
    {
        if (!expanded)
        {
            //show buttons
            btnMusic.DOAnchorPosY(moveMusic,speed,false);
            expanded = true;
        }
        else
        {
            btnMusic.DOAnchorPosY(defaultPosY, speed, false);
            expanded = false;
        }
    }
}
