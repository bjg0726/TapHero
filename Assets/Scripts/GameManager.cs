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
	public Text[] label_Charactor;

	public void Touch() {
		touchCount++;

		for (int i = 0; i < 4; i++) {
			uint attackTime = charList[i].getAttackTime();

			//attack
			if ((touchCount % attackTime) == 0) {
				monsterHP -= (short)charList[i].getAT();

				string charType = "";
				GetCharactorTypeStr(charList[i].getType(), ref charType);

				label_Charactor[i].text = charType + charList[i].getAT().ToString() + " Damage";


				if (monsterHP <= 0)
					NewCreateMonster();

				label_MonsterHP.text = monsterHP.ToString();
				StartCoroutine("RemoveText", label_Charactor[i]);
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

	IEnumerator RemoveText(Text text) {
		yield return new WaitForSeconds(0.5f);
		text.text = "";
	}

	private void GetCharactorTypeStr(byte charType, ref string charStr) {
		switch(charType) {
		case (byte)CharacterType.kKnight:
			charStr = "Knight";
			break;
		case (byte)CharacterType.kArcher:
			charStr = "Archer";
			break;
		case (byte)CharacterType.kMagician:
			charStr = "Magician";
			break;
		case (byte)CharacterType.kRogue:
			charStr = "Rogue";
			break;
		}
	}
}
