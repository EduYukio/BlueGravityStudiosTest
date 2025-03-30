using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Setup(player);
        IdleAction(player);
        player.PlayAnimation("Idle");
    }

    public override void Update(Player player)
    {
        if (base.CheckTransitionToWalking(player)) return;
        //check to interact
    }

    private void Setup(Player player)
    {
    }

    private void IdleAction(Player player)
    {
        player.SetLinearVelocity(Vector2.zero);
    }
}
