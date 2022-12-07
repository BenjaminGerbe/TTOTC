using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
    [Header("Compenents")] 
    public PlayerInput playerInput;
    
    [Header("Values")] 
    public float acceleration;
    public float drag;    
    //some private var
    private Vector2 direction;
    private Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.drag = drag;
    }

   
    void Update()
    {
        direction = playerInput.actions["Deplacement"].ReadValue<Vector2>();   // get direction input
    }


    private void FixedUpdate()
    {
        if (  direction.x != 0 || direction.y != 0)
        {
            rigidBody.AddForce(direction.normalized*acceleration,ForceMode2D.Impulse);
        }
    }
}
