using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void OnEnterState(Player player)
    {
        IdleAction(player);
        player.PlayAnimation("Idle");
    }

    public override void Update(Player player)
    {
        if (base.CheckTransitionToInteracting(player)) return;
        if (base.CheckTransitionToWalking(player)) return;
    }

    private void IdleAction(Player player)
    {
        player.SetLinearVelocity(Vector2.zero);
    }
}
