using UnityEngine;
using System.Collections;
public enum HAZZARDTYPE
{
	CAR,
	PLANE,
	SPACE_SHIP,
	BOAT,
	NOTHING
};

public class swapMeshs : itemGen
{
	public static HAZZARDTYPE hazzardClass;
	public GameObject[] car, plane;
	private GameObject tempObject;
	private float tempFloat;
	public static int spawnAmount;

	protected void Start()
	{
		spawnAmount = setSpawnAmount;
		tempFloat = delay;
		delay = 0;
		StartCoroutine(spawnDelay("startSwap"));
	}

	private GameObject[] meshType(HAZZARDTYPE hazzardGroup)
	{
		switch(hazzardGroup)
		{
			case HAZZARDTYPE.CAR:
			return car;

			case HAZZARDTYPE.PLANE:
			return plane;


			case HAZZARDTYPE.SPACE_SHIP:
			break;

			case HAZZARDTYPE.BOAT:
			break;

			case HAZZARDTYPE.NOTHING:
			break;
		}
		return null;
	}
	public void startSwap()
	{
		//print (spawnAmount);
		for (int i = 0; i < spawnAmount; i++)
		{
			GameObject tempStoredObject = meshType(hazzardClass)[setRandom(meshType(hazzardClass).Length)];
			if(tempStoredObject.activeSelf == false)
			{
				tempObject.SetActive(true);	
				betterSpawn (tempStoredObject).transform.parent = storeObject;
			}
			else
			{
				betterSpawn (tempStoredObject).transform.parent = storeObject;
			}
		}
		tempObject = null;
		StopAllCoroutines();
		delay = (float)spawnAmount/2;
		StartCoroutine(spawnDelay("startSwap"));
	}

	private GameObject betterSpawn(GameObject prefab)
	{
		if (tempObject != null) 
		{
			return tempObject = Instantiate(prefab,new Vector3(spawnPosition( setRandom(3) ).x,tempObject.transform.position.y + coinOffset,0f),prefab.transform.rotation) as GameObject;
		}
		else 
		{
			return tempObject = Instantiate(prefab,spawnPosition( setRandom(3) ),prefab.transform.rotation) as GameObject;
		}
		return null;
		//timer = reFillTimer;
	}
}