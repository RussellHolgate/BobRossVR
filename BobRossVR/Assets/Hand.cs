using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
	public enum HandCode { Left, Right };
	public HandCode HandType = HandCode.Left;
	public UniformScaler PlayerScale;
	public bool UnparentFromVRController = false;

	public enum BehaviourCode { Emit, Push };
	public BehaviourCode Behaviour = BehaviourCode.Emit;
	private CanvasTriggerHandler[] TriggerHandlers;

	bool isTriggerPressed = false;

	void SetActiveBehaviour()
	{
		string n = "";

		switch (Behaviour)
		{
			case BehaviourCode.Emit:
				n = "PaintEmitter";
				break;
			case BehaviourCode.Push:
				n = "PaintPusher";
				break;
		}

		foreach (var child in GetComponentsInChildren<Transform>(true))
		{
			if (child.gameObject.tag == "Behaviour")
				child.gameObject.SetActive(child.gameObject.name == n);
		}
	}

	private XRNode HandNode;

	void Start()
	{
		SetActiveBehaviour();

		if (PlayerScale == null)
		{
			Debug.Log("Hand requires Camera Parent's UniformScaler component");
			enabled = false;
			return;
		}

		if (HandType == HandCode.Left)
		{
			HandNode = XRNode.LeftHand;
			//TODO: Set input for left hand
			//...
		}
		else
		{
			HandNode = XRNode.RightHand;
			//TODO: Set input for right hand
			//...
		}

		TriggerHandlers = GetComponentsInChildren<CanvasTriggerHandler>();
		if (Behaviour == BehaviourCode.Emit && TriggerHandlers.Length == 0)
		{
			Debug.Log("Hand requires a child with CanvasTriggerHandler component");
			enabled = false;
			return;
		}
	}

	void Update()
	{
		isTriggerPressed = Input.GetAxisRaw(HandType == HandCode.Left
			? "Left Trigger"
			: "Right Trigger") > 0.3f;
		if (Behaviour == BehaviourCode.Emit)
		{
			if (isTriggerPressed)
			{
				foreach (var TriggerHandler in TriggerHandlers)
				{
					TriggerHandler.EnterEvent.Invoke();
				}
			}
			else
			{
				foreach (var TriggerHandler in TriggerHandlers)
				{
					TriggerHandler.ExitEvent.Invoke();
				}
			}
		}

		if (UnparentFromVRController)
		{
			return;
		}
		else
		{
			var states = new List<XRNodeState>();
			InputTracking.GetNodeStates(states);

			foreach (var state in states)
			{
				if (state.nodeType == HandNode)
				{
					Vector3 pos;
					if (state.TryGetPosition(out pos))
						transform.position = pos * PlayerScale.UniformScale;

					Quaternion rot;
					if (state.TryGetRotation(out rot))
						transform.rotation = rot;
				}
			}
		}
	}
}
