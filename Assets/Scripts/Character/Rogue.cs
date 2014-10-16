using UnityEngine;
using System.Collections;

public class Rogue : Character {

	public Rogue() {
		Well512 random = new Well512();
		uint[] prob =  {30, 35, 25, 10, 5};
		
		charInfo.type = (byte)CharacterType.kRogue;
		charInfo.grade = (byte)(random.Next(prob) + 1);
		charInfo.strength = (ushort)random.Next(1, 5);
		charInfo.stamina = (ushort)random.Next(1, 7);
		charInfo.intelligence = (ushort)random.Next(1, 7);
		charInfo.agility = (ushort)random.Next(4, 10);
		charInfo.lucky = (ushort)random.Next(1, 7);
	}
	
	public override ushort getAttackTime() {
		int attackTime = 10;
		int gradePoint = (int)(charInfo.grade / 1.3f);
		int agilityBonus = charInfo.agility / (6 - gradePoint);
		
		attackTime -= agilityBonus;
		
		if (attackTime < 4)
			attackTime = 4;
		
		return (ushort)attackTime;
	}
	
	public override ushort getAT() {
		int at = 5;
		int gradePoint = (int)(charInfo.grade / 1.4f);
		int strengthBonus = charInfo.strength / (10 - gradePoint);
		int intelligenceBonus = charInfo.intelligence / (12 - gradePoint);
		int agilityBonus = charInfo.agility / (7 - gradePoint);
		
		at += strengthBonus;
		at += intelligenceBonus;
		at += agilityBonus;
		
		return (ushort)at;
	}
	
	public override ushort getDF() {
		int df = 3;
		int gradePoint = charInfo.grade / 2;
		int strengthBonus = charInfo.strength / (10 - gradePoint);
		int intelligenceBonus = charInfo.intelligence / (12 - gradePoint);
		int agilityBonus = charInfo.agility / (8 - gradePoint);
		
		df += strengthBonus;
		df += intelligenceBonus;
		df += agilityBonus;
		
		return (ushort)df;
	}
	
	public override ushort getHeal() {
		int heal =  5;
		int gradePoint = (int)(charInfo.grade / 1.6f);
		int stamina = charInfo.stamina / (10 - gradePoint);
		
		heal += stamina;
		
		return (ushort)heal;
	}
}
