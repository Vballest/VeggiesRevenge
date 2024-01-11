using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameUI : MonoBehaviour
{
	public GameObject WinmenuUI;
	public static bool isGameEnd = false;
	public GameObject Player;
	public TextMeshProUGUI ScoreTXT;

	private void Start()
	{
		WinmenuUI.SetActive(value: false);
		Time.timeScale = 1f;
		isGameEnd = false;
	}

	private void Update()
	{
		if (isGameEnd == true)
		{
			WinmenuUI.SetActive(value: true);
			Time.timeScale = 0f;
		}
		else if (!PauseMenu.GameIsPaused && !History.isStory)
		{
			WinmenuUI.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}

	public void finishGame()
    {
		isGameEnd	   = true;
		ScoreTXT.text  = Player.GetComponent<ScoreManager>().totalScore.ToString();
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
		isGameEnd = false;
		SceneManager.LoadScene("Main Menu");
	}

	public void retry()
	{
		isGameEnd = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
