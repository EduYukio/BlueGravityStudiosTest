using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public override void Update(Player player)
    {
        if (base.CheckTransitionToInteracting(player)) return;
        if (base.CheckTransitionToIdle(player)) return;
    }

    public override void FixedUpdate(Player player)
    {
        WalkAction(player);
    }

    private void PlayAnimation(Player player, float xInput, float yInput)
    {
        string animationDirection;
        //talvez transformar num switch?
        if (xInput > 0)
        {
            animationDirection = "WalkingRight";
        }
        else if (xInput < 0)
        {
            animationDirection = "WalkingLeft";
        }
        else if (yInput < 0)
        {
            animationDirection = "WalkingDown";
        }
        else
        {
            animationDirection = "WalkingUp";
        }

        player.PlayAnimation(animationDirection);
    }

    public void WalkAction(Player player)
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 newVelocity = new(xInput * player.moveSpeed, yInput * player.moveSpeed);
        player.SetLinearVelocity(newVelocity);

        PlayAnimation(player, xInput, yInput);
    }
}
