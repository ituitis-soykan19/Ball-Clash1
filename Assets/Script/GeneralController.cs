using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class GeneralController : MonoBehaviour
{
    public string[] currentscore = new string[10];
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Rigidbodies[i].GetComponent<ControlandColorChange>().sphereid = i;
            Rigidbodies[i].GetComponent<ControlandColorChange>().controller = this;
            currentscore[i] = ("0");
        }
        changecurrent(0, -1);
    }

    public void updatescore()
    {
        currentscore[currentIndex] = Rigidbodies[currentIndex].GetComponent<ControlandColorChange>().point.ToString();
        scoretext = string.Format("Sphere1={0}\n" +
            "Sphere2={1}\n" +
            "Sphere3={2}\n" +
            "Sphere4={3}\n" +
            "Sphere5={4}\n" +
            "Sphere6={5}\n" +
            "Sphere7={6}\n" +
            "Sphere8={7}\n" +
            "Sphere9={8}\n" +
            "Sphere10={9}", currentscore[0], currentscore[1], currentscore[2], currentscore[3], currentscore[4], currentscore[5], currentscore[6], currentscore[7], currentscore[8], currentscore[9]);
        skorgoster.text = scoretext;
    }
    public Vector2 movement;
    public float speed;
    public int currentIndex = 0;
    public Rigidbody[] Rigidbodies;
    float latestCollisonTime = 0;
    Vector3 _prevPosition;
    public Text skorgoster;
    public string spherenum;
    public string scoretext;
    public string pointstring = ("0");
    public AudioSource spherecol;
    public void changecurrent(int Index, float collisionTime)
    {

        spherecol = GetComponent<AudioSource>(); 
        var currentObject = Rigidbodies[currentIndex].GetComponent<ControlandColorChange>();
        //Eger son carpisma bu framede gerceklestiyse hicbirsey yapma
        if (collisionTime == latestCollisonTime)
        {
            return;
        }
        else
        {
            latestCollisonTime = collisionTime;
        }
        //Deaktivate current object 
        currentObject.isactivated = false;
        spherecol.Play();
        currentObject.GetComponent<Renderer>().material.color = Color.white;
        //Set current object
        currentIndex = Index;
        Rigidbodies[currentIndex].GetComponent<ControlandColorChange>().isactivated = true;
        stopplayer();
        Rigidbodies[currentIndex].GetComponent<Renderer>().material.color = Color.green;
    }
    public void stopplayer()
    {
        for (int a = 0; a < 10; a++)
        {
                Rigidbodies[a].velocity = Vector3.zero;
                Rigidbodies[a].Sleep();
        }
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector2(horizontal, vertical);
        Vector3 vel = (transform.position - _prevPosition) / Time.deltaTime;
        _prevPosition = transform.position;
        //Debug.Log(vel);
        gameObject.transform.position = Rigidbodies[currentIndex].transform.position;
        updatescore();
    }
    private void FixedUpdate()
    {
        Rigidbodies[currentIndex].AddForce(speed * new Vector3(movement.x, 0f, movement.y));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Rigidbodies[currentIndex].gameObject.transform.position.y <= 10)
            {
                Rigidbodies[currentIndex].GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
            }
        }
    }
}