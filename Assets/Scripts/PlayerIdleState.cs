using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.isGrounded = true;
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("プレイヤーがIdle状態です");
        if (_player.canMove)
        {
            _player.stateMachine.ChangeState(_player.moveState);
        }

        if (_player.canJump)
        {
            _player.stateMachine.ChangeState(_player.airState);
        }

        if (_player.canDefend)
        {
            _player.stateMachine.ChangeState(_player.defensiveState);
        }

        if (_player.canAttack)
        {
            _player.stateMachine.ChangeState(_player.attackState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }
}