using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.isMoving = true;
        Debug.Log("プレイヤーが移動し始めた");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("プレイヤーが移動中です");
        // 移動中にできること　：　攻撃＆ジャンプ＆防御＆移動を停止
        //　移動をやめる
        if (!_player.canMove)
        {
            _player.stateMachine.ChangeState(_player.idleState);
        }

        //　攻撃をする
        if (_player.canAttack)
        {
            _player.stateMachine.ChangeState(_player.attackState);
        }

        // 防御をする
        if (_player.canDefend)
        {
            _player.stateMachine.ChangeState(_player.defensiveState);
        }

        // ジャンプをする
        if (_player.canJump)
        {
            _player.stateMachine.ChangeState(_player.airState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _player.isMoving = false;
        Debug.Log("プレイヤーが移動を停止した");
    }
}