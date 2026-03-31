using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

public static AudioManager Instance;

private AudioSource systemSource;
private List<AudioSource> activeSources;
    
    
    
   private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            systemSource = gameObject.AddComponent<AudioSource>();
            activeSources = new List<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
        
    

   
  public void Play( AudioClip clip)
  {
      systemSource.Stop();
      systemSource.clip = clip;
      systemSource.Play();


  }

  public void Stop(AudioClip clip)
  {
      systemSource.PlayOneShot(clip);
  }

  public void Stop(AudioSource source)
  {
    if(activeSources.Contains(source))  
        activeSources.Remove(source);
      source.Stop();
      systemSource.Stop();
  }

  public void Pouse()
  {
      systemSource.Pause();
  }

  public void Resume()
  {
      systemSource.UnPause();
  }
  
  
  
}
