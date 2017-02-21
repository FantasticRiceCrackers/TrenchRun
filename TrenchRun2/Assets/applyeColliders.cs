using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class applyeColliders : MonoBehaviour {

	public bool toggle;

	public GameObject instancePrefab;

	private Collider[] coll; //these are the three instances

	public GameObject[] prefabs;


	private void Update()
	{
		if (toggle) 
		{
			getCollidererInfo ();
			toggle = !toggle;
		}
	}

	private void getCollidererInfo()
	{
		print (instancePrefab.transform.GetChild (0).transform.GetChild (0));
	}


		
}
