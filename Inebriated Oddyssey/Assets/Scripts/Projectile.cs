using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject launcherObj;

    public float speed = 1f;

    private bool exists;

    private Rigidbody2D thisRB;
    private Animator animator;

    private ProjectileLauncher launcher;

    private GenericTimer existTimer = new GenericTimer();
    private string timerStatus;

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
        thisRB = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        launcher = launcherObj.GetComponent<ProjectileLauncher>();

        exists = true;
    }

    void FixedUpdate()
    {
        if(exists)
        {
            Movement(thisDirection);
        }

        timerStatus = existTimer.Timer(5);
        if(timerStatus == "complete")
        {
            StartCoroutine(DestroyAnim(0.8f));
        }
    }
    #endregion

    void Movement(Vector3 direction)
    {
        thisRB.AddForce(speed * direction);
    }

    public void GetDirection(int whichDirection)
    {
        thisDirection = directions[whichDirection];
    }

    #region Animations
    IEnumerator DestroyAnim(float seconds)
    {
        animator.SetBool("Explode", true);
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    #endregion
}
