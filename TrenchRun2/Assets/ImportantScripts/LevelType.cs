using UnityEngine;
using System.Collections;

public class LevelType : MonoBehaviour {

	public GameObject meshScale, meshPos;
	public static int staticInt;
	private static bool tempBool;

	private void Awake()
	{
		if (Application.loadedLevel == 0) 
		{
			switcher (1);
			//if (staticInt == 2 || !(Camera.main.transform.rotation != GameObject.Find ("Saved Rotation").transform.rotation)) 
			//{
				//Camera.main.transform.position = new Vector3 (GameObject.Find ("Saved Rotation").transform.position.x,GameObject.Find ("Saved Rotation").transform.position.y,GameObject.Find ("Saved Rotation").transform.position.z);//GameObject.Find ("Saved Rotation").transform;
				//Camera.main.transform.rotation = GameObject.Find ("Saved Rotation").transform.rotation;

			//}
			Destroy(GetComponent<LevelType>());
		}
	}

	public void switcher(int value)
	{
		switch (value)
		{
			case 1:
				flying();
				break;
			case 2:
				driving();
				break;
		} 
	}

	private void flying()
	{
		LevelSpawner.offSet = 150;
		//meshScale.transform.position = new Vector3(	meshScale.transform.position.x, meshScale.transform.position.y, 81.1f);
		//meshPos.transform.position = new Vector3(meshPos.transform.position.x,  meshPos.transform.position.y, 0f);
		//meshScale.transform.position = new Vector3(	meshScale.transform.position.x, meshScale.transform.position.y, 110f);
		//meshPos.transform.localScale = new Vector3(meshPos.transform.localScale.x + 4f, meshPos.transform.localScale.y + 4f, meshPos.transform.localScale.z + 4f);

	}

	private void driving()
	{
		LevelSpawner.offSet = 100;
		meshPos.transform.position = new Vector3(meshPos.transform.position.x, meshPos.transform.position.y, 6f);
		meshPos.transform.localScale = new Vector3(meshPos.transform.localScale.x + 1f, meshPos.transform.localScale.y + 1f, meshPos.transform.localScale.z + 1f);
	}
}
