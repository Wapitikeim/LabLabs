using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBallSimple : MonoBehaviour
{
    public float _box_X;
    public float _box_Y;
    public float _box_Z;
    public float _lightRange;
    public float _lightIntensity;
    GameObject _box;
    GameObject _light;
    Light _addedLight;
    BoxCollider _colliderbox;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CreateColliderBox();
        CreateLight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateColliderBox()
    {
        _box = new GameObject("Light_Trigger_Box");
        _box.transform.parent = transform;
        _box.transform.position = transform.position;
        _box.layer = LayerMask.NameToLayer("Ignore Raycast");
        _box.AddComponent<BoxCollider>();
        _box.AddComponent<ShadowTriggerInteraction>();
        _colliderbox = _box.GetComponent<BoxCollider>();
        _colliderbox.isTrigger = true;
        _colliderbox.size = new Vector3(_box_X,_box_Y,_box_Z);
    }

        private void CreateLight()
    {
        _light = new GameObject("Light");
        _light.transform.position = transform.position;
        _light.transform.parent = transform;
        _light.AddComponent<Light>();
        _addedLight = _light.GetComponent<Light>();
        _addedLight.type = LightType.Point;
        _addedLight.color = Color.red;
        _addedLight.intensity = _lightIntensity;
        _addedLight.range = _lightRange;
    }
}
