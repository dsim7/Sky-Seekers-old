
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    private Transform cameraObject;

    public float transitionSpeed = 1f;
    
    void LateUpdate()
    {
        cameraObject.transform.localPosition = Vector3.Lerp(cameraObject.transform.localPosition, transform.position, Time.deltaTime * transitionSpeed);
    }
}
