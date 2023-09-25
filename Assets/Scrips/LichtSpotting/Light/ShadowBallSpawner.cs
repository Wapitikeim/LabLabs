using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBallSpawner : MonoBehaviour
{
    private RaycastHit _hitLeft;
    private RaycastHit _hitRight;
    private RaycastHit _hitUp;
    private RaycastHit _hitDown;
    private RaycastHit _hitForward;
    private RaycastHit _hitBackward;

    private GameObject _light;
    private GameObject _box;
    private Light _addedLight;

    private BoxCollider _colliderbox;

    //Es gibt einen nicht gelösten Edgecase bei AdjustBoxOrientation
    //Beim Übergang in die Höhe!
    //Nicht super tragisch dennoch im Hinterkopf zu haben

    void Start()
    {
        CreateLight();
        CreateColliderBox();
    }
    
    void Update()
    {
        AdjustBoxAndLightPosition();
        AdjustBoxOrientation();
    }

    private Vector3 FindMiddlePoint()
    {
        Vector3 _middlePos = transform.position;
        
        
        //The shortest Connection line should function(most of the time) as a good compromise 
        Physics.Raycast(transform.position, Vector3.forward, out _hitForward, 100f);
        Physics.Raycast(transform.position, Vector3.back, out _hitBackward, 100f);
        float _forBackMid = _hitForward.distance + _hitBackward.distance;

        Physics.Raycast(transform.position, Vector3.up, out _hitUp, 100f);
        Physics.Raycast(transform.position, Vector3.down, out _hitDown, 100f);
        float _upDownMid = _hitUp.distance + _hitDown.distance;

        Physics.Raycast(transform.position, Vector3.left, out _hitLeft, 100f);
        Physics.Raycast(transform.position, Vector3.right, out _hitRight, 100f);
        float _leftRightMid = _hitLeft.distance + _hitRight.distance;

        if(_forBackMid <= _upDownMid && _forBackMid <= _leftRightMid)
        {
            _middlePos = ((_hitForward.point+_hitBackward.point)/2);
        }
        else if(_upDownMid <= _forBackMid && _upDownMid <= _leftRightMid)
        {
            _middlePos = ((_hitUp.point+_hitDown.point)/2);
        }
        else
        {
            _middlePos = ((_hitLeft.point+_hitRight.point)/2);
        }
 
        return _middlePos;
    }

    private void CreateLight()
    {
        _light = new GameObject("Light");
        _light.transform.position = FindMiddlePoint();
        //_light.transform.parent = transform;
        _light.AddComponent<Light>();
        _addedLight = _light.GetComponent<Light>();
        _addedLight.type = LightType.Point;
        _addedLight.color = Color.red;
        _addedLight.intensity = 5;
        
        _addedLight.range = FindRange();
    }

    private float FindRange()
    {
        Physics.Raycast(transform.position, Vector3.forward, out _hitForward, 100f);
        Physics.Raycast(transform.position, Vector3.back, out _hitBackward, 100f);
        Physics.Raycast(transform.position, Vector3.up, out _hitUp, 100f);
        Physics.Raycast(transform.position, Vector3.down, out _hitDown, 100f);
        Physics.Raycast(transform.position, Vector3.left, out _hitLeft, 100f);
        Physics.Raycast(transform.position, Vector3.right, out _hitRight, 100f);
        float[] _smallestDistance = {_hitForward.distance, _hitBackward.distance,_hitUp.distance,_hitDown.distance,_hitLeft.distance,_hitRight.distance};
        System.Array.Sort(_smallestDistance);
        
        return _smallestDistance[0];
    }
    
    private void CreateColliderBox()
    {
        float range = FindRange();
        _box = new GameObject("Light_Trigger_Box");
        _box.transform.position = FindMiddlePoint();
        _box.layer = LayerMask.NameToLayer("Ignore Raycast");
        _box.AddComponent<BoxCollider>();
        _box.AddComponent<ShadowTriggerInteraction>();
        _colliderbox = _box.GetComponent<BoxCollider>();
        _colliderbox.isTrigger = true;
        _colliderbox.size = new Vector3(range * 2, 1, range * 2);
    }

    private void AdjustBoxAndLightPosition()
    {
        Vector3 _middlePos = FindMiddlePoint();
        _light.transform.position = _middlePos;
        _addedLight.range = FindRange()*2;
        _box.transform.position = _middlePos;
    }

    private void AdjustBoxOrientation()
    {
        Physics.Raycast(transform.position, Vector3.forward, out _hitForward, 100f);
        Physics.Raycast(transform.position, Vector3.back, out _hitBackward, 100f);
        Physics.Raycast(transform.position, Vector3.up, out _hitUp, 100f);
        Physics.Raycast(transform.position, Vector3.down, out _hitDown, 100f);
        Physics.Raycast(transform.position, Vector3.left, out _hitLeft, 100f);
        Physics.Raycast(transform.position, Vector3.right, out _hitRight, 100f);
        float _range = FindRange()*2;
        
        //Box moves Forward / Backwards (ZAxis) (0,0,1)
        if
        (
            _hitForward.distance  >= _hitUp.distance || _hitForward.distance >= _hitDown.distance || _hitForward.distance >= _hitLeft.distance || _hitForward.distance >=_hitRight.distance ||
            _hitBackward.distance  >= _hitUp.distance || _hitBackward.distance >= _hitDown.distance || _hitBackward.distance >= _hitLeft.distance || _hitBackward.distance >=_hitRight.distance
        )
        {
            _colliderbox.size = new Vector3(_range,_range,1);
        }
        //Box moves Left / Right (X-Axis)(1,0,0)
        else if
        (
            _hitLeft.distance >= _hitUp.distance || _hitLeft.distance >= _hitDown.distance ||
            _hitRight.distance >= _hitUp.distance || _hitRight.distance >= _hitDown.distance
        )
        {
            _colliderbox.size = new Vector3(1,_range,_range);
        }
        //Box moves Up / Down (Y-Axis)(0,1,0)
        else
        {
            _colliderbox.size = new Vector3(_range,1,_range);
        }
        
    
    }
}
