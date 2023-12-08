using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
	[Header("Recovery")]
	public float recoverPoints;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			HealthControllerPlayer component = collision.gameObject.GetComponent<HealthControllerPlayer>();
			if ((bool)component)
			{
				component.ApplyRecovery(recoverPoints);
				Object.Destroy(base.gameObject);
			}
		}
	}
}
