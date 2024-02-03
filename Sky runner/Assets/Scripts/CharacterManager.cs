using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 8.0f;
    private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -50f;
    public Transform Player;
    public UIManager UIManager;
    public AudioClip[] sounds;
    public AudioSource source;
    public MeshRenderer characterRenderer;

    public Material[] PlayerColor;
    public GameObject[] BodyParts;

    private void Start()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        foreach (var part in BodyParts)
        {
            part.GetComponent<MeshRenderer>().material = PlayerColor[PlayerPrefs.GetInt("Color")];

        }
        
        
        controller = this.GetComponent<CharacterController>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        characterRenderer = GetComponent<MeshRenderer>();
        
    }


    void Update()
    {

        

            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }


       
            Vector2 move = new Vector2(1, 0);

            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector2.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                source.clip = sounds[0];
                source.Play();
        }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameOver")
        {
            UIManager.GameOverFunction();
            
        }

        if (other.tag == "EndGame")
        {
            UIManager.WinFunction();
            
        }

    }

    public void ChangeCharacterColor()
    {
        characterRenderer.material.color = Color.green;
    }



}