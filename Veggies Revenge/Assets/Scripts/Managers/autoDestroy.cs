using UnityEngine;

public class autoDestroy : MonoBehaviour
{
	public string enemyTag;

	public Weapon weapon;

	public float autoDestroyTime;

	private void OnCollisionEnter(Collision collision)
	{
		if (!(collision.gameObject.tag != "Weapon") || !(collision.gameObject.tag != "Player"))
		{
			return;
		}
		Debug.Log(collision.gameObject.name);
		if (collision.gameObject.tag == enemyTag)
		{
			HealthController component = collision.gameObject.GetComponent<HealthController>();
			if ((bool)component)
			{
				component.ApplyDamage(weapon.damage);
			}
		}
		if (autoDestroyTime > 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (autoDestroyTime > 0f)
		{
			Object.Destroy(base.gameObject, autoDestroyTime);
		}
	}
}
