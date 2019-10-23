using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  NVIDIA.Flex;

   
    public class testCollision : FlexActor
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collision;particle");
    }
    private void OnParticleTrigger()
    {
        Debug.Log("particle trigger");
    }
    
    protected override void OnFlexUpdate(FlexContainer.ParticleData _particleData)   
    {
        Debug.Log("flex update");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ENTER");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("EXIT");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
