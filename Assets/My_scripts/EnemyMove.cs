using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    //Visible in Inspector
    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2; 
    [SerializeField] Transform Target3; 
    [SerializeField] Transform Target4;  
    [SerializeField] Transform Target5;   
    [SerializeField] Transform Target6;   
    [SerializeField] Transform Target7;   
    [SerializeField] Transform Target8;  
    [SerializeField] Transform Target9;    
    [SerializeField] Transform Target10;

    [SerializeField] int WaitTime = 0;

    [SerializeField] int EnemyNumber;

    //Not Visible In Inspector

    private int LastTarget = 1;
    private Transform TargetPosition;
    private bool Contact = false;   
    private Animator Anim;
    private int CurrentTarget = 1;
    private string TargetName;
    private string TargetDescriptor;

    // Start is called before the first frame update
    void Start()
    {

        TargetPosition = Target1;
        MoveToTarget();
        Anim = GetComponent<Animator>();
        LastTarget = CurrentTarget;
        TargetDescriptor = EnemyNumber +"targetCube1";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="EnemyTarget")
        {
            TargetName = other.GetComponent<Collider>().name;
            if (TargetName == TargetDescriptor)
            {
                if (Contact == false)
                {
                    Contact = true;
                    CurrentTarget = Random.Range(1, 11);
                    if (CurrentTarget == LastTarget)
                    {
                        tryagain();
                    }
                    else
                    {
                        StartCoroutine(waiter());
                    }

                }
            }

        }
       

    }
    void tryagain()
    {
        if(LastTarget==1)
        {
            CurrentTarget = LastTarget + 1;

        }
        else if (LastTarget > 1)
        {
            CurrentTarget = LastTarget - 1;
        }

        StartCoroutine(waiter());
    }
    void MoveToTarget()
    {
     
        if (CurrentTarget == 1)
        {
            TargetPosition = Target1;
            TargetDescriptor = EnemyNumber + "targetCube1";
        }
        if (CurrentTarget == 2)
        {
            TargetPosition = Target2;
            TargetDescriptor = EnemyNumber + "targetCube2";
        }
        if (CurrentTarget == 3)
        {
            TargetPosition = Target3;
            TargetDescriptor = EnemyNumber + "targetCube3";
        }
        if (CurrentTarget == 4)
        {
            TargetPosition = Target4;
            TargetDescriptor = EnemyNumber + "targetCube4";
        }
        if (CurrentTarget == 5)
        {
            TargetPosition = Target5;
            TargetDescriptor = EnemyNumber + "targetCube5";
        }
        if (CurrentTarget == 6)
        {
            TargetPosition = Target6;
            TargetDescriptor = EnemyNumber + "targetCube6";
        }
        if (CurrentTarget == 7)
        {
            TargetPosition = Target7;
            TargetDescriptor = EnemyNumber + "targetCube7";
        }
        if (CurrentTarget == 8)
        {
            TargetPosition = Target8;
            TargetDescriptor = EnemyNumber + "targetCube8";
        }
        if (CurrentTarget == 9)
        {
            TargetPosition = Target9;
            TargetDescriptor = EnemyNumber + "targetCube9";
        }
        if (CurrentTarget == 10)
        {
            TargetPosition = Target10;
            TargetDescriptor = EnemyNumber + "targetCube10";
        }
        GetComponent<NavMeshAgent>().destination = TargetPosition.position;
        LastTarget = CurrentTarget;
        


    }
    


    IEnumerator waiter()
    {
        Anim.SetInteger("WalkToIdle", 1);
        yield return new WaitForSeconds(WaitTime);
        Anim.SetInteger("WalkToIdle", 0);
        Contact = false; 
        MoveToTarget();
    }
}


