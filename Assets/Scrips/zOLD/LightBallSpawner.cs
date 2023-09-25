using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallSpawner : MonoBehaviour
{
    private Vector3 _prevHitLeft = new Vector3(0,0,0);

    // Update is called once per frame
    void Update()
    {
        RaycastHit _hitLeft;
        if(Physics.Raycast(transform.position, Vector3.forward, out _hitLeft, 100f) && _prevHitLeft != _hitLeft.point)
        {
            RaycastHit _hitRight;
            if(Physics.Raycast(_hitLeft.point,Vector3.back, out _hitRight, 100f))
            {
                Vector3 _middlePos = (_hitLeft.point+_hitRight.point)/2;

                if(GameObject.Find("Light"))
                {
                    GameObject _lightToDel = GameObject.Find("Light");
                    Destroy(_lightToDel);
                    GameObject _boxToDel = GameObject.Find("Light_Trigger_Box");
                    Destroy(_boxToDel);
                }
                GameObject _light = new GameObject("Light");
                _light.transform.position = _middlePos;
                //_light.transform.parent = transform;
                _light.AddComponent<Light>();
                Light _addedLight = _light.GetComponent<Light>();
                _addedLight.type = LightType.Point;
                _addedLight.color = Color.red;
                
                RaycastHit _rangeHit;
                float range = 5f;
                if(Physics.Raycast(_addedLight.transform.position, transform.forward, out _rangeHit, 100f))
                {
                    range = _rangeHit.distance;
                }
                _addedLight.range = range;
                _addedLight.intensity = 5;

                GameObject box = new GameObject("Light_Trigger_Box");
                box.transform.position = _middlePos;
                box.layer = LayerMask.NameToLayer("Ignore Raycast");
                box.AddComponent<BoxCollider>();
                BoxCollider colliderbox = box.GetComponent<BoxCollider>();
                colliderbox.isTrigger = true;
                colliderbox.size = new Vector3(range*2, 1, range*2);

            }
            _prevHitLeft = _hitLeft.point;
        }
        else if(!Physics.Raycast(transform.position, Vector3.forward, out _hitLeft, 100f) || !Physics.Raycast(transform.position, Vector3.back, out _hitLeft, 100f))
        {
            if(GameObject.Find("Light"))
                {
                    GameObject _lightToDel = GameObject.Find("Light");
                    Destroy(_lightToDel);
                    GameObject _boxToDel = GameObject.Find("Light_Trigger_Box");
                    Destroy(_boxToDel);
                }
        }

    }

}
