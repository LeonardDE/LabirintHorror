using System;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class BeastController : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    
    public NavMeshAgent agent;

    private Vector3 postionFollow;
    public Vector3 defaultPosition;

    private GameObject[] arrayPlates;

    private const float switchTimeGeneral = 150f;
    private float SwitchTime = 150f;
    public int ZeroOne = 0;
    
    
    Random rnd = new Random();
    private int i = 0;

    void Start()
    {
        arrayPlates = GameObject.FindGameObjectsWithTag("Plate");
    }
    
    void Update()
    {
        BeastPovedenie();
        
        
    }

    void BeastRelaxing()
    {
        if (player.GetComponent<Pcontroller>().PlayerLoud)
        {
            postionFollow = player.transform.position;
            agent.SetDestination(postionFollow);
        }

        if (postionFollow == transform.position)
            agent.SetDestination(defaultPosition);
    }

    void BeastHunting()
    {
        if ( transform.position.x == arrayPlates[i].transform.position.x && transform.position.z == arrayPlates[i].transform.position.z)
        {
            i = rnd.Next(0,arrayPlates.Length );
            postionFollow = arrayPlates[i].transform.position;
            agent.SetDestination(postionFollow);
        }
        
        if (player.GetComponent<Pcontroller>().PlayerLoud)
        {
            postionFollow = player.transform.position;
            agent.SetDestination(postionFollow);
        }
        
    }
    

    void BeastPovedenie()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        Physics.Raycast(ray, out hit);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject != player)
            {
                if (SwitchTime <= 0)
                {
                    if (ZeroOne == 0)
                    {
                        ZeroOne = 1;
                        agent.SetDestination(arrayPlates[i].transform.position);
                        SwitchTime = switchTimeGeneral;
                    }
                    else
                    {
                        ZeroOne = 0;
                        agent.SetDestination(defaultPosition);
                        SwitchTime = switchTimeGeneral;
                    }
                }
                else
                {
                    if (ZeroOne == 0)
                    {
                        BeastRelaxing();
                        SwitchTime -= Time.deltaTime;
                    }
                    else
                    {
                        BeastHunting();
                        SwitchTime -= Time.deltaTime;
                    }
                }
            }
            else
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }
        
        
    
    
}
