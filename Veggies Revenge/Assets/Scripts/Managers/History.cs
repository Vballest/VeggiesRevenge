using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class History : MonoBehaviour
{
	public TextMeshProUGUI nextButton;
	public GameObject PauseUI;
	public GameObject Page1;
	public GameObject Page2;
	public GameObject Page3;
	public GameObject Page4;

	public static bool isStory = true;

	private int pageNumber = 1;

	private void Start()
	{
		Pause();
		isStory = true;
	}

	private void Update()
	{
		if(isStory)
        {
			Pause();
		}
		else
        {
			Resume();
        }
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		PauseUI.SetActive(value: false);
		isStory		 = false;
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		Cursor.visible = true;
		isStory = true;
		PauseUI.SetActive(value: true);

		updateMenu();
	}

	public void updateMenu()
    {
		switch (pageNumber)
		{
			case 1:
				Page1.active = true;
				Page2.active = false;
				Page3.active = false;
				Page4.active = false;
				break;
			case 2:
				Page1.active = false;
				Page2.active = true;
				Page3.active = false;
				Page4.active = false;
				break;
			case 3:
				Page1.active = false;
				Page2.active = false;
				Page3.active = true;
				Page4.active = false;
				break;
			case 4:
				Page1.active = false;
				Page2.active = false;
				Page3.active = false;
				Page4.active = true;
				nextButton.text = "Empezar";
				break;
			case 5:
				omit();
				break;
		}
	}

	public void omit()
	{
		PauseUI.active = false;
		Resume();
	}
	public void next()
    {
		pageNumber++;

    }
}
