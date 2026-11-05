using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector2 tileSize;

    private void Awake()
    {
        // Kích thước 1 ô nền (theo đơn vị Unity)
        tileSize = GetComponent<SpriteRenderer>().sprite.bounds.size;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // Làm tròn theo từng ô để họa tiết khớp liền mạch, không bị giật
        float x = Mathf.Round(target.position.x / tileSize.x) * tileSize.x;
        float y = Mathf.Round(target.position.y / tileSize.y) * tileSize.y;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
