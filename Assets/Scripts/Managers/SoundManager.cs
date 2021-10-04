using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public List<Sound> Sounds; 

	private List<AudioSource> soundSources;

	void Start()
	{
		soundSources = new List<AudioSource>();
	}

    void Update()
    {
	    foreach (var source in soundSources.ToArray()) {
		    if (!source.isPlaying) {
			    soundSources.Remove(source);
				Destroy(source);	// TODO Maybe use some sort of pool instead of creation/deletion?
		    }
	    }   
    }

    public void PlaySound(string soundName)
    {
	    if (Sounds.Any(s => s.Name == soundName)) {
		    var sound = Sounds.Find(s => s.Name == soundName);
		    var source = gameObject.AddComponent<AudioSource>();

		    source.clip = sound.Clip;
		    source.Play();
			soundSources.Add(source);
	    }
    }
}

[Serializable]
public struct Sound
{
	public string Name;
	public AudioClip Clip;
}