using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.isAttacking = true;
        Debug.Log("プレイヤーが攻撃を仕掛けた");
    }

    public override void Update()
    {
        base.Update();
        //　攻撃しているときにできること：　攻撃をやめること以外に何もできない　
        // アニメーションが実装されている場合は if (!_player.isAttacking) changeState -> idleState;
        // Animation Events -> Attack Animation End　というアニメーションイベント設置して攻撃を終了する   
        if (!_player.isAttackButtonPressed)
        {
            _player.stateMachine.ChangeState(_player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _player.isAttacking = false;
        Debug.Log("プレイヤーが攻撃をやめた");
    }

    // イベント
    public void AttackAnimationEnd()
    {
        this.Exit();
    }
}