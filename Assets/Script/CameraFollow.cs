using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offSet;

    private void Start()
    {
        offSet = transform.position - target.position;
    }

    private void LateUpdate()
    {

        transform.position = new Vector3(target.position.x + offSet.x, offSet.y, target.position.z + offSet.z);
    }
}
