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
    private string name;
    private int attack;
    private int hostility;
    private Skill[] skills;
    public State state = State.IDLE;
    [SerializeField]
    private AudioSource stateSource;
    [SerializeField]
    private AudioClip[] stateClip;
    [SerializeField]
    private Animator stateAnimator;

    public void AttackEnemy(GameObject _enemy)
    {

    }

    public void Damaged(int _attack)
    {

    }

    public void Die()
    {

    }

    public void Move()
    {

    }
}

public class Skill
{
    private enum cardType
    {
        RECOVERY,
        ACTIVE,
        PASSIVE
    }

    private GameObject cardTarget;


    public void SkillSet(GameObject _card)
    {

    }

    public void SkillTrigger()
    {

    }
}