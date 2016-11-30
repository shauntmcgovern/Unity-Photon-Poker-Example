using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameState : Photon.MonoBehaviour {

	public static List<string> shuffledDeck;

	public static int potAmount;

	public static List<Player> GameBeginPlayerList; // = GamePlayManager.playerList;

	public static Player currentPlayer;
	public static Player dealer, smallBlindPlayer, bigBlindPlayer;

	//straddle only exists if he decides to bet before the cards are dealt
	public static Player straddlePlayer;

	public static int smallBlindAmount, bigBlindAmount, straddleAmount;

	public static int lastBetAmount;

	public static int currentMinRaise;

	//the betting rounds and showdown
	public enum Rounds {isPreDeal, isPreFlop, isFlop, isTurn, isRiver, isShowdown}

	public static Rounds currentRound;

	public static void OnGameStarted() {

		//this is a permanent snapshot of playerlist at beginning of game. Used to find current player
		//at beginning of each new round
		GameBeginPlayerList = GamePlayManager.playerList;

		//TODO: GRAB THIS FROM SERVER 
		smallBlindAmount = 1;

		bigBlindAmount = 2 * smallBlindAmount;
		straddleAmount = 2 * bigBlindAmount;

		currentMinRaise = 2 * smallBlindAmount;

		//make smallblindplayer the next player in list after dealer
		if (GamePlayManager.playerList.IndexOf (dealer) == GamePlayManager.playerList.Count - 1) {

			smallBlindPlayer = GamePlayManager.playerList [0];

		} else {

			smallBlindPlayer = GamePlayManager.playerList [GamePlayManager.playerList.IndexOf (dealer) + 1];
		}

		//assign big blind player
		if (GamePlayManager.playerList.IndexOf (smallBlindPlayer) == GamePlayManager.playerList.Count - 1) {

			bigBlindPlayer = GamePlayManager.playerList [0];

		} else {

			bigBlindPlayer = GamePlayManager.playerList [GamePlayManager.playerList.IndexOf (smallBlindPlayer) + 1];
		}

		//assign straddle player
		if (GamePlayManager.playerList.IndexOf (bigBlindPlayer) == GamePlayManager.playerList.Count - 1) {

			straddlePlayer = GamePlayManager.playerList [0];

		} else {

			straddlePlayer = GamePlayManager.playerList [GamePlayManager.playerList.IndexOf (bigBlindPlayer) + 1];
		}
	

	}
		
}
