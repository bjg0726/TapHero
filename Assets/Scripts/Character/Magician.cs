using System.Collections;

public class Magician : Character {

	public Magician() {
		Well512 random = new Well512();
		uint[] prob =  {30, 35, 25, 10, 5};
		
		charInfo.type = (byte)CharacterType.kMagician;
		charInfo.grade = (byte)(random.Next(prob) + 1);
		charInfo.strength = (ushort)random.Next(1, 3);
		charInfo.stamina = (ushort)random.Next(1, 5);
		charInfo.intelligence = (ushort)random.Next(3, 12);
		charInfo.agility = (ushort)random.Next(1, 5);
		charInfo.lucky = (ushort)random.Next(1, 5);
	}
	
	public override ushort getAttackTime() {
		int attackTime = 20;
		int gradePoint = charInfo.grade / 2;
		int agilityBonus = charInfo.agility / (10 - gradePoint);
		
		attackTime -= agilityBonus;
		
		if (attackTime < 10)
			attackTime = 10;
		
		return (ushort)attackTime;
	}
	
	public override ushort getAT() {
		int at = 8;
		int gradePoint = (int)(charInfo.grade / 1.6f);
		int strengthBonus = charInfo.strength / (15 - gradePoint);
		int intelligenceBonus = charInfo.intelligence / (6 - gradePoint);
		int agilityBonus = charInfo.agility / (10 - gradePoint);
		
		at += strengthBonus;
		at += intelligenceBonus;
		at += agilityBonus;
		
		return (ushort)at;
	}
	
	public override ushort getDF() {
		int df = 1;
		int gradePoint = (int)(charInfo.grade / 1.4f);
		int strengthBonus = charInfo.strength / (8 - gradePoint);
		int intelligenceBonus = charInfo.intelligence / (12 - gradePoint);
		int agilityBonus = charInfo.agility / (10 - gradePoint);
		
		df += strengthBonus;
		df += intelligenceBonus;
		df += agilityBonus;
		
		return (ushort)df;
	}
	
	public override ushort getHeal() {
		int heal =  3;
		int gradePoint = (int)(charInfo.grade / 1.4f);
		int stamina = charInfo.stamina / (15 - gradePoint);
		
		heal += stamina;
		
		return (ushort)heal;
	}
}

