using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public SpriteRenderer sr { get; private set; }
    public CharacterStats stats { get; private set; }
    public CapsuleCollider2D cd { get; private set; }
    
    [Header("Collision info")]
    public Transform attackCheck;
    public float attackCheckRadius = 1.2f;

    public int facingDir { get; set; } = 1;
    protected bool facingRight = true;
    public Vector2 facingDirection { get; set; } = Vector2.right;
    private Vector2 lastFacingDirection = Vector2.right;
    
    protected virtual void Awake()
    {

    }
    
    protected virtual void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        cd = GetComponent<CapsuleCollider2D>();
    }
    
    protected virtual void Update()
    {

    }
    
    public void SetZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }
    
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    
    public virtual void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        // transform.Rotate(0, 180, 0);
        transform.localScale = new Vector3(facingRight ? 1 : -1, 1, 1);
    }
    
    public virtual void FlipController(float xInput)
    {
        if (xInput > 0 && !facingRight)
            Flip();
        else if (xInput < 0 && facingRight)
            Flip();
    }
    
    public virtual void PositionAttackCheck(float xInput, float yInput)
    {
        if (xInput > 0)
            attackCheck.localPosition = new Vector3(xInput, yInput, 0);
        else if (xInput < 0)
            attackCheck.localPosition = new Vector3(-xInput, yInput, 0);
        else if (xInput == 0 && yInput == 0)
        {
            attackCheck.localPosition = new Vector3(1f, 0, 0);
            facingDirection = lastFacingDirection;
            return;
        }
        else
            attackCheck.localPosition = new Vector3(0, yInput, 0);
        
        facingDirection = new Vector2(xInput, yInput);
        lastFacingDirection = facingDirection;
    }

    public virtual void SetupDefaultFacingDir(int direction)
    {
        facingDir = direction;

        if (facingDir == -1)
            facingRight = false;
    }
    
    protected virtual void ReturnDefaultSpeed()
    {
        anim.speed = 1;
    }
    
    public virtual void Die()
    {

    }
}
