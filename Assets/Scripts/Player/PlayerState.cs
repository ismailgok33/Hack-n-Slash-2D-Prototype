using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected PlayerControls _playerControls;
    
    protected Rigidbody2D rb;
    
    protected float xInput;
    protected float yInput;
    private string _animBoolName;
    
    protected float stateTimer;
    protected bool triggerCalled;
    
    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this._animBoolName= animBoolName;
        _playerControls = playerControls;
    }
    
    public virtual void Enter()
    {
        player.anim.SetBool(_animBoolName, true);
        rb = player.rb;
        triggerCalled = false;
    }
    
    public virtual void Update()
    {
        if (GameManager.Instance.gameIsPaused)
            return;
        
        stateTimer -= Time.deltaTime;
        
        var moveInput = _playerControls.Movement.Move.ReadValue<Vector2>().normalized;

        xInput = moveInput.x;
        yInput = moveInput.y;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(_animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
    
}
