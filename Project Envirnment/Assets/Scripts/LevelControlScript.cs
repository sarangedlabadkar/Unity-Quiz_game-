using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {


	GameObject[] toEnable, toDisable;
	public GameObject[] questions;
	public float waitTimer=2f;
	public GameObject correctSign, incorrectSign, cup, trophySing;
	public int arrayIndex=0;
	public int counter;


	int currentSceneIndex;


	public string whichCupGot = "Cup1Got";


	void Start () {


		currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
		questions [arrayIndex].SetActive (true);

		toEnable = GameObject.FindGameObjectsWithTag ("ToEnable");
		toDisable = GameObject.FindGameObjectsWithTag ("ToDisable");


		foreach (GameObject element in toEnable)
		{
			element.gameObject.SetActive (false);
		}

	}

	// Method is invoked when correct answer is given
	public void RightAnswer()
	{
		// Disabling game objects that are no longer needed
		foreach (GameObject element in toDisable)
		{
			element.gameObject.SetActive (false);
		}

		 
		correctSign.gameObject.SetActive (true);
		arrayIndex++;

		int Cupgot = PlayerPrefs.GetInt(whichCupGot);
		print (Cupgot);
		if (Cupgot == 0 && counter == 3) {
			print ("Fa");
			questions [counter].SetActive (false);
			GetTrophy ();
		}
		if (counter < 3) {
			counter++;
			StartCoroutine (LoadQuestion (counter));
		}




	}


	public void WrongAnswer()
	{
		
		foreach (GameObject element in toDisable)
		{
			element.gameObject.SetActive (false);
		}


		incorrectSign.SetActive (true);


		Invoke ("GotoMainMenu", 1f);
	}
	IEnumerator LoadQuestion(int number){
		questions [number - 1].SetActive (false);
		//questions [number - 1].SetActive (false);
		yield return new WaitForSeconds (waitTimer);
		correctSign.SetActive (false);
		questions [number].SetActive (true);
	}

	void GetTrophy()
	{
		
		correctSign.SetActive (false);


		cup.SetActive (true);


		trophySing.SetActive (true);


		PlayerPrefs.SetInt (whichCupGot, 1);


		Invoke ("LoadNextLevel", 1f);
	}


	void LoadNextLevel()
	{
		SceneManager.LoadScene (currentSceneIndex + 1);
	}


	void GotoMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

}
