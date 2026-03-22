using UnityEngine;

 
public class TriggerToOpenDoorIsBeingInTheTomb : MonoBehaviour
{
    [SerializeField] public TombScript tomb;
    [SerializeField] public DoorScript door;
    private bool wasTher = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("fwefwe");

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(wasTher);

            if (tomb != null && tomb.WasThere())
            {
                wasTher = true;
            }
            if (wasTher) {
                //door.Open();
                door.AllowToOpen(true);
            }

        }
    }
}
