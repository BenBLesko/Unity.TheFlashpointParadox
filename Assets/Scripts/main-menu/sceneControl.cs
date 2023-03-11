using UnityEngine;
using UnityEngine.SceneManagement; // namespace for Unity Scene Management

public class sceneControl : MonoBehaviour 
{
	public GameObject datawaiverUI; // to get access the Data Waiver UI
	[SerializeField] bool isDatawaiverUIup = false; // the Data Waiver UI is not shown at the start of the game

    void Update() 
	{
		// if you press Space, you bring up the Data Waiver UI
		if (Input.GetKeyDown(KeyCode.Space))
		{
			datawaiverUI.SetActive(true);
			isDatawaiverUIup = true;
			
		}

		// if the Data Waiver UI is up, you can either enter the game or quit it
		if (Input.GetKeyDown(KeyCode.Return) && isDatawaiverUIup)
        {
			SceneManager.LoadScene("Custom-User-ID");
		}
		if (Input.GetKeyDown(KeyCode.Q) && isDatawaiverUIup)
		{
			Application.Quit();
		}

		// if you press Escape, you quit the game
		if (Input.GetKeyDown(KeyCode.Escape) && !isDatawaiverUIup)
		{
			Application.Quit();
		}
	}
}
