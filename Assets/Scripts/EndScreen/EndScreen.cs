using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
	void Start()
	{
		FindObjectOfType<Text>().text = FindObjectOfType<GameManager>().Score.ToString(CultureInfo.InvariantCulture);
	}

    void Update()
    {
        
    }
}
