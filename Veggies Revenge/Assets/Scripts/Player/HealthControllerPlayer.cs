/* HealthController.cs */
using System.Collections;
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
    private float maxHealth;

    [SerializeField]
    private float respawnTime;
    private MeshRenderer meshRenderer;
    private bool isDead;

    [Header("Damage overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float durationTimer;

    [Header("Damage camera shake")]
    public Camera Camera;
    public float shakeDuration = 0.0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public float shakeDurationLocal;

    [Header("Health overlay")]
    public Image overlayHealth;
    public float durationHealth;
    public float fadeSpeedHealth;
    private float durationTimerHealth;

    void Update()
    {
        damageOverlay();
        healthOverlay();
        shakeCamera();
    }

    void Start()
    {
        healthBarStartWidth = healthBar.sizeDelta.x;
        meshRenderer = GetComponent<MeshRenderer>();
        ResetHealth();
        UpdateHealthUI();
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        shakeDurationLocal = shakeDuration;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.3f);
        durationTimer = 0;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }

        UpdateHealthUI();
    }

    public void ApplyRecovery(float revovery)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += revovery;
            currentHealth = currentHealth <= maxHealth ? currentHealth : maxHealth;
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
        healthPanel.SetActive(true);
        UpdateHealthUI();
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        overlayHealth.color = new Color(overlayHealth.color.r, overlayHealth.color.g, overlayHealth.color.b, 0);
    }

    private void UpdateHealthUI()
    {        
        float percentOutOf = (currentHealth / maxHealth) * 100;
        float newWidth = (percentOutOf / 100f) * healthBarStartWidth;

        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        healthText.text = currentHealth + "/" + maxHealth;
    }
    private void shakeCamera()
    {
        if (shakeDurationLocal > 0)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y * (Random.Range(-0.1f, 0.1f) * shakeAmount), Camera.transform.position.z);
            shakeDurationLocal -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDurationLocal = 0.0f;
        }
    }

    private void damageOverlay()
    {
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                // Fade image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    private void healthOverlay()
    {
        if (overlayHealth.color.a > 0)
        {
            durationTimerHealth += Time.deltaTime;
            if (durationTimerHealth > durationHealth)
            {
                // Fade image
                float tempAlpha = overlayHealth.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlayHealth.color = new Color(overlayHealth.color.r, overlayHealth.color.g, overlayHealth.color.b, tempAlpha);
            }
        }
    }
}