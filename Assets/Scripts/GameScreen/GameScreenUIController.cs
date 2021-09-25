using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenUIController : MonoBehaviour
{
	void Start()
    {
        
    }

    void Update()
    {
	    GetComponentInChildren<Text>().text =
		    Math.Round(FindObjectOfType<GameManager>().Score, 1).ToString(CultureInfo.InvariantCulture);
    }
}
