using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpUnit : MonoBehaviour
{
    // Game System

    protected bool isDead;

    // status
    protected int HP;       // 체력
    protected int Chaos;    // 치명타 확률 [10 당 치명타 확률 5%, 20당 팀킬 확률 5%]

    protected float Atk;      // 데미지 공식 [(Atk * 스킬 계수 * 1.3 (강타 계수)) * 방어력 공식]
    protected float Dfd;      // 방어력 공식 [100/(100+Dfd)]
    protected float Speed;    // 스피드 공식 [Speed / 100 (소수점 두자리) => 누적 더해서 100 먼저 되면 턴 획득]
    

    protected EpUnit() { }

    protected EpUnit(int hp, float atk, float dfd, float speed, int chaos) {
        isDead = true;
        HP = hp;
        Atk = atk;
        Dfd = dfd;
        Speed = speed;
        Chaos = chaos;
    }

    protected float CalcAtk(float atk, float skill)
    {
        return atk * skill * 1.3f * CalcDfd();
    }

    protected float CalcDfd()
    {
        return (100 / (Dfd + 100));
    }

    protected void HpUp(float Heal)
    {
        HP += (int) Heal;
    }

    protected void HpDown(float atk, float skill)
    {
        HP -= (int) CalcAtk(atk, skill);
    }

    protected void SetChaos(int chaos)
    {
        Chaos += chaos;

        if (Chaos < 0)
            Chaos = 0;

        if (Chaos > 100)
            Chaos = 100;
    }

    protected void IsDead()
    {
        if(HP <= 0)
        {
            isDead = false;
        }
    }

    protected void Awake()
    {
        
    }

    protected virtual void Start()
    {
        
    }
}
