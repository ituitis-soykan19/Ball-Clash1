using UnityEngine;
using UnityEngine.UI;

public class ControlandColorChange : MonoBehaviour
{
    public bool isactivated = false;
    public int sphereid;
    public GeneralController controller;
    public int score = 0;
    public int point = 0;
    public GameObject patlama;
    public AudioSource cubecollect;

    void Start()
    {
        cubecollect = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (isactivated)
        {
            var changer = col.gameObject.GetComponent<ControlandColorChange>();
            //Eger carptigimiz obje sphere degilse ve controlandchange scripti yoksa
            //hicbisey yapma
            if (changer == null || changer.isactivated)
            {
                return;
            }
            //Debug.Log(sphereid + " " + col.relativeVelocity);
            controller.changecurrent(changer.sphereid, Time.time);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            point++;
            Destroy(other.gameObject);
            cubecollect.Play();
            Instantiate(patlama, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
    }
}