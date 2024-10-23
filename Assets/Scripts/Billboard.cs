using UnityEngine;
using Cinemachine;

public class Billboard : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        if (vcam == null)
        {
            vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + vcam.transform.rotation * Vector3.forward, vcam.transform.rotation * Vector3.up);
    }
}
