using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformScaler : MonoBehaviour
{
  public float UniformScale = 2;

  public void ApplyScale()
  {
    transform.localScale = Vector3.one * UniformScale;
  }

  void Start()
  {
    ApplyScale();
  }
}
