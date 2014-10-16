using System.Collections;

public struct CharacterInfo {
	public byte type;
	public byte grade;

	public ushort strength;
	public ushort stamina;
	public ushort intelligence;
	public ushort agility;
	public ushort lucky;
	public ushort hp;
}

public enum CharacterType {
	kKnight,
	kArcher,
	kMagician,
	kRogue,
};

public abstract class Character {
	public Character() {
		charInfo = new CharacterInfo();
	}
	
	public abstract ushort getAttackTime();
	public abstract ushort getHeal();
	public abstract ushort getDF();
	public abstract ushort getAT();

	public ushort getCurrentHP() { return charInfo.hp; }
	void strengthTraining(ushort addPoint = 1) {		charInfo.strength += addPoint;		}
	void staminaTraining(ushort addPoint = 1) {			charInfo.stamina += addPoint;		}
	void intelligenceTraining(ushort addPoint = 1) {	charInfo.intelligence += addPoint;	}
	void agilityTraining(ushort addPoint = 1) {			charInfo.agility += addPoint;		}
	void luckyTraining(ushort addPoint = 1) {			charInfo.lucky += addPoint;			}

	protected CharacterInfo charInfo;
//	public CharacterInfo CharInfo {
//		get {ㅏ
//			return charInfo;
//		}
//		set{
//			charInfo = value;
//		}
//	}
}
