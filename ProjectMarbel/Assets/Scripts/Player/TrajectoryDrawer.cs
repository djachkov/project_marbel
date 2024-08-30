using UnityEngine;
using Cinemachine;

public class TrajectoryDrawer : MonoBehaviour
{
    [SerializeField]
    private CinemachineFreeLook Camera;
    [SerializeField]
    private Rigidbody Marbel;
    [SerializeField]
    private LineRenderer LineRenderer;
    [SerializeField]
    private Transform ReleasePosition;


    [SerializeField]
    private int LinePoints = 25;

    [SerializeField]
    private float TimeBetweenPoints = 0.1f;

    private Transform InitialParent;
    private Vector3 InitialLocalPosition;
    private Quaternion InitialRotation;
    private LayerMask collisionMask;
    private void Awake()
    {
        InitialParent = Marbel.transform.parent;
        InitialRotation = Marbel.transform.localRotation;
        InitialLocalPosition = Marbel.transform.localPosition;

        int layer = Marbel.gameObject.layer;
        for (int i = 0; i < 32; i++)
        {
            if (!Physics.GetIgnoreLayerCollision(layer, i))
            {
                collisionMask |= 1 << i; // magic
            }
        }
    }
    public void DrawProjection(Vector3 velocity)
    {
        LineRenderer.enabled = true;
        LineRenderer.positionCount = Mathf.CeilToInt(LinePoints / TimeBetweenPoints) + 1;
        Vector3 startPosition = ReleasePosition.position;
        int i = 0;
        LineRenderer.SetPosition(i, startPosition);
        for (float time = 0; time < LinePoints; time += TimeBetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * velocity;
            point.y = startPosition.y + velocity.y * time + (Physics.gravity.y / 2f * time * time);

            LineRenderer.SetPosition(i, point);

            Vector3 lastPosition = LineRenderer.GetPosition(i - 1);

            if (Physics.Raycast(lastPosition,
                (point - lastPosition).normalized,
                out RaycastHit hit,
                (point - lastPosition).magnitude,
                collisionMask))
            {
                LineRenderer.SetPosition(i, hit.point);
                LineRenderer.positionCount = i + 1;
                return;
            }
        }
    }
}