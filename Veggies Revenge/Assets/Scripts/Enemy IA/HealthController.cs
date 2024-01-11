/* HealthController.cs */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
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

    public GameObject explosion;
    public GameObject blood;

    public AudioSource DamageSoundAudisource;
	public AudioClip DamageSoundEnemy;

    // Start is called before the first frame update
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

        GameObject bloodAnimation = Object.Instantiate(blood, gameObject.transform.position, base.transform.rotation);
        bloodAnimation.SetActive(true);

        if(!DamageSoundAudisource.isPlaying)
        {
            DamageSoundAudisource.PlayOneShot (DamageSoundEnemy);
        }

        // When recive damage, the enemy goes to the player position
        // Only for Enemy not for Player
        if (GetComponent<EnemyAI>())
        {
            GetComponent<EnemyAI>().ParmPlayerIsAttacking(true);
            GetComponent<EnemyAI>().ChasePlayer();
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            meshRenderer.enabled = false;
            healthPanel.SetActive(false);

            /*
            StartCoroutine(RespawnAfterTime());
            foreach (Transform child in transform)
            {
                child.gameObject.SetActiveRecursively(false);
            }
            */

            GameObject explosionAnimation = Object.Instantiate(explosion, gameObject.transform.position, base.transform.rotation);
            explosionAnimation.SetActive(true);

            whatIsPlayer.GetComponent<ScoreManager>().updateScore();
            Destroy(gameObject);
        }

        UpdateHealthUI();
    }

    IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTime);
        ResetHealth();
    }

    private void ResetHealth()
    {
        isDead = false;
        currentHealth = maxHealth;
        meshRenderer.enabled = true;
        healthPanel.SetActive(true);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {        
        float percentOutOf = (currentHealth / maxHealth) * 100;
        float newWidth = (percentOutOf / 100f) * healthBarStartWidth;

        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        healthText.text = currentHealth + "/" + maxHealth;
    }
}