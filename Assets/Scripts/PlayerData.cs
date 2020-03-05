using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{

    public int Points;
    public int PointsMultiplier;
    public int TotalNumberOfClicks;

    public bool M1Active, M2Active, M3Active, M4Active, M5Active, M6Active;
    public bool A1Active, A2Active, A3Active, A4Active, A5Active, A6Active;

    public int A1Amount, A2Amount, A3Amount, A4Amount, A5Amount, A6Amount;
    public int A1Price, A2Price, A3Price, A4Price, A5Price, A6Price;

    public PlayerData(GameControlScript player)
    {
        Points = player.Points;
        PointsMultiplier = player.PointsMultiplier;
        TotalNumberOfClicks = player.TotalNumberOfClicks;

		M1Active = player.M1Active;
		M2Active = player.M2Active;
		M3Active = player.M3Active;
		M4Active = player.M4Active;
		M5Active = player.M5Active;
		M6Active = player.M6Active;

		A1Active = player.A1Active;
		A1Amount = player.A1Amount;
		A1Price = player.A1Price;

		A2Active = player.A2Active;
		A2Amount = player.A2Amount;
		A2Price = player.A2Price;

		A3Active = player.A3Active;
		A3Amount = player.A3Amount;
		A3Price = player.A3Price;

		A4Active = player.A4Active;
		A4Amount = player.A4Amount;
		A4Price = player.A4Price;

		A5Active = player.A5Active;
		A5Amount = player.A5Amount;
		A5Price = player.A5Price;

		A6Active = player.A6Active;
		A6Amount = player.A6Amount;
		A6Price = player.A6Price;

    }
}

