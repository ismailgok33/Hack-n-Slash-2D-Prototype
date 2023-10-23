using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public bool isBusy { private set; get; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    private float defaultMoveSpeed;
    
    [Header("Combat info")]
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    
    [Header("Dash info")]   
    public float dashSpeed;
    public float dashDuration;
    private float defaultDashSpeed;
    public float dashDir { get; private set; }
 
    private PlayerControls _playerControls;
    
    public PlayerStateMachine StateMachine { get; private set; }
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerPrimaryAttackState PrimaryAttackState { get; private set; }
    public PlayerDashState PlayerDashState { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        _playerControls = new PlayerControls();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle", _playerControls);
        MoveState = new PlayerMoveState(this, StateMachine, "Move", _playerControls);
        PrimaryAttackState = new PlayerPrimaryAttackState(this, StateMachine, "Attack", _playerControls);
        PlayerDashState = new PlayerDashState(this, StateMachine, "Dash", _playerControls);
    }
    
    protected override void Start()
    {
        base.Start();
        
        // skill = SkillManager.instance;

        StateMachine.Initialize(IdleState);

        defaultMoveSpeed = moveSpeed;
        defaultDashSpeed = dashSpeed;
    }

    protected override void Update()
    {
        if (Time.timeScale == 0)
            return;

        base.Update();
        
        StateMachine.currentState.Update();
    }

    public IEnumerator BusyFor(float seconds)
    {
        isBusy = true;        

        yield return new WaitForSeconds(seconds);
        isBusy = false;
    }
    
    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();

    public void DoDamage(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }
    
    public override void Die()
    {
        base.Die();

        // stateMachine.ChangeState(deadState);
        
        _playerControls.Disable();
    }
    
    private void OnEnable()
    {
        _playerControls.Enable();
    }
}
