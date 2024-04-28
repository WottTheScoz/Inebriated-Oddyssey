using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject launcherObj;

    public bool movementOn = true;
    public bool boomerang;

    public float speed = 0.1f;

    public int DamageOutput = -1;

    [Space(20)]
    public float existanceTime = 5;
    public float destroyAnimTime = 0.8f;

    private Animator animator;

    private ProjectileLauncher launcher;

    private GenericTimer existTimer = new GenericTimer();
    private string timerStatus;

    private Vector3 position;

    private Vector3 thisDirection;
    Vector3[] directions = new Vector3[]
    {
        Vector3.right, 
        Vector3.up, 
        Vector3.left, 
        Vector3.down
    };

    #region Unity Methods
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        launcher = launcherObj.GetComponent<ProjectileLauncher>();

        if(boomerang)
        {
            speed *= -1;
        }
    }

    void FixedUpdate()
    {
        if(movementOn)
        {
            Movement(thisDirection, boomerang);
        }

        timerStatus = existTimer.Timer(existanceTime);
        if(timerStatus == "complete")
        {
            StartCoroutine(DestroyAnim(destroyAnimTime));
        }
    }
    #endregion

    #region Movement
    void Movement(Vector3 direction, bool shouldBoomerang)
    {
        if(shouldBoomerang == true)
        {
            gameObject.transform.position += ((-(speed * speed / 2) + (speed)) * direction);
            speed += 0.002f;
        }
        else
        {
            gameObject.transform.position += (speed * direction);
        }
    }

    public void GetDirection(int whichDirection)
    {
        thisDirection = directions[whichDirection];
    }
    #endregion

    #region Collision
    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag.ToLower() == "player")
        {
            StartCoroutine(DestroyAnim(destroyAnimTime));
        }
    }
    #endregion

    #region Animations
    IEnumerator DestroyAnim(float seconds)
    {
        movementOn = false;
        animator.SetBool("Explode", true);
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    #endregion
}
