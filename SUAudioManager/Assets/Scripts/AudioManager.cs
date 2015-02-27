using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class AudioManager : MonoBehaviour 
{
	//Variables
	private static Hashtable emitterlist = null;


	//TODO
	//Variables texture, type;

	public enum AudioType //Enumerators for sound types
	{
		SFX,
		FOOTSTEPS,
		MUSIC,
		VO,
		IFX,
		UI,
		AMBIENCE,
		MISC
	};

	void Start () 
	{


		emitterlist = new Hashtable();

		FMOD_StudioEventEmitter [] emitters = FindObjectsOfType (typeof(FMOD_StudioEventEmitter)) as FMOD_StudioEventEmitter[]; //Find all FMOD Emitters

		int iemittercount = 0;

		foreach (FMOD_StudioEventEmitter emitter in emitters) //for each FMOD emitter found 
		{
			if (emitter.asset != null)
			{
				//Debug.Log("found " + emitter.asset.name + " on " + emitter.gameObject.name);

	            //emitter.CacheEventInstance();
	            // add the emitter to the hash..

				string estring = (emitter.gameObject.transform.parent.gameObject.GetHashCode() + "-" + emitter.asset.name).ToString();
				
				emitterlist.Add(estring,emitter);
	        }
   		}
	}

	public static bool PlayEmitter(string estring)  //Called To Play A Sound From Designated Emitter
	{
		FMOD_StudioEventEmitter EmitterToPlay = (FMOD_StudioEventEmitter) emitterlist[estring];

		EmitterToPlay.Stop(); //Stop Sound
		EmitterToPlay.Play(); //Play Sound

		return true;
	}

	void Update () 
	{


		if (Input.GetKeyDown ("4"))
		{
			DumpHash(emitterlist);
		}

	}

	void DumpHash (Hashtable HashtableHold)
	{
		HashtableHold.Clear ();
	}


	                    
}

