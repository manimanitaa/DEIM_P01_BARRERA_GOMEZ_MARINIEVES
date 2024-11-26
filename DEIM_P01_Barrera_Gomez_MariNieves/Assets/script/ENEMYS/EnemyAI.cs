using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{

    public enum EnemyState { Stopped, Mov, Follow, Attack, Dead}

    private EnemyState state;

    private float health= 3;

    private AIPath pathAgent;

    [SerializeField] private Transform playerTrf;

    [SerializeField] private float followRange;

    [SerializeField] private LayerMask followLayerMask;

    private void Awake()
    {
        pathAgent = GetComponent<AIPath>();
    }


    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Follow;

        playerTrf = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state != EnemyState.Dead)
        {
            if (health <= 0)
            {
                GoToDead();
            }
            else
            {
                switch (state) 
                {
                    case EnemyState.Stopped:

                        if (InFollowRange())
                        {
                            GoToFollow();
                        }
                        else
                        {
                            GoToStopped();
                        }
                        break;

                    case EnemyState.Mov:

                        break;

                    case EnemyState.Follow:

                        if (!InFollowRange())
                        {
                            GoToStopped();
                        }
                        else if (InAttakRange())
                        {
                            GoToAttack();
                        }
                        else
                        {
                            pathAgent.destination = playerTrf.position;
                        }
                    
                        break;

                    case EnemyState.Attack:

                        if (!InAttakRange())
                        {
                            GoToFollow();
                        }

                        break;

                }
            }
        }
    }

    private void GoToDead()
    {
        state = EnemyState.Dead;
    }

    private void GoToStopped()
    {
        state = EnemyState.Stopped;
        pathAgent.canMove = false;
    }

    private void GoToFollow()
    {
        state = EnemyState.Follow;
        pathAgent.canMove = true;
    }

    private void GoToAttack()
    {
        state = EnemyState.Attack;

        pathAgent.canMove = false;  
    }

    private bool InAttakRange()
    {
        return false;
    }


    private bool InFollowRange()
    {
        bool res = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTrf.position - transform.position, followRange, followLayerMask);

        if ((hit.collider != null) && (hit.collider.CompareTag("Player")))
        {
            res= true;
        }

        return res;
    }


}
