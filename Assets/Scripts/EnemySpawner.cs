
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float spawnRadius = 12f;

    private float timer;

    private void Update()
    {
        if (player == null || enemyPrefab == null) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Chọn một hướng ngẫu nhiên, đặt kẻ địch cách nhân vật đúng spawnRadius
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + direction * spawnRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}