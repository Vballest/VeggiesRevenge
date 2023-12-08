using UnityEngine;
using UnityEngine.UI;

public class HealthControllerPlayer : MonoBehaviour
{
	[SerializeField]
	private GameObject healthPanel;

	[SerializeField]
	private RectTransform healthBar;

	[SerializeField]
	private Text healthText;

	[SerializeField]
	public GameObject whatIsPlayer;

	private float healthBarStartWidth;

	private float currentHealth;

	[SerializeField]
	public float maxHealth;

	[SerializeField]
	private float respawnTime;

	private MeshRenderer meshRenderer;

	public static bool isDead;

	[Header("Damage overlay")]
	public Image overlay;

	public float duration;

	public float fadeSpeed;

	private float durationTimer;

	[Header("Damage camera shake")]
	public Camera Camera;

	public float shakeDuration;

	public float shakeAmount = 0.7f;

	public float decreaseFactor = 1f;

	public float shakeDurationLocal;

	[Header("Health overlay")]
	public Image overlayHealth;

	public float durationHealth;

	public float fadeSpeedHealth;

	private float durationTimerHealth;

	private void Update()
	{
		damageOverlay();
		healthOverlay();
		shakeCamera();
	}

	private void Start()
	{
		healthBarStartWidth = healthBar.sizeDelta.x;
		meshRenderer = GetComponent<MeshRenderer>();
		ResetHealth();
		UpdateHealthUI();
	}

	public void ApplyDamage(float damage)
	{
		if (!isDead)
		{
			currentHealth -= damage;
			shakeDurationLocal = shakeDuration;
			overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.3f);
			durationTimer = 0f;
			if (currentHealth <= 0f)
			{
				currentHealth = 0f;
				isDead = true;
			}
			UpdateHealthUI();
		}
	}

	public void ApplyRecovery(float revovery)
	{
		if (currentHealth < maxHealth)
		{
			currentHealth += revovery;
			currentHealth = ((currentHealth <= maxHealth) ? currentHealth : maxHealth);
			shakeDurationLocal = shakeDuration;
		}
		overlayHealth.color = new Color(overlayHealth.color.r, overlayHealth.color.g, overlayHealth.color.b, 0.3f);
		UpdateHealthUI();
	}

	private void ResetHealth()
	{
		isDead = false;
		currentHealth = maxHealth;
		meshRenderer.enabled = true;
		healthPanel.SetActive(value: true);
		UpdateHealthUI();
		overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0f);
		overlayHealth.color = new Color(overlayHealth.color.r, overlayHealth.color.g, overlayHealth.color.b, 0f);
	}

	private void UpdateHealthUI()
	{
		float x = currentHealth / maxHealth * 100f / 100f * healthBarStartWidth;
		healthBar.sizeDelta = new Vector2(x, healthBar.sizeDelta.y);
		healthText.text = currentHealth + "/" + maxHealth;
	}

	private void shakeCamera()
	{
		if (shakeDurationLocal > 0f)
		{
			Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y * (Random.Range(-0.1f, 0.1f) * shakeAmount), Camera.transform.position.z);
			shakeDurationLocal -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDurationLocal = 0f;
		}
	}

	private void damageOverlay()
	{
		if (overlay.color.a > 0f)
		{
			durationTimer += Time.deltaTime;
			if (durationTimer > duration)
			{
				float a = overlay.color.a;
				a -= Time.deltaTime * fadeSpeed;
				overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, a);
			}
		}
	}

	private void healthOverlay()
	{
		if (overlayHealth.color.a > 0f)
		{
			durationTimerHealth += Time.deltaTime;
			if (durationTimerHealth > durationHealth)
			{
				float a = overlayHealth.color.a;
				a -= Time.deltaTime * fadeSpeed;
				overlayHealth.color = new Color(overlayHealth.color.r, overlayHealth.color.g, overlayHealth.color.b, a);
			}
		}
	}
}
