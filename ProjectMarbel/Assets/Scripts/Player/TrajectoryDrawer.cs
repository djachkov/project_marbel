using UnityEngine;
using Cinemachine;

public class TrajectoryDrawer : MonoBehaviour
{

    [SerializeField]
    private Rigidbody Marbel;
    [SerializeField]
    private LineRenderer LineRenderer;
    [Header("Display Controls")]
    [SerializeField]
    [Range(10, 100)]
    private int LinePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float TimeBetweenPoints = 0.1f;


    [SerializeField]
    private LayerMask MarbelCollisionMask;

    public void DisableLineRenderer()
    {
        LineRenderer.enabled = false;
    }
    public void DrawTrajectory(Vector3 marbelVelocity, Vector3 marbelPosition)
    {
        // 
        LineRenderer.enabled = true;
        LineRenderer.positionCount = Mathf.CeilToInt(LinePoints / TimeBetweenPoints) + 1;
        int i = 0;
        LineRenderer.SetPosition(i, marbelPosition);
        for (float time = 0; time < LinePoints; time += TimeBetweenPoints)
        {
            i++;
            Vector3 point = marbelPosition + time * marbelVelocity;
            point.y = marbelPosition.y + marbelVelocity.y * time + (Physics.gravity.y / 2f * time * time);

            LineRenderer.SetPosition(i, point);

            Vector3 lastPosition = LineRenderer.GetPosition(i - 1);

            if (Physics.Raycast(lastPosition,
                (point - lastPosition).normalized,
                out RaycastHit hit,
                (point - lastPosition).magnitude,
                MarbelCollisionMask))
            {
                LineRenderer.SetPosition(i, hit.point);
                LineRenderer.positionCount = i + 1;
                return;
            }
        }
    }

}
