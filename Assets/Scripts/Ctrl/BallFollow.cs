using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
            //                 3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
            //                 3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
            //                 Mathf.Pow(t, 3) * controlPoints[3].position;

            //gizmosPosition = controlPoints[0].position* Mathf.Pow(1 - t, 2) + 2 * t * controlPoints[1].position* (1 - t) + controlPoints[2].position* Mathf.Pow(t, 2);

            //Gizmos.DrawSphere(gizmosPosition, 0.25f);
public class BallFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;
    
    private float tParam;
    
    private Vector3 ballPosition;
    
    private float speedModifier;

    public bool coroutineAllowed;
    

    route2 myroute;
    public GameObject route;
    // Start is called before the first frame update
    void Start()
    {
        myroute = route.GetComponent<route2>();
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.85f;
        coroutineAllowed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
            StartCoroutine(GoByTheRoute(routeToGo));

    }


    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            ballPosition = myroute.CalculateQuadraticBezierPoint(tParam,p0,p1,p2);


            transform.position = ballPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
            routeToGo = 0;

        coroutineAllowed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                SFXCtrl.instance.ShowCoinSparkle(other.gameObject.transform.position);
                GameManager.instance.UpdateCoinCount();
                AudioCtrl.instance.Coin(other.gameObject.transform.position);
                break;
            case "PlayerFoot":
                SFXCtrl.instance.DustSparkle(gameObject.transform.position);
                GameManager.instance.anim.enabled = false;
                coroutineAllowed = true;
                AudioCtrl.instance.FootballKick(gameObject.transform.position);
                break;
            case "Net":
                SFXCtrl.instance.ExplosionSparkle(other.gameObject.transform.position);
                Destroy(gameObject);
                SceneCtrl.instance.LoadNextScene();
                GameManager.instance.UpdateCoinCount();
                break;

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("hello");
            
            AudioCtrl.instance.Hit(gameObject.transform.position);
            gameObject.SetActive(false);
            SceneCtrl.instance.LoadCurrentScene();
        }
    }
}
