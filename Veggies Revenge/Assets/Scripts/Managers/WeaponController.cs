/* WeaponController.cs */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private string enemyTag;

    private bool fire;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            fire = false;
            weapon.cooldown = false;
        }

        if (fire)
        {
            weapon.Fire(enemyTag);
            //fire = false;

            if (weapon.UseTap())
            {
                fire = false;
            }
        }
    }
}