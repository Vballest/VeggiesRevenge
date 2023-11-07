/* Weapon.cs */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private float fireDistance = 10;

    [SerializeField]
    private Transform bulletPoint;

    private RaycastHit hit;

    public bool cooldown;

    public void Fire(string enemyTag)
    {
        if (cooldown) return;

        Ray ray = new Ray();
        ray.origin = bulletPoint.position;
        ray.direction = bulletPoint.TransformDirection(Vector3.forward);

        Debug.DrawRay(ray.origin, ray.direction * fireDistance, Color.green);

        if (Physics.Raycast(ray, out hit, fireDistance))
        {
            if (hit.collider.CompareTag(enemyTag))
            {
                var healthCtrl = hit.collider.GetComponent<HealthController>();
                if (healthCtrl)
                {
                    healthCtrl.ApplyDamage(damage);
                }
            }
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
        return fireRate == 0;
    }
}
