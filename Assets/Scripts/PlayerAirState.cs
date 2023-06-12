using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.isGrounded = false;
        Debug.Log("プレイヤーが空中にいる");
    }

    public override void Update()
    {
        base.Update();
        // 空中にできること　：　空中ダッシュ、二段ジャンプ、空中攻撃など
        // isGrounded
        if (_player.isGrounded)
        {
            _player.stateMachine.ChangeState(_player.idleState);
        }
        // if (canDash) changestate -> dash
        // ...
        // if (canJump) -> toJump() もう一回ジャンプする また、canJump = jumpCount <= CountLimitという条件を加える
        // ...
        // if (canAttack) changestate -> AirAttack 
        // ...
    }

    public override void Exit()
    {
        base.Exit();
        _player.isGrounded = true;
        Debug.Log("プレイヤーが地面に着いた");
    }
}