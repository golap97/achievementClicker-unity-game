using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class Achievements : MonoBehaviour
{

    private float timer = 0.0f;
	private float FiveSecTimer = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(SteamManager.Initialized) {
            Debug.Log("Wszystko miodzio");
        }

        SteamUserStats.RequestCurrentStats();
        SteamUserStats.GetStat ("ACHIVPOINTS", out GameControlScript.AchievementClicks);
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;		

		if (timer > FiveSecTimer) {
			timer = timer - FiveSecTimer;

            SteamUserStats.SetStat ("ACHIVPOINTS", GameControlScript.AchievementClicks);
			Debug.Log(GameControlScript.AchievementClicks);
            SteamUserStats.StoreStats ();
		}
    }

    public void resetall() {
        SteamUserStats.ResetAllStats(true);
		SteamUserStats.StoreStats();
    }

    public static void ShopAchievement() {
        SteamUserStats.SetAchievement("SHOP");
        SteamUserStats.StoreStats();
    }
}
