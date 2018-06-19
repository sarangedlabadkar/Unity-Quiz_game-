using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {


	public void StartGame()
	{
		SceneManager.LoadScene ("Scene01");
	}


	public void GotoTrophyRoom()
	{
		SceneManager.LoadScene ("TrophyRoom");
	}


	public void ResetPlayerPrefs()
	{
		PlayerPrefs.DeleteAll ();
	}

}
