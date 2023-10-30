using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public bool isBusy { private set; get; }
    [Header("Move info")]
    public float moveSpeed = 12f;
    public float defaultMoveSpeed;
    
    public Transform stumpAttackCheck;
    public Vector3 stumpAttackCheckSize = new Vector3(3, 1);
    
    [Header("Combat info")]
    // [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
 
    private PlayerControls _playerControls;
    
    public PlayerStateMachine StateMachine { get; private set; }
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerPrimaryAttackState PrimaryAttackState { get; private set; }
    public PlayerDashState PlayerDashState { get; private set; }
    public PlayerDeathState PlayerDeathState { get; private set; }
    public PlayerSlideAttackState PlayerSlideAttackState { get; private set; }
    public PlayerStumpAttackState PlayerStumpAttackState { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        _playerControls = new PlayerControls();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle", _playerControls);
        MoveState = new PlayerMoveState(this, StateMachine, "Move", _playerControls);
        PrimaryAttackState = new PlayerPrimaryAttackState(this, StateMachine, "Attack", _playerControls);
        PlayerDashState = new PlayerDashState(this, StateMachine, "Dash", _playerControls);
        PlayerDeathState = new PlayerDeathState(this, StateMachine, "Die", _playerControls);
        PlayerSlideAttackState = new PlayerSlideAttackState(this, StateMachine, "SlideAttack", _playerControls);
        PlayerStumpAttackState = new PlayerStumpAttackState(this, StateMachine, "StumpAttack", _playerControls);
    }
    
    protected override void Start()
    {
        base.Start();
        
        // skill = SkillManager.instance;

        StateMachine.Initialize(IdleState);

        defaultMoveSpeed = moveSpeed;
        
        _playerControls.Combat.Dash.performed += _ => UseActiveCard();
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

    public void DoDamage(Enemy_2 enemy)
    {
        enemy.TakeDamage(damage);
    }
    
    public override void Die()
    {
        base.Die();

        StateMachine.ChangeState(PlayerDeathState);
        
        _playerControls.Disable();
    }
    
    private void UseActiveCard()
    {
        CardManager.Instance.UseActiveCard();
    }
    
    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
    
    public void SetDefaultMovementSpeed() 
    {
        moveSpeed = defaultMoveSpeed;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireCube(stumpAttackCheck.position, stumpAttackCheckSize);
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }
}
