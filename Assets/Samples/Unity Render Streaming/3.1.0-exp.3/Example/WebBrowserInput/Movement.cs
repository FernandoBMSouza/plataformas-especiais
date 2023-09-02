using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector3 movement;
    private Rigidbody rigidbody;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        playerInput.actions["Movement"].started += Move;
        playerInput.actions["Movement"].canceled += Stop;
    }

    private void OnDisable()
    {
        playerInput.actions["Movement"].started -= Move;
        playerInput.actions["Movement"].canceled -= Stop;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movement * Time.deltaTime * 5;
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = new Vector3(context.ReadValue<Vector2>().x/4,
            0f, context.ReadValue<Vector2>().y/4);
    }

    public void Stop(InputAction.CallbackContext context)
    {
        movement = new Vector3(0f, 0f, 0f);
    }

    public void jump(InputAction.CallbackContext context)
    {
        rigidbody.AddForce(new Vector3(0, 10*10f, 0));
    }
}
