using UnityEngine;

public class AddWeapontInventory : MonoBehaviour
{
	[Header("Weapon")]
	public Weapon Weapon;

	private WeaponController WeaponController;

	private void OnCollisionEnter(Collision collision)
	{
		if (!(collision.gameObject.tag == "Player"))
		{
			return;
		}
		WeaponController = collision.gameObject.GetComponent<WeaponController>();
		if ((bool)WeaponController)
		{
			if (Weapon.tag == "Pistol")
			{
				WeaponController.PistolInventory = collision.gameObject.GetComponent<WeaponController>().PistolStock;
				WeaponController.weapon = WeaponController.PistolInventory;
				WeaponController.SelecWeapon(1);
			}
			if (Weapon.tag == "Shotgun")
			{
				WeaponController.ShotGunInventory = collision.gameObject.GetComponent<WeaponController>().ShotGunStock;
				WeaponController.weapon = WeaponController.ShotGunInventory;
				WeaponController.SelecWeapon(2);
			}
			if (Weapon.tag == "Machinegun")
			{
				WeaponController.MachineGunInventory = collision.gameObject.GetComponent<WeaponController>().MachineGunStock;
				WeaponController.weapon = WeaponController.MachineGunInventory;
				WeaponController.SelecWeapon(3);
			}
			Object.Destroy(base.gameObject);
		}
	}
}
