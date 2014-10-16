using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public short monsterMaxHP = 100;
	private short monsterHP;
	public float addHP = 1.2f;

	private short touchCount = 0;
	private List<Character> charList;
	public Text label_MonsterHP;

	public void Touch() {
		touchCount++;

		for (int i = 0; i < 4; i++) {
			uint attackTime = charList[i].getAttackTime();

			if ((touchCount % attackTime) == 0) {
				monsterHP -= (short)charList[i].getAT();

				if (monsterHP <= 0)
					NewCreateMonster();

				label_MonsterHP.text = monsterHP.ToString();
			}
		}
	}

	private void NewCreateMonster() {
		touchCount = 0;

		float tempMaxHP = monsterMaxHP * addHP;
		monsterMaxHP = (short)tempMaxHP;
		monsterHP = monsterMaxHP;

		Debug.Log("new monster");
	}

	// Use this for initialization
	public void Start () {
		monsterHP = monsterMaxHP;
		charList = GameData.Instance.CharacterList;
		label_MonsterHP.text = monsterHP.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
