using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("List of doors")]
    public GameObject[] doors;
    static public GameObject gate;
    static public List<GameObject> houseDoors;
    static public GameObject frogDoor;
    //[Header("Stuff that helps AI")]
    static public bool gateQuest;
    // Start is called before the first frame update
    void Start()
    {
        gateQuest = false;
        gate = doors[0];
        frogDoor = doors[4];//need this door for frogman ai
        houseDoors = doors.ToList();//listify, other methods = crash
        houseDoors.Remove(gate);//gate is irrelevant to list
    }

    // Update is called once per frame
    void Update()
    {

    }
    static public void OpenGate() //no more gate
    {
        gate.SetActive(false);
        gateQuest = false;
    }
    static public void OpenDoor()
    {
        houseDoors[0].SetActive(false);
        houseDoors.Remove(houseDoors[0]);
    }
}
