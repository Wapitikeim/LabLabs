using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxSpawner : MonoBehaviour
{
   
    void Start()
    {
        //Compensation for HeightDiff in BezierAlgo
        StartCoroutine(LateStart(0.5f));
        
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        SpawnTriggerBox();
        
    }

    private float CalcBoxSizeSpotLight(RaycastHit hit)
    {
        if (GetComponent<Light>())
        {
            Light lt = GetComponent<Light>();
            lt.type = LightType.Spot;
            float boxSize = Mathf.Abs(Mathf.Tan((lt.spotAngle * Mathf.PI) / 180)) * hit.distance;
            return boxSize/2;
        }
        else
        {
            print("No Attached Light found!");
            return 0f;
        }
        
    }

    private void SpawnTriggerBox()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -Vector3.up, out hit, 100f))
        {
            GameObject box = new GameObject("Box");
            box.transform.position = hit.point;            
            box.transform.parent = transform;
            box.AddComponent<TriggerBoxColliderInteraction>();
            box.AddComponent<BoxCollider>();
            BoxCollider colliderbox = box.GetComponent<BoxCollider>();
            colliderbox.isTrigger = true;
            colliderbox.size = new Vector3(CalcBoxSizeSpotLight(hit), 4 , CalcBoxSizeSpotLight(hit));
            

        }
    }
}
