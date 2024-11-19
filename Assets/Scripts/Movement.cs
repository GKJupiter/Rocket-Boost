using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 100f;
    Rigidbody rb;
    private void OnEnable() 
    {
        thrust.Enable();
        rotation.Enable(); 
    }
    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Flying to the Moon");
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput < 0)
        {
            Debug.Log("You used left key");
        }
        else if (rotationInput > 0)
        {
            Debug.Log("You used right key");
        }
        
    }
}