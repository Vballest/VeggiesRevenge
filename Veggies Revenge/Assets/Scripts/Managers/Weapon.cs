using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	public float damage;

	[SerializeField]
	private float fireRate;

	[SerializeField]
	public float autoDestroyTime;

	[SerializeField]
	private Transform bulletPoint;

	public bool cooldown;

	public Rigidbody bullet;

	public float bulletSpeed = 10f;

	public AudioSource AudioSource;
	public AudioClip ShootSound;

	public void Fire()
	{
		if (cooldown)
		{
			return;
		}

		AudioSource.PlayOneShot(ShootSound);

		if ((bool)bullet && bullet.GetComponent<Rigidbody>() != null)
		{
			Rigidbody rigidbody = Object.Instantiate(bullet, bulletPoint.position, base.transform.rotation);
			autoDestroy component = rigidbody.gameObject.GetComponent<autoDestroy>();
			if ((bool)component)
			{
				component.autoDestroyTime = autoDestroyTime;
			}
			rigidbody.velocity = base.transform.forward * bulletSpeed;
		}
		cooldown = true;
		StartCoroutine(StopCooldownAfterTime());
	}

	private IEnumerator StopCooldownAfterTime()
	{
		yield return new WaitForSeconds(fireRate);
		cooldown = false;
	}

	public bool UseTap()
	{
		return fireRate == 0f;
	}
}
