using UnityEngine;
using System.Collections;
[System.Serializable]
public struct LevelInfo
{
	public GameObject[] objectArray;
}
public class LevelSpawner : MonoBehaviour {

	private Transform instanceOfRotation;
	public Transform[] differentRotation;

	public float worldOffset;
	public LevelInfo[] currentInfo;
	public GameObject world, worldAbove;
	public LayerMask currentLayer;
	private GameObject tempObject,  player;
	private int currentInt;
	private bool run = false;
	public static float offSet,savedTimeScale,myFixedTime;


	private Transform instanceOfPlayerPos;
	private void Start()
	{
		//currentInt = Random.Range (0, currentInfo.Length);
		instanceOfRotation = GameObject.Find("tempRotation").GetComponent<Transform>();
		player = GameObject.Find ("Player");
		savedTimeScale = Time.timeScale;
		if (myFixedTime == 0) 
		{
			myFixedTime = Time.deltaTime;
		}
		instanceOfPlayerPos = player.transform;
	}

	private void FixedUpdate()
	{
		difficultyChanger (highscore.highScore);
		if (!checkLevel ()) 
		{
			Spawn (currentInt,randomRotation(1,differentRotation[Random.Range(0,differentRotation.Length)]));
		}
	}
		
	private void difficultyChanger(int highScore)
	{
		if (highScore % 250 == 0) 
		{
			if (run) 
			{
				currentInt = Random.Range (0, currentInfo.Length);
				//abstractRules.speed += 5f;
				//swapMeshs.spawnAmount += 5;
				run = false;
			}
		}
		else 
		{
			run = true;
		}
	}

	private bool checkLevel()
	{
		Vector3 tempVector = new Vector3(0f,instanceOfPlayerPos.position.y,-300f);
		return Physics.Raycast(tempVector + Vector3.up * worldOffset, Vector3.forward,320f, currentLayer);
	}


	public GameObject randomObject(GameObject[] objectArray)
	{
		return objectArray [Random.Range (0, objectArray.Length)];
	}



	public Transform randomRotation(int switcher, Transform instance)
	{
		switch(switcher)
		{
			case 0:
			return world.transform;
			case 1:
			return instance;
		}
		return null;
	}

	private void Spawn(int value, Transform instance)
	{
		if (tempObject != null) 
		{
			tempObject = Instantiate (randomObject(currentInfo[value].objectArray), new Vector3 (tempObject.transform.position.x, tempObject.transform.position.y + offSet,instance.localPosition.z), instance.rotation ) as GameObject;
			tempObject.transform.parent = worldAbove.transform;
		}
		else 
		{
			tempObject = Instantiate (randomObject(currentInfo[value].objectArray), new Vector3 (world.transform.position.x, world.transform.position.y +offSet,world.transform.position.z), Quaternion.identity) as GameObject;
			tempObject.transform.parent = worldAbove.transform;
		}
	}
}