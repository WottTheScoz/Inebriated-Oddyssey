using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public string enemyName;
    public int speed = 3;

    private Transform player;

    private Vector3 lastPosition;

    private Rigidbody2D ThisRB;
    private Animator animator;

    private ProjectileLauncher launcher;

    private GenericTimer attackTimer = new GenericTimer();

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Player");
        player = playerObj[0].transform;

        ThisRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        launcher = gameObject.GetComponent<ProjectileLauncher>();
    }

    void Update()
    {
        AnimateEnemy();
    }

    void FixedUpdate()
    {
        EnemyBehavior(enemyName);
    }
    #endregion

    #region Enemy Behavior
    void AnimateEnemy() //Plays left or right anim depending on current direction.
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = currentPosition - lastPosition;
        direction.Normalize();
        animator.SetFloat("Move X", direction.x);
        lastPosition = currentPosition;
    }

    void EnemyBehavior(string enemyName)
    {
        Vector3 position = ThisRB.position;
        switch(enemyName)
        {
            case "FlyingEye":
                MoveTowardsPlayer(position);
                break;
            case "Mushroom":
                MushroomStats mushroom = new MushroomStats();
                string timerStatus = attackTimer.Timer(mushroom.attackEverySeconds);
                if(timerStatus == "complete")
                {
                    StartCoroutine(AttackAnim(mushroom.attackAnimLength, mushroom.projectileAmount));
                }
                else if(timerStatus == "incomplete")
                {
                    MoveTowardsPlayer(position);
                }
                break;
            case "Goblin":
                GoblinStats goblin = new GoblinStats();
                timerStatus = attackTimer.Timer(goblin.attackEverySeconds);
                if(timerStatus == "complete")
                {
                    StartCoroutine(AttackAnim(goblin.attackAnimLength, goblin.projectileAmount));
                }
                else if(timerStatus == "incomplete")
                {
                    MoveTowardsPlayer(position);
                }
                break;
            default:
                Debug.Log("Unknown enemy type: " + enemyName);
                break;
        }
    }

    void MoveTowardsPlayer(Vector3 position)
    {
        position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        ThisRB.MovePosition(position);
    }
    #endregion

    #region Animations
    IEnumerator AttackAnim(float seconds, int projAmount)
    {
        attackTimer.TurnTimerOn(false);

        animator.SetBool("Is Attacking", true);

        yield return new WaitForSeconds(seconds);

        launcher.CreateProjectiles(projAmount);
        attackTimer.TurnTimerOn(true);

        animator.SetBool("Is Attacking", false);
    }
    #endregion
}
