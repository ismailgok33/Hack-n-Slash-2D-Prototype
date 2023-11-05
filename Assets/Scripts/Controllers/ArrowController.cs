using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private string targetLayerName = "Player";
    [SerializeField] private Vector2 arrowVelocity;
    [SerializeField] private float travelTime = 10f;
    
    private CharacterStats _stats;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (travelTime <= 0)
            Destroy(gameObject);
        else
            travelTime -= Time.deltaTime;
        
        rb.velocity = arrowVelocity;
    }

    public void SetupArrow(Vector2 speed,CharacterStats stats)
    {
        arrowVelocity = speed;
        _stats = stats;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.GetComponent<CharacterStats>()?.IsInvincible == true)
        //     return;
        //
        // if (collision.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        //     _stats.DoDamage(collision.GetComponent<CharacterStats>());

        if (collision.GetComponent<Player>() == null) return;
        
        var target = collision.GetComponent<PlayerStats>();
        _stats.DoDamage(target);
        travelTime = 0;
    }
}
