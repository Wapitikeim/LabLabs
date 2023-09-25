using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierMove : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;
    private int routeToGo;
    private float tParam;
    private Vector3 lightPosition;
    private bool coroutineAllowed;
    public float routeFollowSpeed;

    public bool RouteGoBackwards;
    public int heightOffset;

    void Start()
    {
        InitParameters();
    }
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }
    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;
        Vector3 p0 = routes[routeNum].GetChild(0).position;
        Vector3 p1 = routes[routeNum].GetChild(1).position;
        Vector3 p2 = routes[routeNum].GetChild(2).position;
        Vector3 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1 )
        {
            tParam += Time.deltaTime * routeFollowSpeed;
            lightPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            transform.position = lightPosition + new Vector3(0,heightOffset,0);
            yield return new WaitForEndOfFrame();
        }
        RouteRoundupCheck();
        coroutineAllowed = true;
    }

    private void InitParameters()
    {
        routeToGo = 0;
        tParam = 0f;
        coroutineAllowed = true;
    }
    private void LetRouteGoBackwards()
    {
        System.Array.Reverse(routes);
        for (int i = routeToGo - 1; i >= 0; i--)
        {
            BezierRouteScript refScript = routes[i].GetComponent<BezierRouteScript>();
            System.Array.Reverse(refScript.controlPoints);
            

            //This Extra Clutter is nessesary because Unity do indeed Reverse
            //the order of the Array but does not update the positions
            Vector3 cpNull = refScript.controlPoints[0].position;
            Vector3 cpOne = refScript.controlPoints[1].position;
            refScript.controlPoints[0].position = refScript.controlPoints[3].position;
            refScript.controlPoints[1].position = refScript.controlPoints[2].position;
            refScript.controlPoints[2].position = cpOne;
            refScript.controlPoints[3].position = cpNull;

        }
    }
    private void RouteRoundupCheck()
    {
        tParam = 0f;
        routeToGo += 1;
        if (routeToGo > routes.Length - 1)
        {
            //Backwards Check
            if (RouteGoBackwards)
            {
                LetRouteGoBackwards();
            }

            routeToGo = 0;
        }
    }
  
  
    public void StopMovement()
    {
        routeFollowSpeed = 0;
    }

    public void SetRouteFollowSpeed(float x)
    {
        routeFollowSpeed = x;
    }

    public void SetRouteGoBackwards(bool x)
    {
        RouteGoBackwards = x;
    }

    void OnEnable()
    {
        coroutineAllowed = true;
    }

}
