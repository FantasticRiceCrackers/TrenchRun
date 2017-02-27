using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum MoveStates
{
	LEFT_MAIN_NODE,
	RIGHT_MAIN_NODE,
	LEFT_TEMP_NODE,
	RIGHT_TEMP_NODE,
	NO_NODE
};
public class abstractRules : MonoBehaviour {

	public List<Transform> nodes, newNodes;
	public Transform tempNode;
	public GameObject tempObject;
	private RaycastHit returnedRay;
	public LayerMask currentLayer;
	public static float speed;
	public float setSpeed;
	public bool toggle, isOnLeft, interupt;

	protected void Awake()
	{
		speed = setSpeed;
	}

	public GameObject swapNodes(Transform mainNode) //this function is made to swap to a new node, it can be used for somthing else
	{
		if (tempObject == null) 
		{
			return tempObject = spawnNode (mainNode) as GameObject;
		}
		else if(tempObject != null) 
		{
			return tempObject;	
		}
		return null;
	}

	public GameObject spawnNode(Transform mainNode)//this will spawn the temp node to allow the player to move side to side in a smoother way
	{
		return Instantiate(tempNode.gameObject, new Vector3(mainNode.position.x,transform.position.y),mainNode.rotation) as GameObject;
	}

	public void increamentNodes()
	{
		if (newNodes.Count >= 1) 
		{
			nodes = new List<Transform> ();
			foreach (Transform i in newNodes) 
			{
				nodes.Add (i);
			}
		}
	}

	public void foundNextNodes()
	{
		if (nodes.Count >= 1) 
		{
			newNodes = new List<Transform> ();
			foreach (Transform i in nodes) 
			{
				if(castRay(i))
				{
					newNodes.Add (returnedRay.transform);
				}
			}
			increamentNodes ();
		}
	}

	public bool castRay(Transform currentNode)//it will pass the current node selected
	{
		return Physics.Raycast (currentNode.position, currentNode.up, out returnedRay,50f, currentLayer);
	}
		
	public Vector3 lerp(Vector3 nodeTransform, float localSpeed)
	{
		return Vector3.MoveTowards (moveToRail (transform.position), moveToRail (nodeTransform), Time.deltaTime * localSpeed);
	}

	public Vector3 LerpY(Vector3 nodeTransform, float localSpeed)
	{
		return Vector3.MoveTowards (moveOnY (transform.position), moveOnY (nodeTransform), Time.deltaTime * localSpeed);
	}

	public Vector3 moveOnY(Vector3 pos)
	{
		return new Vector3 (transform.position.x, pos.y, /*-0.66f*/0f);
	}
	//i can have two of these functions, one for lerping to the left, and to the right
	public Vector3 moveToRail(Vector3 pos)
	{
		return new Vector3 (pos.x, pos.y, /*-0.66f*/0f);
	}
}