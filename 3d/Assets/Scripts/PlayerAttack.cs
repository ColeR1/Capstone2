using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;
    
    private float timeToAttack = 1f;
    private float timer = 0f;

    public  Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
     {
        Attack();
     }   

     if(attacking)
     {
        timer += Time.deltaTime;
        if(timer >= timeToAttack)
        {
            timer = 0;
            attacking = false;
            _animator.SetBool("Attack", false);
            attackArea.SetActive(attacking);
        }
     }
    }

    private void Attack()
    {
        attacking = true ;
        _animator.SetBool("Attack", true);
        Debug.Log("Attacked");
        attackArea.SetActive(attacking);
    }
}
