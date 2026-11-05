using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0f; // 0 = bám cứng, 5-10 = bám mượt

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

        if (smoothSpeed <= 0f)
            transform.position = targetPos;
        else
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}