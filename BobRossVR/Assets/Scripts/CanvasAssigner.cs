using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAssigner : MonoBehaviour
{
    public BoxCollider Canvas;
    // Start is called before the first frame update
    void Awake()
    {
        var springBones = GetComponentsInChildren<VRM.VRMSpringBone>();

        foreach (var springBone in springBones)
        {
            springBone.box = Canvas;
        }
    }
}
