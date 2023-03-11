using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // namespace for Unity Scene Management

// I was using sceneControl.cs as a template

public class resetGame : MonoBehaviour
{
	void Update()
	{
		//if you press Space, you jump to the Main Menu
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("Tutorial"); // https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
		}
		// if you press Escape, you quit the game
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Application.Quit(); // https://docs.unity3d.com/ScriptReference/Application.Quit.html
		}
	}
}
