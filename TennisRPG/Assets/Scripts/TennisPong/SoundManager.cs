using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioSource DeadZoneSound;
    
    // Start is called before the first frame update
    public void PlayDeadZoneSound()
	{
		DeadZoneSound.Play();
	}
}
