using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
	public List<Sound> Sounds;
	public List<Sound> Music;

	private List<AudioSource> soundSources;
	private AudioSource musicSource;

	void Start()
	{
		soundSources = new List<AudioSource>();
		musicSource = gameObject.AddComponent<AudioSource>();
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

    public void PlaySound(string soundName, bool randomize = false)
    {
	    if (Sounds.Any(s => s.Name == soundName)) {
		    var sound = Sounds.Find(s => s.Name == soundName);
		    var source = gameObject.AddComponent<AudioSource>();

		    source.clip = sound.Clip;

		    if (randomize) {
			    source.pitch = Random.Range(0.8f, 1.2f);
		    }

			source.Play();
			soundSources.Add(source);
	    }
    }

    public void PlayMusic(string musicName)
    {
	    if (Music.Any(m => m.Name == musicName)) {
		    var music = Music.Find(m => m.Name == musicName);
		    musicSource.clip = music.Clip;
		    musicSource.Play();
	    }
    }
}

[Serializable]
public struct Sound
{
	public string Name;
	public AudioClip Clip;
}