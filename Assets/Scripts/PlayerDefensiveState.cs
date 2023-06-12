using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefensiveState : PlayerState
{
    public PlayerDefensiveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.isDefending = true;
        Debug.Log("プレイヤーが盾を立てた");
    }

    public override void Update()
    {
        base.Update();
        //　防御している時にできること：　防御をやめる以外に何もできない 
        Debug.Log("プレイヤーが盾をずっと立てている");
        if (!_player.isDefenceButtonPressed)
        {
            _player.stateMachine.ChangeState(_player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _player.isDefending = false;
        Debug.Log("プレイヤーが防御をやめた");
    }
}