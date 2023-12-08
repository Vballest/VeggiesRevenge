using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	public Vector2 turn;

	public float rotationSpeed;

	public Camera cam;

	private Quaternion rotation;

	private void Start()
	{
	}

	private void Update()
	{
		rotation = new Quaternion(cam.transform.rotation.x / 100f, cam.transform.rotation.y, cam.transform.rotation.z, cam.transform.rotation.w);
		base.transform.rotation = rotation;
	}
}
