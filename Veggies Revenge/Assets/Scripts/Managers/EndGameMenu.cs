using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
	public GameObject EndGameUI;

	private void Start()
	{
		EndGameUI.SetActive(value: false);
		Time.timeScale = 1f;
	}

	private void Update()
	{
		if (HealthControllerPlayer.isDead)
		{
			EndGameUI.SetActive(value: true);
			Time.timeScale = 0f;
		}
		else if (!PauseMenu.GameIsPaused && !History.isStory && !WinGameUI.isGameEnd)
		{
			EndGameUI.SetActive(value: false);
			Time.timeScale = 1f;
		}
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
		SceneManager.LoadScene("Main Menu");
	}

	public void retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
