using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform rayPoint;
    Collider2D collidedObj = null;
    [SerializeField] float jumpMultiplier;
    [SerializeField] AnimationCurve DistanceToCeilingCurve;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && collidedObj)
        {
            Debug.Log("pressed");
            Bounds bounds = collidedObj.bounds;
            Vector3 boundsMax = bounds.max;
            //float DistanceToCeiling = Vector3.Distance(new Vector3(rayPoint.position.x, rayPoint.position.y, 0), boundsMax);
            float DistanceToCeiling = boundsMax.y - rayPoint.position.y;
            if (DistanceToCeiling > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                //rb.AddForce(new Vector2(0, DistanceToCeiling * jumpMultiplier));
                rb.AddForce(new Vector2(0, DistanceToCeilingCurve.Evaluate(DistanceToCeiling) * jumpMultiplier));
                rb.velocity = new Vector2(0, Mathf.Clamp(rb.velocity.y, 0, 10));
                Debug.Log("In ground checked. DistanceToCeiling = " + DistanceToCeiling);
            }

        }

        //prevent from falling off screen for debugging
        if (transform.position.y < -3.81f)
        {
            rb.velocity = Vector2.zero;
        }

    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        //RaycastHit2D HitCeilingInGround = Physics2D.Raycast(new Vector2(rayPoint.position.x, rayPoint.position.y), Vector2.up);
    //        //Debug.DrawRay(new Vector2(rayPoint.position.x, rayPoint.position.y), Vector2.up, Color.red);
    //        //float DistanceToCeiling = HitCeilingInGround.distance;

    //        //Bounds bounds = collision.bounds;
    //        //Vector3 boundsMax = bounds.max;
    //        //float DistanceToCeiling = Vector3.Distance(new Vector3(rayPoint.position.x, rayPoint.position.y, 0), boundsMax);
    //        //float DistanceToCeiling = boundsMax.y - rayPoint.position.y;
    //        //rb.velocity = new Vector2(0, 0);
    //        //rb.AddForce(new Vector2(0, DistanceToCeiling * 100));
    //        //Debug.Log("In ground checked. DistanceToCeiling = " + DistanceToCeiling + "RayHit");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedObj = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedObj = null;
    }
}
