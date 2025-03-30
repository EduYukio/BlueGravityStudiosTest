using UnityEngine;

public class Player : MonoBehaviour
{

    //check all public and privates
    public PlayerBaseState CurrentState { get; set; }

    public readonly PlayerIdleState IdleState = new();
    public readonly PlayerWalkingState WalkingState = new();
    public readonly PlayerInteractingState InteractingState = new();

    public Rigidbody2D Rb { get; set; }
    public Animator Animator { get; set; }

    public readonly float moveSpeed = 6f;
    public IInteractable interactableObjectInRange;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentState.Update(this);

        // Debug code
        // string debugState = CurrentState.GetType().Name;
        // Debug.Log(debugState);
    }

    void FixedUpdate()
    {
        CurrentState.FixedUpdate(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var interactableObject = collision.GetComponent<IInteractable>();
        bool playerDontHaveInteractableObject = interactableObjectInRange == null;
        if (interactableObject != null && playerDontHaveInteractableObject)
        {
            interactableObjectInRange = interactableObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        var interactableObject = collision.GetComponent<IInteractable>();
        bool playerHasInteractableObject = interactableObjectInRange != null;
        if (interactableObject != null && playerHasInteractableObject)
        {
            interactableObjectInRange = null;
        }
    }

    public void TransitionToState(PlayerBaseState state)
    {
        CurrentState = state;
        CurrentState.OnEnterState(this);
    }

    public void SetLinearVelocity(Vector2 velocity)
    {
        Rb.linearVelocity = velocity;
    }

    public void PlayAnimation(string animationName)
    {
        Animator.Play(animationName);
    }

    public void Interact()
    {
        interactableObjectInRange.Interact();
    }
}
