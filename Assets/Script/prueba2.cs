using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class prueba2 : MonoBehaviour, ITrackableEventHandler
{
    // Aquí se declaran las variables de clase
    TrackableBehaviour mTrackableBehaviour;

    public GameObject cubo;
    public GameObject plano;
    public Transform posParticulas;

    public ParticleSystem particleLauncher;

    public ParticleSystemShapeType shapeType = ParticleSystemShapeType.Cone;
    private float timeLeft = 1.0f;

    float[] ritmo = new float[] { 1.5f, 1.5f, 1f, 1.5f, 1.5f, 1f, 1.5f, 1.5f, 2.5f, 1.5f, 2f };

    int contador = 0;

    bool emitFree = false;

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
            SpinFree.instance.valor = true;
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            SpinFree.instance.valor = false;
            Debug.Log("Pierde");
        }
        else
        {
            Debug.Log("Comienza1");
        }


    }

    void Update()
    {


        var shape = particleLauncher.shape;

        if (SpinFree.instance.valor == true)
        {
            if (emitFree == false)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    sacarParticulas();
                    //Debug.Log("el ritmos es: "+ ritmo[contador] + " del contador: " + contador);
                    if (contador < 10)
                    {
                        timeLeft = ritmo[contador];
                        contador++;
                        if (contador > 5)
                        {
                            plano.SetActive(false);
                        }
                    }
                    else
                    {
                        shape.shapeType = ParticleSystemShapeType.Sphere;
                        shape.arcMode = ParticleSystemShapeMultiModeValue.Loop;
                        cubo.SetActive(true);
                        emitFree = true;
                    }

                }
            }
            else {
                emisionParticulas();
            }


        }


    }
    void sacarParticulas()
    {  // Emite las partículas asignadas            
        posParticulas.position = new Vector3(SpinFree.instance.transform.position.x, SpinFree.instance.transform.position.y, SpinFree.instance.transform.position.z);
        particleLauncher.Emit(30);
    }

    void emisionParticulas() {
        particleLauncher.Emit(1);
    }


}
