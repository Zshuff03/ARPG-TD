using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Experience : MonoBehaviour {

    public double currentExperience;                            //how much experience the character currently has
    public double toNextLevel;                                  //experience required to level up
    public int charLevel;                                       //current character level

	void Start() {
		currentExperience = 0;
        toNextLevel = calcNextLevel((double)charLevel);
        charLevel = 1;
	}

    ///Calculates the required experience to level up
	public double calcNextLevel(double curLvl) {
        double expToNext = 0;
        expToNext = 500 + 0.4 * (100 * curLvl * curLvl);        //formula for experience requirements for leveling

        return expToNext;
    }

    ///function to add experience after a kill or quest completion or whatever
    public void gainExp(int expGained) {
        if(toNextLevel <= currentExperience + expGained){
            levelup(currentExperience + expGained - toNextLevel);
        }else{
            currentExperience += expGained;
        }
    }

    ///levels the character up
    public void levelup(double excessExp) {
        charLevel += 1;
        toNextLevel = calcNextLevel(charLevel);
        currentExperience = excessExp;
        //add stats here - or we can make a formula in the stats script
    }
}
