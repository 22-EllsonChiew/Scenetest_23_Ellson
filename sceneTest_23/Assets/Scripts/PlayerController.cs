using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float JumpForce;
    public float rotateSpeed;
    float iCount = 10.0f;
    public Text gameScore;
    Rigidbody PlayerRB;
    //public GameObject GameScore;

    int iTotalPowerUpLeft;




    // Start is called before the first frame update
    void Start()
    {
        PlayerRB.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        //float Inputvertical = Input.GetAxis("Vertical");
        //float Inputhorizontal = Input.GetAxis("Horizontal");


        //transform.Translate(Vector3.forward * Time.deltaTime * Inputvertical * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * Inputhorizontal * speed);


        iTotalPowerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
       
        if(iTotalPowerUpLeft == 0)
        {
            Debug.Log("Going OVER to new SCENE NOW WHEN ALL POER UP COLLECTED!");
            SceneManager.LoadScene("EndScenes");
        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
           
            
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            
            
        }
       
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            
            
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            
            
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {

            iCount--;
            gameScore.GetComponent<Text>().text = "Game Score: " + iCount.ToString();
            if(iCount == 0)
            {
                Debug.Log("Going OVER to new SCENE NOW!");
                SceneManager.LoadScene("EndScenes");
            }
        }
        
        



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            iCount++;
            gameScore.GetComponent<Text>().text = "Game Score: " + iCount.ToString();

            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("EndScenes");
        }

    }

    

}

