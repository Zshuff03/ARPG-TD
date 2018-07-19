using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

 		public int maxHealth = 100;
        public int currentHealth { get; private set;}

        public Stat damage = new Stat(0);
        public Stat armor = new Stat(0);

        void Awake() {
            currentHealth = maxHealth;
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.T)) {
                TakeDamage(5);
            }
        }

        public void TakeDamage(int damage) {
            damage -= armor.CalcValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            
            currentHealth -= damage;
            Debug.Log(transform.name + " takes " + damage + " damage.");
        
            if(currentHealth <= 0) {
                Die();
            }
        }

        public virtual void Die() {
            //Overwrite this
            Debug.Log(transform.name + " has died.");
        }
}
