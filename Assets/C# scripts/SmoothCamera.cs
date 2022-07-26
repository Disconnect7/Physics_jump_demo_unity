using UnityEngine;


public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    [SerializeField] [Range(0, 1)] float SmoothRate;

    private void FixedUpdate()
    {
        Vector3 destinationPosition = target.position + offset;
        Vector3 SmothedPosition = Vector3.Lerp(transform.position, destinationPosition, SmoothRate);
        transform.position = new Vector3 (offset.x, SmothedPosition.y, 0);
                
    }
}
