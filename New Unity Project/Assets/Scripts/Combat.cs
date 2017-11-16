using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {
    public GameObject Attacker;
    public GameObject Defender;
    public int minAttackHP = 2;
    public int minAttackStamina = 1;
    Stats defender;
    Stats attacker;


    // Use this for initialization
    void Start ()
    {
        defender = Defender.GetComponent<Stats>();
        attacker = Attacker.GetComponent<Stats>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Attack()
    {
        if (attacker.Stamina >= minAttackStamina)
        {
            if (attacker.Health >= minAttackHP)
            {

                if (defender.Defence < attacker.Damage)
                {
                    attacker.Health -= 2;
                    defender.Health -= 10;
                    return;
                }
                else
                {
                    attacker.Health -= 15;
                    defender.Health -= 1;
                    return;
                }
            }
            else
                return;
        }
        else
            return;

    }
}
