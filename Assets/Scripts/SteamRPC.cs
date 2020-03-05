using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamRPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SteamFriends.SetRichPresence ("steam_display","#Points");
        SteamFriends.SetRichPresence ("score", GameControlScript.AchievementPointsATM.ToString());
    }
}
