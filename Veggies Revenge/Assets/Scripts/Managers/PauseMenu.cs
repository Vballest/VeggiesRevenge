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
				if (!History.isStory && !History.isStory && !WinGameUI.isGameEnd)
				{
					Resume();
				}
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
		#if !UNITY_EDITOR
					Application.Quit();
		#endif

		#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void mainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
