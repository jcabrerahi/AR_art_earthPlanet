using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ejemplo : MonoBehaviour, ITrackableEventHandler
{
    // Aquí se declaran las variables de clase
    TrackableBehaviour mTrackableBehaviour;

    public Transform posParticulas;

    public ParticleSystem particleLauncher;

    // Use this for initialization
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
            
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Detecta");
            soundSystem.instance.PlayMusic();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Pierde");
        }
        else
        {
            Debug.Log("Comienza1");
        }
    }

    void sacarParticulas(){  // Emite las partículas asignadas            
        //Debug.Log(transform.position);
        posParticulas.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        particleLauncher.Emit(12) ;   
    }
}
