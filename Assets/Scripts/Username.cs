using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;


public class Username : MonoBehaviour
{

    public Text SteamName;

    // Start is called before the first frame update
    void Start()
    {
		if(SteamManager.Initialized) {
			string name = SteamFriends.GetPersonaName();
            SteamName.text = "Welcome " + name;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
