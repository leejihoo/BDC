using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Charater
{
    protected bool attackDelay = false;
    protected bool moveDelay = false;
    protected bool dieDelay = false;
    protected bool damageDelay = false;
    public override void AttackEnemy()
    {
        var _enemy = GameManager.Instance.createdAllies[0];
        _enemy.GetComponent<Charater>().Damaged(this.attack);
    }

    public IEnumerator DamagedDelay()
    {

        if (!damageDelay)
        {
        damageDelay = true;
        stateSource.clip = stateClip[2];
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
            stateSource.clip = stateClip[1];
            stateSource.Play();
            stateAnimator.SetBool("Die", true);
            yield return new WaitForSeconds(1f);
            GameManager.Instance.createdEnemies.Remove(this.gameObject);
            Destroy(this.gameObject);
            dieDelay = false;
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

    }
}
