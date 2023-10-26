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

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;
    
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
            attackCheck.localPosition = new Vector3(1f, 0, 0);
        else
            attackCheck.localPosition = new Vector3(0, yInput, 0);
    }

    public virtual void SetupDefaultFacingDir(int direction)
    {
        facingDir = direction;

        if (facingDir == -1)
            facingRight = false;
    }
    
    public virtual void Die()
    {

    }
}
