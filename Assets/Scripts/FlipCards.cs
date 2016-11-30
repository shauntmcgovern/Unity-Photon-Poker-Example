using UnityEngine;
using System.Collections;

public class FlipCards : MonoBehaviour {

	public GameObject[] cards;

	public Material material;

	public Texture2D texture;

	// Use this for initialization
	void Start () {
	
		StartCoroutine(FlipMyCards (cards, 0.59f));
	}
	
	IEnumerator FlipMyCards(GameObject[] cards, float overTime)
	{

		yield return new WaitForSeconds (2);

		float startTime;

		//rotate the cards
		for (var i = 0; i < cards.Length; i++) {

			startTime = Time.time;

			while (Time.time < startTime + overTime) {

				cards[i].transform.Rotate(Vector3.forward*5, Space.World);

				//changing the material of the card to card face once it is rotated to 90deg
				if (cards[i].transform.rotation.eulerAngles.z >= 90f) {

					//CHANGE THE MATERIAL
					GameObject cardObject = GameObject.Find("Card"+i+"-0");
					Renderer cardRend = cardObject.GetComponent<Renderer>();
					cardRend.enabled = true;

					material.mainTexture = texture;
					cardRend.sharedMaterial = material;
				}

				//PUT THE FINAL ROTATED POSITION HERE

				yield return null;

			}


			//time between rotating each card
			//yield return new WaitForSeconds (timeBetweenCards);
		}
	}
}
