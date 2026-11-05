using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthBar; // chỉ gán cho player
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateBar();
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void UpdateBar()
    {
        if (healthBar != null)
            healthBar.value = currentHealth / maxHealth;
    }

    private void Die()
    {
        if (CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}