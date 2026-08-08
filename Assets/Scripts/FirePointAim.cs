using UnityEngine;

public class FirePointAim : MonoBehaviour
{
    public Camera mainCamera;
    public float rotationSpeed = 25f;

    void Update()
    {
        AimAtCursor();
    }

    void AimAtCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(50f);
        }

        Vector3 direction = (targetPoint - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = targetRotation;
    }
}