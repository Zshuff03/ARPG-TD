using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Experience : MonoBehaviour {

	public double exp;
    public double toNextLevel;
    public int lvl;

	void Start(){
		exp = 0;
        toNextLevel = calcNextLevel((double)lvl);
        lvl = 1;
	}
	public double calcNextLevel(double curLvl){
        double expToNext = 0;
        expToNext = 500 + 0.4 * (100 * curLvl * curLvl);

        return expToNext;
    }

    public void gainExp(int expGained){
        if(toNextLevel <= exp + expGained){
            levelup(exp + expGained - toNextLevel);
        }else{
            exp += expGained;
        }
    }

    public void levelup(double excessExp){
        lvl += 1;
        toNextLevel = calcNextLevel(lvl);
        exp = excessExp;
    }
}
