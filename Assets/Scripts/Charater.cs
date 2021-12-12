using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Charater : MonoBehaviour
{


    public enum State
    {
        IDLE,
        ATTACK,
        MOVE,
        DIE,
        DAMAGED
    }

    public int maxHp;
    public int currentHp;
    public int maxStamina;
    public int currentStamina;
    [SerializeField]
    private string name;
    
    public int attack;
    [SerializeField]
    public int hostility;
    public List<Skill> skills;
    public State state = State.IDLE;
    [SerializeField]
    protected AudioSource stateSource;
    [SerializeField]
    protected AudioClip[] stateClip;
    [SerializeField]
    protected Animator stateAnimator;
    bool StaminaDelay = false;
    public virtual void AttackEnemy()
    {
        
    }

    public void Damaged(int _attack)
    {
        if(state == State.IDLE)
        state = State.DAMAGED;

        currentHp -= _attack;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        state = State.DIE;
 
    }



    public IEnumerator StaminaRecovery()
    {
        if (!StaminaDelay)
        {
            
            StaminaDelay = true;
            yield return new WaitForSeconds(1f);
            currentStamina += 1;
            if (currentStamina == maxStamina)
            {
                currentStamina = 0;
                state = State.ATTACK;

            }
            StaminaDelay = false;
        }
    }


}

public class Skill : MonoBehaviour
{
    //private enum cardType
    //{
    //    RECOVERY,
    //    ACTIVE,
    //    PASSIVE
    //}

    //private GameObject cardTarget;


    //public void SkillSet(GameObject _card)
    //{

    //}

    public virtual void SkillTrigger()
    {

    }
}