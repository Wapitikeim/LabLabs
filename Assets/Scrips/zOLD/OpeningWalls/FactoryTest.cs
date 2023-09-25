using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    
    string parameter = null;
    public static FactoryTest CreateComponent (GameObject x, string para)
    {
        FactoryTest test = x.AddComponent<FactoryTest>();
        test.parameter = para;
        return test;
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
