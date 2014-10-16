using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchControls : MonoBehaviour, IPointerDownHandler  {
	private Color oriColor;
	GameObject gameManager;

	public void OnPointerDown (PointerEventData eventData) {
		Color newColor = new Color(Random.Range(0.5f, 1.0f), 0.0f, 0.0f, oriColor.a);
		GetComponent<Image>().color = newColor;

		StartCoroutine("ChangeOriColor");

		gameManager.GetComponent<GameManager>().Touch();
	}
	
	IEnumerator ChangeOriColor() {
		yield return null;
		GetComponent<Image>().color = oriColor;
	}

	// Use this for initialization
	void Start () {
		oriColor = GetComponent<Image>().color;
		gameManager = GameObject.Find("GameManager");

//		Debug.Log(gameManager);
//		gameManager.GetComponent<GameManager>().Touch();
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpate() {

	}
}
