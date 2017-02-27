using UnityEngine;
using System.Collections;

public enum ITEMINFO
{
	COIN,
	HAZZARD,
	POWER_UP
};
public class itemGen : MonoBehaviour {

	public GameObject savedObject;
	public Transform storeObject;
	public GameObject[] getNodeInfo;
	public int setSpawnAmount;
	public float delay, coinOffset;
	private float savedDelay;

	private void Start()
	{
		//spawnAmount = setSpawnAmount;
		savedDelay = delay;
		delay = 0;
		StartCoroutine(spawnDelay("spawn"));
		delay = savedDelay;
	}


	public IEnumerator spawnDelay(string functionName)
	{
		while (delay > 0)
		{
			delay -= Time.deltaTime;
			yield return null;
		}
		Invoke (functionName, 0f);
	}
		
	public void spawn()
	{
		for (int i = 0; i < setSpawnAmount; i++)
		{
			returnObject(i, savedObject).transform.parent = storeObject;
		}
		StopAllCoroutines();
		delay = savedDelay;
		StartCoroutine(spawnDelay("spawn"));
	}
		
	public GameObject returnObject(int i, GameObject prefab)
	{ 
		return Instantiate(prefab,setPosition( spawnPosition( setRandom(3) ), i ),prefab.transform.rotation) as GameObject;
	}
		
	private float between(float value1, float value2)
	{
		float temp = value1 + (value2 - value1) / 2;
		return temp;
	}

	public Vector3 setPosition(Vector3 passedValue, int i)
	{
		//print("running now");
		return new Vector3(passedValue.x,passedValue.y + i * coinOffset, 0f);
	}

	public int setRandom(int value)
	{
		return Random.Range(0,value);
	}

	public Vector3 spawnPosition(int value)
	{
		switch(value)
		{
		case 0:
			return getNodeInfo[value].transform.position;
		case 1:
			return getNodeInfo[value].transform.position;
		case 2:
			return new Vector3(between(getNodeInfo[0].transform.position.x,getNodeInfo[1].transform.position.x),getNodeInfo[0].transform.position.y,0f);
		}
		return Vector3.zero;
	}

}
