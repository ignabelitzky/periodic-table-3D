using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class UserController : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float rotationSpeed = 100f;
    public Vector3 movementCenter = Vector3.zero;
    public float movementRadius = 50f;
    public float heightLevel = 10f;

    private UserControls controls;
    private Vector2 moveInput;

    private void Awake()
    {
        controls = new UserControls();

        // Bind input actions
        controls.User.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.User.Move.canceled += ctx => moveInput = Vector2.zero;
        controls.User.Exit.performed += ctx => TriggerExit();
    }

    private void OnEnable()
    {
        controls.User.Enable();
    }

    private void OnDisable()
    {
        controls.User.Disable();
    }

    private void TriggerExit()
    {
        StartCoroutine(TriggerElementExplosion());
    }

    public IEnumerator TriggerElementExplosion()
    {
        GameObject references = GameObject.FindGameObjectWithTag("References");
        if (references == null)
        {
            Debug.LogError("References object not found!");
            yield break;
        }
        references.GetComponent<Rigidbody>().isKinematic = false;
        references.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(5f, 15f), ForceMode.Impulse);

        GameObject informationDisplay = GameObject.FindGameObjectWithTag("InformationDisplay");
        if (informationDisplay == null)
        {
            Debug.LogError("InformationDisplay object not found!");
            yield break;
        }
        informationDisplay.GetComponent<Rigidbody>().isKinematic = false;
        informationDisplay.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(5f, 15f), ForceMode.Impulse);

        GameObject[] elements = GameObject.FindGameObjectsWithTag("Element");
        foreach (GameObject element in elements)
        {
            Rigidbody rb = element.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                Vector3 explosionDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(explosionDirection * Random.Range(5f, 15f), ForceMode.Impulse);
            }
        }
        yield return new WaitForSeconds(3f);
        Debug.Log("Quitting application...");
        Application.Quit();
    }

    private void Update()
    {
        // Camera movement
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

        // Limit the camera's position within the specified radius
        Vector3 offset = transform.position - movementCenter;
        if (offset.magnitude > movementRadius)
        {
            offset = offset.normalized * movementRadius;
            transform.position = movementCenter + offset;
        }

        // Clamp the Z position to prevent it from excedint positive values
        if (transform.position.z > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        // Clamp the Y position to the specified height level
        if (transform.position.y < heightLevel || transform.position.y > heightLevel)
        {
            transform.position = new Vector3(transform.position.x, heightLevel, transform.position.z);
        }
    }
}
