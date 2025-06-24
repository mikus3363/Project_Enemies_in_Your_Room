using UnityEngine;

public class FollowHeadUI : MonoBehaviour
{
    public Transform head;
    public Vector3 offset = new Vector3(0, 0.2f, 2.0f); // 2m przed twarz¹, lekko wy¿ej

    void LateUpdate()
    {
        if (!head) return;

        Vector3 targetPos = head.position + head.forward * offset.z + Vector3.up * offset.y;
        transform.position = targetPos;

        Quaternion lookRotation = Quaternion.LookRotation(transform.position - head.position);
        transform.rotation = lookRotation;
    }
}
