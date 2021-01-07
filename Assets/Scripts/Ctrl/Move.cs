using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Touch touch;
    float srcHeight;
    private float speedModifier;
    public Transform curvePos;
    public Transform pos3;

    public GameObject curve;
    public GameObject Ball;
    
    // Start is called before the first frame update
    void Start()
    {
        srcHeight = Screen.height;
        speedModifier = 0.01f;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.activeMove)
        {
            if (Input.touchCount > 0)
            {
                
                touch = Input.GetTouch(0);
                if (touch.position.y < srcHeight/3)
                {
                    curve.GetComponent<LineRenderer>().enabled = true;
                    if (touch.phase == TouchPhase.Moved)
                    {
                        curvePos.position = new Vector3(
                            Mathf.Clamp(curvePos.position.x + touch.deltaPosition.x * speedModifier * 1.6f, -4.5f, 4.5f),
                            curvePos.position.y,
                            curvePos.position.z);
                        pos3.position = new Vector3(
                            Mathf.Clamp(pos3.position.x + touch.deltaPosition.x * speedModifier, -1.4f, 2.3f),
                            pos3.position.y,
                            pos3.position.z);

                    }
                }
                
                
            }
            else
            {
                if (touch.position.y < srcHeight / 3)
                {
                    GameManager.instance.anim.enabled = true;
                    curve.GetComponent<LineRenderer>().enabled = false;
                }
                
            }

        }
        
        
    }
}
