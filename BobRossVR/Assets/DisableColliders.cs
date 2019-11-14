using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		var comps = GetComponentsInChildren<Collider>();
		foreach(var comp in comps)
		{
			comp.enabled = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
