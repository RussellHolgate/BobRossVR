using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScalerAllChildrensChildren : MonoBehaviour
{
	[Range(0.5f, 5.0f)]
	public float Scale = 1;
	float PreviousScale;

	private void Start()
	{
		UpdateScale();
	}

	// Update is called once per frame
	void Update()
    {
        if (PreviousScale != Scale)
		{
			UpdateScale();
		}
    }

	void UpdateScale()
	{
		var children = GetComponentsInChildren<Transform>();
		if (children.Length > 10)
		{
			Debug.Log("ok");
		}
		foreach (var child in children)
		{
			child.localScale *= Scale;
		}

		PreviousScale = Scale;
	}
}
