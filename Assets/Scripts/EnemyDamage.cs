using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage = 5f;
    [SerializeField] private float damageInterval = 1f;
    private float timer;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (animator != null) animator.SetTrigger("Attack");

            Health hp = collision.gameObject.GetComponent<Health>();
            if (hp != null) hp.TakeDamage(damage);
            timer = damageInterval;
        }
    }
}
