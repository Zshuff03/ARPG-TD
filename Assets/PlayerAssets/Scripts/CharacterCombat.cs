using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	CharacterStats myStats;

	public float attackSpeed = 1f;								//Attack speed of the character - affected by char stats eventually
	public float attackCooldown = 0f;							//Cooldown of basic attack. Starts at 0 because attack isn't cd

	public float attackDelay = .6f;								//Delay for the attack to match up with animations

	public event System.Action OnAttack;						//Callback Method for attacks - add animators and the like i think?

	void Start() {
		//Get stats for this character
		myStats = GetComponent<CharacterStats>();
	}

	void Update() {
		//Reduce CD
		attackCooldown -= Time.deltaTime;
	}

	//Attack that motherlicker
	public void Attack(CharacterStats targetStats) {
		if(attackCooldown <= 0f){
			StartCoroutine(DoDamage(targetStats, attackDelay));

			//if (OnAttack != null){
			attackCooldown = 1f / attackSpeed;
			//}
		}
	}

	//Coroutine to delay attack based on animation
	IEnumerator DoDamage(CharacterStats stats, float delay) {
		yield return new WaitForSeconds(delay);

		stats.TakeDamage(myStats.damage.CalcValue());
	}
}
