using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NVIDIA.Flex;

public class CanvasTriggerHandler : MonoBehaviour
{
  public UnityEngine.Events.UnityEvent EnterEvent;
  public UnityEngine.Events.UnityEvent ExitEvent;

  void Start()
  {
    if (EnterEvent == null)
      EnterEvent = new UnityEngine.Events.UnityEvent();
    if (ExitEvent == null)
      ExitEvent = new UnityEngine.Events.UnityEvent();
        FlexSourceActor child = transform.GetComponentInChildren<FlexSourceActor>();
        //child.container;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.name == "Canvas")
      EnterEvent.Invoke();
    
  }
  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.name == "Canvas")
      ExitEvent.Invoke();
  }
}
