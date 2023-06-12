using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    public PlayerDefensiveState defensiveState { get; private set; }
    public bool isMoveButtonPressed { get; private set; }
    public bool isAttackButtonPressed { get; private set; }
    public bool isJumpButtonPressed { get; private set; }
    public bool isDefenceButtonPressed { get; private set; }
    public bool isMoving;
    public bool isAttacking;
    public bool isGrounded;
    public bool isDefending;
    public bool canMove { get; private set; }
    public bool canJump { get; private set; }
    public bool canAttack { get; private set; }
    public bool canDefend { get; private set; }

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        airState = new PlayerAirState(this, stateMachine, "Air");
        attackState = new PlayerAttackState(this, stateMachine, "Attack");
        defensiveState = new PlayerDefensiveState(this, stateMachine, "Defence");
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        isMoveButtonPressed = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        isAttackButtonPressed = Input.GetKeyDown(KeyCode.Mouse0);
        isJumpButtonPressed = Input.GetKeyDown(KeyCode.Space);
        isDefenceButtonPressed = Input.GetKey(KeyCode.Mouse1);
        // example
        canMove = isMoveButtonPressed && !isAttacking && isGrounded && !isDefending;
        canJump = isJumpButtonPressed && isGrounded && !isAttacking && !isDefending;
        // 地面にいる時だけが攻撃可能にする（空中の攻撃の状態をAirAttackにする)
        canAttack = isAttackButtonPressed && isGrounded && !isDefending && !isAttacking;
        canDefend = isDefenceButtonPressed && isGrounded && !isAttacking;
        stateMachine.currentState.Update();
    }
}