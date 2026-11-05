using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackInterval = 0.5f;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0f) return;

        // Tìm mọi collider trong tầm đánh
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == gameObject) continue;
            Health hp = hit.GetComponent<Health>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
        timer = attackInterval;
    }

    // Vẽ vòng tròn tầm đánh trong Scene để dễ chỉnh
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
