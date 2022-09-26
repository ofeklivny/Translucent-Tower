using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform rayPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //RaycastHit2D HitCeilingInGround = Physics2D.Raycast(new Vector2(rayPoint.position.x, rayPoint.position.y), Vector2.up);
            //Debug.DrawRay(new Vector2(rayPoint.position.x, rayPoint.position.y), Vector2.up, Color.red);
            //float DistanceToCeiling = HitCeilingInGround.distance;
            
            Bounds bounds = collision.bounds;
            Vector3 boundsMax = bounds.max;
            float DistanceToCeiling = Vector3.Distance(new Vector3(rayPoint.position.x, rayPoint.position.y, 0), boundsMax) ;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, DistanceToCeiling*50));
            Debug.Log("In ground checked. DistanceToCeiling = " + DistanceToCeiling + "RayHit");
        }
    }

}
