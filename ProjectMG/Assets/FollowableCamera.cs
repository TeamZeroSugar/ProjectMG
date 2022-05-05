using UnityEngine;

public class FollowableCamera : MonoBehaviour
{
    public float followSpeed = 0.1f;
    public float zVariable = -10;
    public Transform targetTransform;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (targetTransform != null)
        {
            Vector3 targetVector = new Vector3(targetTransform.position.x, targetTransform.position.y, zVariable);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetVector, followSpeed);
        }
    }
}
