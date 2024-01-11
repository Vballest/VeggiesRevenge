using UnityEngine;

public class Exit : MonoBehaviour
{
	public GameObject player;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			gameObject.GetComponentInParent<WinGameUI>().finishGame();
		}
	}
}
