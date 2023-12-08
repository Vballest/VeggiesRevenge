using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
	[Header("Selected weapon")]
	public Weapon weapon;

	[Header("Canvas images")]
	public Image WeaponNone;

	public Image Weapon1;

	public Image Weapon2;

	public Image Weapon3;

	[Header("Inventory")]
	[SerializeField]
	public Weapon PistolInventory;

	public Weapon ShotGunInventory;

	public Weapon MachineGunInventory;

	[Header("Available Weapon")]
	[SerializeField]
	public Weapon PistolStock;

	public Weapon ShotGunStock;

	public Weapon MachineGunStock;

	[Header("System")]
	public bool fire;

	private GameObject Pistol;

	private GameObject ShotGun;

	private GameObject MachineGun;

	private void Start()
	{
		Pistol = GameObject.Find("Pistol");
		ShotGun = GameObject.Find("Shotgun");
		MachineGun = GameObject.Find("Machinegun");
		WeaponNone.gameObject.SetActive(value: true);
		Weapon1.gameObject.SetActive(value: false);
		Weapon2.gameObject.SetActive(value: false);
		Weapon3.gameObject.SetActive(value: false);
		Pistol.SetActive(value: false);
		ShotGun.SetActive(value: false);
		MachineGun.SetActive(value: false);
	}

	private void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			SelecWeapon(1);
		}
		if (Input.GetKeyDown("2"))
		{
			SelecWeapon(2);
		}
		if (Input.GetKeyDown("3"))
		{
			SelecWeapon(3);
		}
		if (!(weapon != null))
		{
			return;
		}
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
			weapon.Fire();
			if (weapon.UseTap())
			{
				fire = false;
			}
		}
	}

	public void SelecWeapon(int _weaponNumber)
	{
		if (_weaponNumber == 1 && (bool)PistolInventory)
		{
			Debug.Log("Weapon 1");
			if ((bool)Pistol && (bool)ShotGun && (bool)MachineGun)
			{
				Pistol.SetActive(value: true);
				ShotGun.SetActive(value: false);
				MachineGun.SetActive(value: false);
				WeaponNone.gameObject.SetActive(value: false);
				Weapon1.gameObject.SetActive(value: true);
				Weapon2.gameObject.SetActive(value: false);
				Weapon3.gameObject.SetActive(value: false);
				Weapon component = Pistol.gameObject.GetComponent<Weapon>();
				if ((bool)component)
				{
					weapon = component;
				}
			}
		}
		if (_weaponNumber == 2 && (bool)ShotGunInventory)
		{
			Debug.Log("Weapon 2");
			if ((bool)Pistol && (bool)ShotGun && (bool)MachineGun)
			{
				Pistol.SetActive(value: false);
				ShotGun.SetActive(value: true);
				MachineGun.SetActive(value: false);
				WeaponNone.gameObject.SetActive(value: false);
				Weapon1.gameObject.SetActive(value: false);
				Weapon2.gameObject.SetActive(value: true);
				Weapon3.gameObject.SetActive(value: false);
				Weapon component2 = ShotGun.gameObject.GetComponent<Weapon>();
				if ((bool)component2)
				{
					weapon = component2;
				}
			}
		}
		if (_weaponNumber != 3 || !MachineGunInventory)
		{
			return;
		}
		Debug.Log("Weapon 3");
		if ((bool)Pistol && (bool)ShotGun && (bool)MachineGun)
		{
			Pistol.SetActive(value: false);
			ShotGun.SetActive(value: false);
			MachineGun.SetActive(value: true);
			WeaponNone.gameObject.SetActive(value: false);
			Weapon1.gameObject.SetActive(value: false);
			Weapon2.gameObject.SetActive(value: false);
			Weapon3.gameObject.SetActive(value: true);
			Weapon component3 = MachineGun.gameObject.GetComponent<Weapon>();
			if ((bool)component3)
			{
				weapon = component3;
			}
		}
	}
}
