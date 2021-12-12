using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Charater
{
    protected bool attackDelay = false;
    protected bool moveDelay = false;
    protected bool dieDelay = false;
    protected bool damageDelay = false;
    public void Resurrection()
    {

    }   
    public void EarnSkill(Skill _skill)
    {

    }

    public void StateCheck()
    {
        

        if (state == State.ATTACK)
        {
           StartCoroutine(AttackDelay());
            
        }
        else if (state == State.DAMAGED)
        {
            StartCoroutine(DamagedDelay());
        }
        else if (state == State.DIE)
        {
            StartCoroutine(DieDelay());
        }
        else if (state == State.MOVE)
        {
            StartCoroutine(MoveDelay());
        }
    }

    public void Move()
    {

    }

    public override void AttackEnemy()
    {
        var _enemy = GameManager.Instance.createdEnemies[0];
        _enemy.GetComponent<Charater>().Damaged(this.attack);
    }
    IEnumerator MoveDelay()
    {
        if (!moveDelay)
        {
            moveDelay = true;
            stateSource.clip = stateClip[1];
            stateSource.Play();
            stateAnimator.SetBool("Move", true);
            yield return new WaitForSeconds(1f);
            stateAnimator.SetBool("Move", false);
            state = State.IDLE;
            moveDelay = false;
        }
        
    }

    public IEnumerator DamagedDelay()
    {
        if(!damageDelay)
        {
            damageDelay = true;
            stateSource.clip = stateClip[3];
            stateSource.Play();
            stateAnimator.SetBool("Hurt", true);
            yield return new WaitForSeconds(1f);
            stateAnimator.SetBool("Hurt", false);
            state = State.IDLE;
            damageDelay = false;
        }
        
    }

    public IEnumerator DieDelay()
    {
        if (!dieDelay)
        {
            dieDelay = true;
            stateSource.clip = stateClip[2];
            stateSource.Play();
            stateAnimator.SetBool("Die", true);
            yield return new WaitForSeconds(1f);
            GameManager.Instance.createdAllies.Remove(this.gameObject);
            Destroy(this.gameObject);

        }
    }



    public IEnumerator AttackDelay()
    {
        
        if (!attackDelay)
        {
            attackDelay = true;
            AttackEnemy();
            stateSource.clip = stateClip[0];
            stateSource.Play();
            stateAnimator.SetBool("Attack", true);
            yield return new WaitForSeconds(1f);
            stateAnimator.SetBool("Attack", false);
            state = State.IDLE;
            attackDelay = false;
        }
    }
}


