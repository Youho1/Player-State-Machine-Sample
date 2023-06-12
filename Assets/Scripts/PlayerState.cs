using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;
    private string _animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this._player = player;
        this._stateMachine = stateMachine;
        this._animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        //Debug.Log(_animBoolName + "状態に入ります.");
    }

    public virtual void Update()
    {
        //Debug.Log((_animBoolName + "状態です!"));
    }

    public virtual void Exit()
    {
        //Debug.Log(_animBoolName + "状態から離れます.");
    }
}