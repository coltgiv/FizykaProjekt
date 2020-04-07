using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Vertical movement from input.
    private float verticalMove;
    //Horizontal movement from input.
    private float horizontalMove;
    //Speed of sphere.
    private float speed = 400;
    //Rigidbody of sphere.
    private Rigidbody rigidbody;
    //Number of capsule collected.
    private int numberOfCapsule;
    //Object of ending screen.
    private GameObject endingScreen;
    // Deactivating ending screen and geting rigidbody.
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        numberOfCapsule = 0;
        endingScreen = GameObject.Find("EndingScreen");
        endingScreen.SetActive(false);
        Cursor.visible = false;
    }

    // Updating movement of sphere.
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");

        Vector3 movingVector = new Vector3(-verticalMove, 0.0f, horizontalMove);
        rigidbody.AddForce(movingVector * speed);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    // When interact with capsule increse parameter and chceck if game should end.
    private void OnTriggerEnter(Collider other)
    {
        numberOfCapsule++;
        other.gameObject.SetActive(false);
        if(numberOfCapsule == 5)
        {
            endingScreen.SetActive(true);
            Cursor.visible = true;
            rigidbody.Sleep();
        }
    }
}
