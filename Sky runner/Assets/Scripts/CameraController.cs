using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    public Transform Player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //cam1 = GameObject.FindGameObjectWithTag("MainCamera");
        //cam2 = GameObject.Find("cam2");
        target = GameObject.FindGameObjectWithTag("MovingCube").transform;
        offset = transform.position - target.position;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, Player.position.y, target.position.z) + offset, Time.deltaTime * 3);


    }
}
