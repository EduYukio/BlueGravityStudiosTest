using UnityEngine;

public class PlayerInteractingState : PlayerBaseState
{

    public override void OnEnterState(Player player)
    {
        InteractAction(player);
    }

    public override void Update(Player player)
    {
        if (base.CheckTransitionToIdle(player)) return;
        if (base.CheckTransitionToWalking(player)) return;
    }

    public void InteractAction(Player player)
    {
        player.Interact();
    }
}
