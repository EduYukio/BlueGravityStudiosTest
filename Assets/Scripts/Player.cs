using UnityEngine;

public class Player : MonoBehaviour
{

    //check all public and privates
    public PlayerBaseState CurrentState { get; set; }

    public readonly PlayerIdleState IdleState = new PlayerIdleState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();

    public Rigidbody2D Rb { get; set; }
    public Animator Animator { get; set; }

    public readonly float moveSpeed = 6f;

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

    public void TransitionToState(PlayerBaseState state)
    {
        CurrentState = state;
        CurrentState.EnterState(this);
    }

    public void SetLinearVelocity(Vector2 velocity)
    {
        Rb.linearVelocity = velocity;
    }

    public void PlayAnimation(string animationName)
    {
        Animator.Play(animationName);
    }
}
