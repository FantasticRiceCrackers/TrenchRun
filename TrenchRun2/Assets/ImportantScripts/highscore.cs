using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class highscore : MonoBehaviour {

	public static int highScore;
	public static int money;
	public static bool checkIsEnd;


	private int tempInt;
	private float tempFloat;
	public Text textBox, highTextBox, income, moneyBox;
	public GameObject highscoreObject;
	public bool gameEnd, tempBool;

	private void Awake()
	{
		checkIsEnd = false;
		money = 0;
	}

	public void resetHighScore()
	{
		PlayerPrefs.DeleteAll ();
	}
	
	private void Update()
	{
		if(Application.loadedLevel == 0)
		{
			displayValues();
		}
		else
		{
			if(!gameEnd)
			income.text = money.ToString(); moneyBox.text = "Money Earned = " + money.ToString();
			calculateHighscore();
		}
	}


	private void displayValues()
	{
		highTextBox.text = "Highest distance :" + PlayerPrefs.GetInt ("Highscore").ToString () +" M";
		moneyBox.text = "Money " + PlayerPrefs.GetInt("Money").ToString();
	}

	private void calculateMoney()
	{		
		if(!tempBool)
		{
			PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money") + money );
			tempBool = true;
		}
	}

	private void calculateHighscore()
	{
		if (!checkIsEnd) 
		{
			tempFloat += 20 * Time.deltaTime;
			highScore = (int)tempFloat;
			textBox.text = "Distance: " + highScore.ToString () + " M";
		}
		else 
		{
			if (PlayerPrefs.GetInt ("Highscore", tempInt) != null) 
			{
				if (highScore >= PlayerPrefs.GetInt ("Highscore", tempInt))
				{
					PlayerPrefs.SetInt ("Highscore", highScore);
					PlayerPrefs.Save ();
					gameEnd = true;
				}
				else 
				{
					gameEnd = true;
				}
			}
			else 
			{
				PlayerPrefs.SetInt ("Highscore", highScore);
				PlayerPrefs.Save ();
				gameEnd = true;
			}
		}
		
		if (gameEnd) 
		{
			highscoreObject.SetActive (true);
			highTextBox.text = "Highest distance :" + PlayerPrefs.GetInt ("Highscore", tempInt).ToString () +" M";
			calculateMoney();
			gameEnd = false;
			tempBool = true;

		}
	}
}