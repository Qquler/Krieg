using UnityEngine;

public class Swarm_Allocation : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private float R = 1f;
    private GameObject Scarab;

    void Start()
    {
        Scarab = this.transform.Find("Scarab").gameObject;
    }
    void Update()
    {
        
        int c = Scarab.transform.childCount;
        if (c == 1)
        {
            Transform fr = Scarab.transform.GetChild(0);
            fr.position = Vector2.MoveTowards(fr.position, this.transform.position, speed * Time.deltaTime);
            //Debug.Log(fr.position);

        }else if(c == 2)
        {
            Transform fr = Scarab.transform.GetChild(0);
            Transform sc = Scarab.transform.GetChild(1);
            fr.position = Vector2.MoveTowards(fr.position, new Vector2(this.transform.position.x+(R/3),this.transform.position.y), speed * Time.deltaTime);
            sc.position = Vector2.MoveTowards(sc.position, new Vector2(this.transform.position.x - (R / 3), this.transform.position.y), speed * Time.deltaTime);
            //Debug.Log(fr.position);
        }
        else
        {
            
            float add = (2f * Mathf.PI) / ((float)c-1);
            float rad = -add;

            foreach (Transform sca in Scarab.transform)
            {
                if (rad < 0)
                {

                    sca.position = Vector2.MoveTowards(sca.position, new Vector2(this.transform.position.x
                                                                               , this.transform.position.y), speed * Time.deltaTime);

                }
                else {
                    sca.position = Vector2.MoveTowards(sca.position, new Vector2(this.transform.position.x + Mathf.Cos(rad) * R
                                                                               , this.transform.position.y + Mathf.Sin(rad) * R
                                                                              ), speed * Time.deltaTime);

                }
                rad += add;
            }
        }
        //foreach (Transform child in Scarab)
        //{
            
        //}
    }

    // Update is called once per frame

}