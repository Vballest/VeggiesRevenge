using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused;

	public GameObject PauseUI;

	private void Start()
	{
		Resume();
	}

	private void Update()
	{
		if (!HealthControllerPlayer.isDead && Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		PauseUI.SetActive(value: false);
		GameIsPaused = false;
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		Cursor.visible = true;
		GameIsPaused = true;
		PauseUI.SetActive(value: true);
	}

	public void exit()
	{
		Application.Quit();
	}

	public void mainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
