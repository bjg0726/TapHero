using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData {
	private List<Character> charList;
	public List<Character> CharacterList {
		get { return charList; }
	}
	
	private GameData() {
		charList = new List<Character>();
		charList.Capacity = 4;

		charList.Add(new Knight());
		charList.Add(new Archer());
		charList.Add(new Magician());
		charList.Add(new Rogue());
	}

	//singleton
	private static GameData instance = null;
	
	public static GameData Instance {
		get {
			if (instance == null)
				instance = new GameData();
			
			return instance;
		}
	}
}
