using UnityEngine;

public abstract class PlayerBaseState
{
    public virtual void OnEnterState(Player player) { }
    public virtual void Update(Player player) { }
    public virtual void FixedUpdate(Player player) { }

    public virtual bool CheckTransitionToIdle(Player player)
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        if (xInput == 0 && yInput == 0)
        {
            player.TransitionToState(player.IdleState);
            return true;
        }

        return false;
    }

    public virtual bool CheckTransitionToWalking(Player player)
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        if (xInput != 0 || yInput != 0)
        {
            player.TransitionToState(player.WalkingState);
            return true;
        }

        return false;
    }

    public virtual bool CheckTransitionToInteracting(Player player)
    {
        if (Input.GetButtonDown("Interact") && player.interactableObjectInRange != null)
        {
            player.TransitionToState(player.InteractingState);
            return true;
        }

        return false;
    }
}
