using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(Player player);
    public virtual void Update(Player player) { }
    public virtual void FixedUpdate(Player player) { }

    public virtual bool CheckTransitionToIdle(Player player)
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        //talvez adicionar valor um pouco maior que 0 pra gamepads sensíveis
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
}
