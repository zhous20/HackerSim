using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour {

	double moneyAmount;

	public Text moneyAmountText;

	public Text ChairPrice;
	public Text TreePrice;
	public Text PlantPrice;
	public Text TreadmillPrice;
	public Text TVPrice;
	public Text ComputerPrice;
	public Text ApplePrice;

	public Button buyChairButton;
	public Button buyTreeButton;
	public Button buyPlantButton;
	public Button buyTreadmillButton;
	public Button buyTVButton;
	public Button buyComputerButton;
	public Button buyAppleButton;

	private SEAttributes player;
	private int StockChair = 4;
	private int StockComp = 1;
	private int StockTv = 1 ;
	private int StockPlant = 1;
	private int StockTree = 1;
	private int StockTread = 1;

	private int amount = 0;

	private Image rend;
	// private Sprite chair, chair2, chair3, chair4, chair5;

	// Use this for initialization
	void Start () {
		player = SaveSEAttributes.LoadPlayer();
		moneyAmount = player.PlayerCurrency;
		//moneyAmount = PlayerPrefs.GetInt ("MoneyAmount");

		GameObject initialState = GameObject.Find("Canvas/Chair");
		rend = initialState.GetComponent<Image>();
		rend.sprite = ChangeChair.chairs[ChangeChair.upgrade+1];
	}

	// Update is called once per frame
	void Update () {

		moneyAmountText.text = "Money: " + moneyAmount.ToString() + "$";


		if (moneyAmount >= 5 && StockChair != 0)
			buyChairButton.interactable = true;
		else
			buyChairButton.interactable = false;

		if (moneyAmount >= 7 && StockTree != 0)
			buyTreeButton.interactable = true;
		else
			buyTreeButton.interactable = false;

		if (moneyAmount >= 3 && StockPlant != 0)
			buyPlantButton.interactable = true;
		else
			buyPlantButton.interactable = false;

		if (moneyAmount >= 20 && StockTread != 0)
			buyTreadmillButton.interactable = true;
		else
			buyTreadmillButton.interactable = false;

		if (moneyAmount >= 30 && StockTv != 0)
			buyTVButton.interactable = true;
		else
			buyTVButton.interactable = false;

		if (moneyAmount >= 50 && StockComp != 0)
			buyComputerButton.interactable = true;
		else
			buyComputerButton.interactable = false;

		if (moneyAmount >= 1)
			buyAppleButton.interactable = true;
		else
			buyAppleButton.interactable = false;
	}

	public void buyChair()
	{
		moneyAmount -= 5;
		ChairPrice.text = "Bought!";
		StockChair -= 1;
		//buyChairButton.gameObject.SetActive (false);
		if(ChangeChair.upgrade < 4)
			ChangeChair.upgrade += 1;
		rend.sprite = ChangeChair.chairs[ChangeChair.upgrade+1];
	}

	public void buyTree()
	{
		moneyAmount -= 7;
		TreePrice.text = "Bought!";
		StockTree -= 1;
		AddItem.isTree = true;
		AddItem.bought = true;
		//buyTreeButton.gameObject.SetActive (false);
	}
	public void buyPlant()
	{
		moneyAmount -= 3;
		PlantPrice.text = "Bought!";
		StockPlant -= 1;
		AddItem.isPlant = true;
		AddItem.bought = true;
		//buyPlantButton.gameObject.SetActive (false);
	}
	public void buyTreadmill()
	{
		moneyAmount -= 20;
		TreadmillPrice.text = "Bought!";
		StockTread -= 1;
		AddItem.isTread = true;
		AddItem.bought = true;
		//buyTreadmillButton.gameObject.SetActive (false);
	}
	public void buyTV()
	{
		moneyAmount -= 30;
		TVPrice.text = "Bought!";
		StockTv -= 1;
		ChangeTv.upgrade = true;
		//buyTVButton.gameObject.SetActive (false);
	}
	public void buyComputer()
	{
		moneyAmount -= 50;
		ComputerPrice.text = "Bought!";
		StockComp -= 1;
		ChangeComputer.upgrade = true;
		//buyComputerButton.gameObject.SetActive (false);
	}
	public void buyApple()
	{
		moneyAmount -= 1;
		ApplePrice.text = "Bought!";
		amount += 5;
		//buyAppleButton.gameObject.SetActive (false);
	}

	public void exitShop()
	{
		// PlayerPrefs.SetInt ("MoneyAmount", moneyAmount);
		SEAttributesController.AdjustCurrency(player, -player.PlayerCurrency);
		SEAttributesController.AdjustCurrency(player, moneyAmount);
		for(int i = 0; i < amount; i++)
		{
			SEAttributesController.DecreaseHunger(player);
		}
		SceneManager.LoadScene ("GeneralRoom");
	}


}
