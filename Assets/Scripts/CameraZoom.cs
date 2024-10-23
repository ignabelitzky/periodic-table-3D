using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomSpeed = 10f;
    public float minFieldOfView = 30f;
    public float maxFieldOfView = 60f;

    void Update()
    {
        if (virtualCamera != null)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            virtualCamera.m_Lens.FieldOfView -= scrollInput * zoomSpeed;
            virtualCamera.m_Lens.FieldOfView = Mathf.Clamp(virtualCamera.m_Lens.FieldOfView, minFieldOfView, maxFieldOfView);
        }
    }
}
