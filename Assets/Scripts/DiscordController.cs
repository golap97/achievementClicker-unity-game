using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour {

	long CurrentTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

	//private float timer = 0.0f;
	//private float FiveSecTimer = 5.0f;

	public Discord.Discord discord;

	// Use this for initialization
	void Start () {
		discord = new Discord.Discord(669298461312679966, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
		var activityManager = discord.GetActivityManager();
		activityManager.RegisterSteam(1229730);
		

		var activity = new Discord.Activity
		{
			State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
			Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
			Timestamps =
			{
				Start = CurrentTime,
			},
			Assets =
			{
				LargeImage = "puchar", // Larger Image Asset Key
				LargeText = "Achievement Clicker", // Large Image Tooltip
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});
	}
	// Timer powoduje dziwne opoznienie 25 sekundowe
	// Update is called once per frame
	void Update () {

	//	timer += Time.deltaTime;		
		
	//	if (timer > FiveSecTimer) {
	//		timer = timer - FiveSecTimer;

			if (GameControlScript.M1ActiveAPI == true) {
				if (GameControlScript.M2ActiveAPI == true) {
					if (GameControlScript.M3ActiveAPI == true) {
						if (GameControlScript.M4ActiveAPI == true) {
							if (GameControlScript.M5ActiveAPI == true) {
								if (GameControlScript.M6ActiveAPI == true) {
									M6();
								}
								else {
									M5();
								}
							}
							else {
								M4();
							}
						}
						else {
							M3();
						}
					}
					else {
						M2();
					}
				}
				else {
					M1();
				}
			}
			else {
				var activityManager = discord.GetActivityManager();
				activityManager.RegisterSteam(1229730);
					
				var activity = new Discord.Activity
				{
					State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
					Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
					Timestamps =
					{
						Start = CurrentTime,
					},
					Assets =
					{
						LargeImage = "puchar", // Larger Image Asset Key
						LargeText = "Achievement Clicker", // Large Image Tooltip
					},
				};
				activityManager.UpdateActivity(activity, (res) =>
				{
					if (res == Discord.Result.Ok)
					{
						Debug.LogError("Everything is fine!");
					}
				});

				discord.RunCallbacks();
			}
		//}
	}

	public void M1() {
		var activityManager = discord.GetActivityManager();
		activityManager.RegisterSteam(1229730);
					
		var activity = new Discord.Activity
		{
			State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
			Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
			Timestamps =
			{
				Start = CurrentTime,
			},
			Assets =
			{
				LargeImage = "puchar", // Larger Image Asset Key
				LargeText = "Achievement Clicker", // Large Image Tooltip
				SmallImage = "times2", // Small Image Asset Key
				SmallText = "x2", // Small Image Tooltip
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});

		discord.RunCallbacks();
	}

	public void M2() {
		var activityManager = discord.GetActivityManager();
		activityManager.RegisterSteam(1229730);
					
		var activity = new Discord.Activity
		{
			State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
			Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
			Timestamps =
			{
				Start = CurrentTime,
			},
			Assets =
			{
				LargeImage = "puchar", // Larger Image Asset Key
				LargeText = "Achievement Clicker", // Large Image Tooltip
				SmallImage = "times4", // Small Image Asset Key
				SmallText = "x4", // Small Image Tooltip
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});

		discord.RunCallbacks();
	}

	public void M3() {
		var activityManager = discord.GetActivityManager();
		activityManager.RegisterSteam(1229730);
					
		var activity = new Discord.Activity
		{
			State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
			Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
			Timestamps =
			{
				Start = CurrentTime,
			},
			Assets =
			{
				LargeImage = "puchar", // Larger Image Asset Key
				LargeText = "Achievement Clicker", // Large Image Tooltip
				SmallImage = "times8", // Small Image Asset Key
				SmallText = "x8", // Small Image Tooltip
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});

		discord.RunCallbacks();
	}

	public void M4() {
		var activityManager = discord.GetActivityManager();
		activityManager.RegisterSteam(1229730);
					
		var activity = new Discord.Activity
		{
			State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
			Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
			Timestamps =
			{
				Start = CurrentTime,
			},
			Assets =
			{
				LargeImage = "puchar", // Larger Image Asset Key
				LargeText = "Achievement Clicker", // Large Image Tooltip
				SmallImage = "times16", // Small Image Asset Key
				SmallText = "x16", // Small Image Tooltip
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});

		discord.RunCallbacks();
	}

	public void M5() {
		var activityManager = discord.GetActivityManager();
		activityManager.RegisterSteam(1229730);
					
		var activity = new Discord.Activity
		{
			State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
			Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
			Timestamps =
			{
				Start = CurrentTime,
			},
			Assets =
			{
				LargeImage = "puchar", // Larger Image Asset Key
				LargeText = "Achievement Clicker", // Large Image Tooltip
				SmallImage = "times32", // Small Image Asset Key
				SmallText = "x32", // Small Image Tooltip
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});

		discord.RunCallbacks();
	}

	public void M6() {
		var activityManager = discord.GetActivityManager();
		activityManager.RegisterSteam(1229730);
					
		var activity = new Discord.Activity
		{
			State = "Points: " + GameControlScript.AchievementPointsATM.ToString(),
			Details = "Total Clicks: " + GameControlScript.AchievementClicks.ToString(),
			Timestamps =
			{
				Start = CurrentTime,
			},
			Assets =
			{
				LargeImage = "puchar", // Larger Image Asset Key
				LargeText = "Achievement Clicker", // Large Image Tooltip
				SmallImage = "times64", // Small Image Asset Key
				SmallText = "x64", // Small Image Tooltip
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});

		discord.RunCallbacks();
	}
}