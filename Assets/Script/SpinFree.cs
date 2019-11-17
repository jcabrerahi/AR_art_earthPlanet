using UnityEngine;
using System.Collections;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class SpinFree : MonoBehaviour
{

    public static SpinFree instance;

    [Tooltip("Spin: Yes or No")]
    public bool spin;
    [Tooltip("Spin the parent object instead of the object this script is attached to")]

    public bool spinParent;
    public float velocidadVuelo;
    public float speed = 10f;

    [HideInInspector]
    public bool clockwise = true;
    [HideInInspector]
    public float direction = 1f;
    [HideInInspector]
    public float directionChangeSpeed = 2f;

    public bool valor = false;	

	bool llegaMeta = false;

    private void Awake()
    {
        if (SpinFree.instance == null)
        {
            SpinFree.instance = this;
        }
        else if (SpinFree.instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        transform.position = new Vector3(0, transform.position.y, 0);        
    }


    // Update is called once per frame
    void Update()
    {

        if (valor == true)
        {
            mover();
        }
		else {
			encerar();
		}

        //Debug.Log("El valor es: " + valor);


        if (direction < 1f)
        {
            direction += Time.deltaTime / (directionChangeSpeed / 2);
        }

        if (spin)
        {
            if (clockwise)
            {
                if (spinParent)
                    transform.parent.transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
                else
                    transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
            }
            else
            {
                if (spinParent)
                    transform.parent.transform.Rotate(-Vector3.up, (speed * direction) * Time.deltaTime);
                else
                    transform.Rotate(-Vector3.up, (speed * direction) * Time.deltaTime);
            }
        }
    }


    void mover()
    {
        if (transform.position.y <= 0.8)
        {
            transform.position = new Vector3(0, transform.position.y + 0.001f * velocidadVuelo, 0);
			llegaMeta = false;
        }
		else {
			llegaMeta = true;
		}

    }

    private void OnDestroy()
    {
        SpinFree.instance = null;
    }

	private void encerar(){
		transform.position = new Vector3(0, 0, 0);        
	}
}