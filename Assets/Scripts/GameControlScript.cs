using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControlScript : MonoBehaviour {

	// Guziki i tekst do kupna multiplierow
	public Button M1, M2, M3, M4, M5, M6;
	public GameObject M1SoldText, M2SoldText, M3SoldText, M4SoldText, M5SoldText, M6SoldText;
	public Text M1PriceText, M2PriceText, M3PriceText, M4PriceText, M5PriceText, M6PriceText;

	// Zmienne od multiplierow - czy sa kupione?
	public bool M1Active, M2Active, M3Active, M4Active, M5Active, M6Active;
	// Ceny multiplierow | M1=x2   M2=x4   M3=x8   M4=x16   M5=x32   M6=x64
	public int M1Price = 128, M2Price = 512, M3Price = 2048, M4Price = 8192, M5Price = 32768, M6Price = 131072;

	// Guziki i tekst do kupna auto-clickerow
	public Button A1, A2, A3, A4, A5, A6;
	public Text A1PriceText, A2PriceText, A3PriceText, A4PriceText, A5PriceText, A6PriceText;
	public Text A1AmountText, A2AmountText, A3AmountText, A4AmountText, A5AmountText, A6AmountText;
	public Text A1Stats, A2Stats, A3Stats, A4Stats, A5Stats, A6Stats;

	// Zmienne od auto-clickerow - czy sa kupione?
	public bool A1Active, A2Active, A3Active, A4Active, A5Active, A6Active;
	// Ceny multiplierow | A1=+2   A2=+4   A3=+8   A4=+16   A5=+32   A6=+64
	public int A1Price = 128, A2Price = 192, A3Price = 288, A4Price = 432, A5Price = 648, A6Price = 972;
	// Zwiekszenie ceny auto-clickerow po kazdym zakupie
	public int A1PriceIncrease = 16, A2PriceIncrease = 32, A3PriceIncrease = 64, A4PriceIncrease = 128, A5PriceIncrease = 256, A6PriceIncrease = 512;
	public int A1Amount = 0, A2Amount = 0, A3Amount = 0, A4Amount = 0, A5Amount = 0, A6Amount = 0;
	public int A1Auto = 2, A2Auto = 4, A3Auto = 8, A4Auto = 16, A5Auto = 32, A6Auto = 64;


	public Text PointsText, CurrentMultiplier, CurrentPointsPerSecond, TotalClicks;
	public int Points;
	public int PointsMultiplier = 1;
	public int PointsPerSecond;
	public int TotalNumberOfClicks;

	public static int AchievementClicks, AchievementPointsATM;

	public static bool M1ActiveAPI, M2ActiveAPI, M3ActiveAPI, M4ActiveAPI, M5ActiveAPI, M6ActiveAPI;

	// Timer'y do pasywnych punktow
	private float timer = 0.0f;
	private float OneSecTimer = 1.0f;

	public GameObject StorePanel;
	public GameObject MENU, ConBox;

	public GameObject UI, ShopUI;

	public GameObject WinText;

	public Button ClickerButton, ShopButton, ShopExit;

	private bool niepowtarzaj1 = false;

	// Use this for initialization
	void Start () {
		// Wylacz sklep na starcie
		StorePanel.gameObject.SetActive (false);
		ShopExit.gameObject.SetActive (false);

		// Wyswietlanie ceny multiplierow
		M1PriceText.text = "Price: " + M1Price.ToString();
		M2PriceText.text = "Price: " + M2Price.ToString();
		M3PriceText.text = "Price: " + M3Price.ToString();
		M4PriceText.text = "Price: " + M4Price.ToString();
		M5PriceText.text = "Price: " + M5Price.ToString();
		M6PriceText.text = "Price: " + M6Price.ToString();

		
		A1PriceText.text = "Price: " + A1Price.ToString();
		A1AmountText.text = "Amount: " + A1Amount.ToString();
		A2PriceText.text = "Price: " + A2Price.ToString();
		A2AmountText.text = "Amount: " + A2Amount.ToString();
		A3PriceText.text = "Price: " + A3Price.ToString();
		A3AmountText.text = "Amount: " + A3Amount.ToString();
		A4PriceText.text = "Price: " + A4Price.ToString();
		A4AmountText.text = "Amount: " + A4Amount.ToString();
		A5PriceText.text = "Price: " + A5Price.ToString();
		A5AmountText.text = "Amount: " + A5Amount.ToString();
		A6PriceText.text = "Price: " + A6Price.ToString();
		A6AmountText.text = "Amount: " + A6Amount.ToString();

		A1Stats.text = " " + A1Amount.ToString();
		A2Stats.text = " " + A2Amount.ToString();
		A3Stats.text = " " + A3Amount.ToString();
		A4Stats.text = " " + A4Amount.ToString();
		A5Stats.text = " " + A5Amount.ToString();
		A6Stats.text = " " + A6Amount.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		PointsPerSecond = (A1Auto * A1Amount) + (A2Auto * A2Amount) + (A3Auto * A3Amount) + (A4Auto * A4Amount) + (A5Auto * A5Amount) + (A6Auto * A6Amount);

		PointsText.text = Points + " Points";
		CurrentMultiplier.text = "Current Multiplier: x" + PointsMultiplier;
		CurrentPointsPerSecond.text = "Points Per Second: " + PointsPerSecond;
		TotalClicks.text = "Total Clicks: " + TotalNumberOfClicks;

		PointsChecker();

		timer += Time.deltaTime;		

		if (timer > OneSecTimer) {
			timer = timer - OneSecTimer;
			PassivePoints();
		}

		AchievementClicks = TotalNumberOfClicks;
		AchievementPointsATM = Points;
		M1ActiveAPI = M1Active;
		M2ActiveAPI = M2Active;
		M3ActiveAPI = M3Active;
		M4ActiveAPI = M4Active;
		M5ActiveAPI = M5Active;
		M6ActiveAPI = M6Active;

		if (Points >= 2000000000) {
			Points = 2000000000;
			WinText.gameObject.SetActive (true);
		}
		else {
			WinText.gameObject.SetActive (false);
		}
	}

	public void Free5000() {
		Points = Points + 5000;
	}

	// Glowny guzik - 1 klikniecie to +1 punkt
	public void Clicker()
	{
		Points = Points + (1 * PointsMultiplier);
		TotalNumberOfClicks = TotalNumberOfClicks + 1;
	}
	
	// Pasywne punkty na sekunde
	public void PassivePoints() {
		if (A1Active == true) {
			Points = Points + (A1Auto * A1Amount);
		}
		if (A2Active == true) {
			Points = Points + (A2Auto * A2Amount);
		}
		if (A3Active == true) {
			Points = Points + (A3Auto * A3Amount);
		}
		if (A4Active == true) {
			Points = Points + (A4Auto * A4Amount);
		}
		if (A5Active == true) {
			Points = Points + (A5Auto * A5Amount);
		}
		if (A6Active == true) {
			Points = Points + (A6Auto * A6Amount);
		}
	}

	public void Discord() {
		Application.OpenURL ("https://discord.gg/Nfzn6eF");
	}

	// Wlacza sklep
	public void shop() {
		StorePanel.gameObject.SetActive (true);
		ShopButton.gameObject.SetActive (false);
		ShopExit.gameObject.SetActive (true);
		ClickerButton.gameObject.SetActive (false);
		UI.gameObject.SetActive (false);
		ShopUI.gameObject.SetActive (true);

		if (niepowtarzaj1 == false) {
            niepowtarzaj1 = true;
			Achievements.ShopAchievement();
		}
	}

	// Wylacza sklep
	public void exitshop() {
		StorePanel.gameObject.SetActive (false);
		ShopButton.gameObject.SetActive (true);
		ShopExit.gameObject.SetActive (false);
		ClickerButton.gameObject.SetActive (true);
		UI.gameObject.SetActive (true);
		ShopUI.gameObject.SetActive (false);
	}

	// Sprawdza czy stac cie na dane ulepszenie
	public void PointsChecker() {
		// Czy stac cie na multiplier 1?
		if (Points < M1Price) {
			M1.interactable = false;
		}

		if (!M1Active && Points >= M1Price) {
			M1.interactable = true;
		}

		// Czy stac cie na multiplier 2 i masz kupiony multiplier 1?
		if (Points < M2Price) {
			M2.interactable = false;
		}

		if (M1Active && !M2Active && Points >= M2Price) {
			M2.interactable = true;
		}

		// Czy stac cie na multiplier 3 i masz kupiony multiplier 2?
		if (Points < M3Price) {
			M3.interactable = false;
		}

		if (M2Active && !M3Active && Points >= M3Price) {
			M3.interactable = true;
		}

		// Czy stac cie na multiplier 4 i masz kupiony multiplier 3?
		if (Points < M4Price) {
			M4.interactable = false;
		}

		if (M3Active && !M4Active && Points >= M4Price) {
			M4.interactable = true;
		}

		// Czy stac cie na multiplier 5 i masz kupiony multiplier 4?
		if (Points < M5Price) {
			M5.interactable = false;
		}

		if (M4Active && !M5Active && Points >= M5Price) {
			M5.interactable = true;
		}

		// Czy stac cie na multiplier 6 i masz kupiony multiplier 5?
		if (Points < M6Price) {
			M6.interactable = false;
		}

		if (M5Active && !M6Active && Points >= M6Price) {
			M6.interactable = true;
		}



		// Czy stac cie na auto-clicker 1?
		if (Points < A1Price) {
			A1.interactable = false;
		}

		if (Points >= A1Price) {
			A1.interactable = true;
		}
		
		// Czy stac cie na auto-clicker 2?
		if (Points < A2Price) {
			A2.interactable = false;
		}

		if (Points >= A2Price) {
			A2.interactable = true;
		}
		
		// Czy stac cie na auto-clicker 3?
		if (Points < A3Price) {
			A3.interactable = false;
		}

		if (Points >= A3Price) {
			A3.interactable = true;
		}
		
		// Czy stac cie na auto-clicker 4?
		if (Points < A4Price) {
			A4.interactable = false;
		}

		if (Points >= A4Price) {
			A4.interactable = true;
		}
		
		// Czy stac cie na auto-clicker 5?
		if (Points < A5Price) {
			A5.interactable = false;
		}

		if (Points >= A5Price) {
			A5.interactable = true;
		}
		
		// Czy stac cie na auto-clicker 6?
		if (Points < A6Price) {
			A6.interactable = false;
		}

		if (Points >= A6Price) {
			A6.interactable = true;
		}
	}
//-------------------SHOP-------------------
	//------------Multipliery------------
	public void BuyM1() {
		Points -= M1Price;

		M1Active = true;
		M1.interactable = false;

		M1SoldText.gameObject.SetActive (true);
		M1PriceText.gameObject.SetActive (false);

		PointsMultiplier = 2;
	}

	public void BuyM2() {
		Points -= M2Price;

		M2Active = true;
		M2.interactable = false;

		M2SoldText.gameObject.SetActive (true);
		M2PriceText.gameObject.SetActive (false);

		PointsMultiplier = 4;
	}

	public void BuyM3() {
		Points -= M3Price;

		M3Active = true;
		M3.interactable = false;
		
		M3SoldText.gameObject.SetActive (true);
		M3PriceText.gameObject.SetActive (false);

		PointsMultiplier = 8;
	}

	public void BuyM4() {
		Points -= M4Price;

		M4Active = true;
		M4.interactable = false;
		
		M4SoldText.gameObject.SetActive (true);
		M4PriceText.gameObject.SetActive (false);

		PointsMultiplier = 16;
	}

	public void BuyM5() {
		Points -= M5Price;

		M5Active = true;
		M5.interactable = false;
		
		M5SoldText.gameObject.SetActive (true);
		M5PriceText.gameObject.SetActive (false);

		PointsMultiplier = 32;
	}

	public void BuyM6() {
		Points -= M6Price;

		M6Active = true;
		M6.interactable = false;
		
		M6SoldText.gameObject.SetActive (true);
		M6PriceText.gameObject.SetActive (false);

		PointsMultiplier = 64;
	}

	//------------AutoClickery------------
	public void BuyA1() {
		Points -= A1Price;

		A1Active = true;

		A1Amount = A1Amount + 1;

		A1Price = A1Price + A1PriceIncrease;

		A1PriceText.text = "Price: " + A1Price.ToString();
		A1AmountText.text = "Amount: " + A1Amount.ToString();
		A1Stats.text = " " + A1Amount.ToString();
	}

	public void BuyA2() {
		Points -= A2Price;

		A2Active = true;

		A2Amount = A2Amount + 1;

		A2Price = A2Price + A2PriceIncrease;

		A2PriceText.text = "Price: " + A2Price.ToString();
		A2AmountText.text = "Amount: " + A2Amount.ToString();
		A2Stats.text = " " + A2Amount.ToString();
	}

	public void BuyA3() {
		Points -= A3Price;

		A3Active = true;

		A3Amount = A3Amount + 1;

		A3Price = A3Price + A3PriceIncrease;

		A3PriceText.text = "Price: " + A3Price.ToString();
		A3AmountText.text = "Amount: " + A3Amount.ToString();
		A3Stats.text = " " + A3Amount.ToString();
	}

	public void BuyA4() {
		Points -= A4Price;

		A4Active = true;

		A4Amount = A4Amount + 1;

		A4Price = A4Price + A4PriceIncrease;

		A4PriceText.text = "Price: " + A4Price.ToString();
		A4AmountText.text = "Amount: " + A4Amount.ToString();
		A4Stats.text = " " + A4Amount.ToString();
	}

	public void BuyA5() {
		Points -= A5Price;

		A5Active = true;

		A5Amount = A5Amount + 1;

		A5Price = A5Price + A5PriceIncrease;

		A5PriceText.text = "Price: " + A5Price.ToString();
		A5AmountText.text = "Amount: " + A5Amount.ToString();
		A5Stats.text = " " + A5Amount.ToString();
	}

	public void BuyA6() {
		Points -= A6Price;

		A6Active = true;

		A6Amount = A6Amount + 1;

		A6Price = A6Price + A6PriceIncrease;

		A6PriceText.text = "Price: " + A6Price.ToString();
		A6AmountText.text = "Amount: " + A6Amount.ToString();
		A6Stats.text = " " + A6Amount.ToString();
	}


// System zapisywania postaci do "tej"
	public void SavePlayer()
	{
		SaveSystem.SavePlayer(this);
	}
// System wczytywania postaci 
	public void LoadPlayer()
	{
		if (SaveSystem.LoadPlayer() != null) {
		PlayerData data = SaveSystem.LoadPlayer();

		Points = data.Points;
		PointsMultiplier = data.PointsMultiplier;
		TotalNumberOfClicks = data.TotalNumberOfClicks;

		M1Active = data.M1Active;
		M2Active = data.M2Active;
		M3Active = data.M3Active;
		M4Active = data.M4Active;
		M5Active = data.M5Active;
		M6Active = data.M6Active;

		A1Active = data.A1Active;
		A1Amount = data.A1Amount;
		A1Price = data.A1Price;

		A2Active = data.A2Active;
		A2Amount = data.A2Amount;
		A2Price = data.A2Price;

		A3Active = data.A3Active;
		A3Amount = data.A3Amount;
		A3Price = data.A3Price;

		A4Active = data.A4Active;
		A4Amount = data.A4Amount;
		A4Price = data.A4Price;

		A5Active = data.A5Active;
		A5Amount = data.A5Amount;
		A5Price = data.A5Price;

		A6Active = data.A6Active;
		A6Amount = data.A6Amount;
		A6Price = data.A6Price;

		if (M1Active == true) {
			M1.interactable = false;
			M1SoldText.gameObject.SetActive (true);
			M1PriceText.gameObject.SetActive (false);
			if (M2Active == true) {
				M2.interactable = false;
				M2SoldText.gameObject.SetActive (true);
				M2PriceText.gameObject.SetActive (false);
				if (M3Active == true) {
					M3.interactable = false;
					M3SoldText.gameObject.SetActive (true);
					M3PriceText.gameObject.SetActive (false);
					if (M4Active == true) {
						M4.interactable = false;
						M4SoldText.gameObject.SetActive (true);
						M4PriceText.gameObject.SetActive (false);
						if (M5Active == true) {
							M5.interactable = false;
							M5SoldText.gameObject.SetActive (true);
							M5PriceText.gameObject.SetActive (false);
							if (M6Active == true) {
								M6.interactable = false;
								M6SoldText.gameObject.SetActive (true);
								M6PriceText.gameObject.SetActive (false);
							}
						}
					}
				}
			}
		}

		A1PriceText.text = "Price: " + A1Price.ToString();
		A1AmountText.text = "Amount: " + A1Amount.ToString();
		A2PriceText.text = "Price: " + A2Price.ToString();
		A2AmountText.text = "Amount: " + A2Amount.ToString();
		A3PriceText.text = "Price: " + A3Price.ToString();
		A3AmountText.text = "Amount: " + A3Amount.ToString();
		A4PriceText.text = "Price: " + A4Price.ToString();
		A4AmountText.text = "Amount: " + A4Amount.ToString();
		A5PriceText.text = "Price: " + A5Price.ToString();
		A5AmountText.text = "Amount: " + A5Amount.ToString();
		A6PriceText.text = "Price: " + A6Price.ToString();
		A6AmountText.text = "Amount: " + A6Amount.ToString();

		A1Stats.text = " " + A1Amount.ToString();
		A2Stats.text = " " + A2Amount.ToString();
		A3Stats.text = " " + A3Amount.ToString();
		A4Stats.text = " " + A4Amount.ToString();
		A5Stats.text = " " + A5Amount.ToString();
		A6Stats.text = " " + A6Amount.ToString();

		MENU.gameObject.SetActive (false);
		}
		else
		{
			MENU.gameObject.SetActive (false);
		}
	}
	
//----------PRZYCISKI Z GLOWNEGO MENU----------

	//Resetuje progres "NEW GAME"
	public void PlayGame()
    {
        MENU.gameObject.SetActive (false);
		ConBox.gameObject.SetActive (false);

		Points = 0;
		PointsMultiplier = 1;
		TotalNumberOfClicks = 0;

		ShopReset();
    }
    
    public void QuitGame()
    {
		SaveSystem.SavePlayer(this);
        Debug.Log("Quit");
        Application.Quit();
    }

	public void StartGame() {
		ConBox.gameObject.SetActive (true);
	}

	public void CloseConBox() {
		ConBox.gameObject.SetActive (false);
	}

	public void ShopReset() {

		M1Active = false;
		M2Active = false;
		M3Active = false;
		M4Active = false;
		M5Active = false;
		M6Active = false;

		A1Active = false;
		A2Active = false;
		A3Active = false;
		A4Active = false;
		A5Active = false;
		A6Active = false;

		A1Amount = 0;
		A2Amount = 0;
		A3Amount = 0;
		A4Amount = 0;
		A5Amount = 0;
		A6Amount = 0;

		A1Price = 128;
		A2Price = 192;
		A3Price = 288;
		A4Price = 432;
		A5Price = 648;
		A6Price = 972;

		M1SoldText.gameObject.SetActive (false);
		M1PriceText.gameObject.SetActive (true);
		M2SoldText.gameObject.SetActive (false);
		M2PriceText.gameObject.SetActive (true);
		M3SoldText.gameObject.SetActive (false);
		M3PriceText.gameObject.SetActive (true);
		M4SoldText.gameObject.SetActive (false);
		M4PriceText.gameObject.SetActive (true);
		M5SoldText.gameObject.SetActive (false);
		M5PriceText.gameObject.SetActive (true);
		M6SoldText.gameObject.SetActive (false);
		M6PriceText.gameObject.SetActive (true);

		A1PriceText.text = "Price: " + A1Price.ToString();
		A1AmountText.text = "Amount: " + A1Amount.ToString();
		A2PriceText.text = "Price: " + A2Price.ToString();
		A2AmountText.text = "Amount: " + A2Amount.ToString();
		A3PriceText.text = "Price: " + A3Price.ToString();
		A3AmountText.text = "Amount: " + A3Amount.ToString();
		A4PriceText.text = "Price: " + A4Price.ToString();
		A4AmountText.text = "Amount: " + A4Amount.ToString();
		A5PriceText.text = "Price: " + A5Price.ToString();
		A5AmountText.text = "Amount: " + A5Amount.ToString();
		A6PriceText.text = "Price: " + A6Price.ToString();
		A6AmountText.text = "Amount: " + A6Amount.ToString();

		A1Stats.text = " " + A1Amount.ToString();
		A2Stats.text = " " + A2Amount.ToString();
		A3Stats.text = " " + A3Amount.ToString();
		A4Stats.text = " " + A4Amount.ToString();
		A5Stats.text = " " + A5Amount.ToString();
		A6Stats.text = " " + A6Amount.ToString();
	}
}
