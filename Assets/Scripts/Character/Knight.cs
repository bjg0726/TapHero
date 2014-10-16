using UnityEngine;
using System.Collections;

public class Knight : Character {

	public Knight() {
		Well512 random = new Well512();
		uint[] prob =  {30, 35, 25, 10, 5};

		charInfo.type = (byte)CharacterType.kKnight;
		charInfo.grade = (byte)(random.Next(prob) + 1);
		charInfo.strength = (ushort)random.Next(1, 10);
		charInfo.stamina = (ushort)random.Next(1, 10);
		charInfo.intelligence = (ushort)random.Next(1, 5);
		charInfo.agility = (ushort)random.Next(1, 5);
		charInfo.lucky = (ushort)random.Next(1, 3);
	}

	public override ushort getAttackTime() {
		int attackTime = 15;
		int gradePoint = (charInfo.grade / 2);
		int agilityBonus = charInfo.agility / (7 - gradePoint);
		
		attackTime -= agilityBonus;
		
		if (attackTime < 8)
			attackTime = 8;
		
		return (ushort)attackTime;
	}
	
	public override ushort getAT() {
		int at = 5;
		int gradePoint = charInfo.grade / 2;
		int strengthBonus = charInfo.strength / (6 - gradePoint);
		int intelligenceBonus = charInfo.intelligence / (15 - gradePoint);
		int agilityBonus = charInfo.agility / (10 - gradePoint);
		
		at += strengthBonus;
		at += intelligenceBonus;
		at += agilityBonus;
		
		return (ushort)at;
	}
	
	public override ushort getDF() {
		int df = 6;
		int gradePoint = (int)(charInfo.grade / 1.4f);
		int strengthBonus = charInfo.strength / (5 - gradePoint);
		int intelligenceBonus = charInfo.intelligence / (15 - gradePoint);
		int agilityBonus = charInfo.agility / (12 - gradePoint);
		
		df += strengthBonus;
		df += intelligenceBonus;
		df += agilityBonus;
		
		return (ushort)df;
	}
	
	public override ushort getHeal() {
		int heal =  10;
		int gradePoint = (int)(charInfo.grade / 1.3f);
		int stamina = charInfo.stamina / (7 - gradePoint);
		
		heal += stamina;
		
		return (ushort)heal;
	}
}