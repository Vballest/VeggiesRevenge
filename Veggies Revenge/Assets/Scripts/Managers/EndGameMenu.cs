using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
	public GameObject EndGameUI;

	private void Start()
	{
	}

	private void Update()
	{
		if (HealthControllerPlayer.isDead)
		{
			EndGameUI.SetActive(value: true);
			Time.timeScale = 0f;
		}
		else if (!PauseMenu.GameIsPaused)
		{
			EndGameUI.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}

	public void exit()
	{
		Application.Quit();
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
