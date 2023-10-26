using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;
    private Main gameScript;
    public int amountOfScore;
    public ParticleSystem explosionParticle;

    void Awake()
    {
        gameScript = GameObject.Find("GameManager").GetComponent<Main>(); ;
        
        ballRb = GetComponent<Rigidbody>();
        

    }
    // Start is called before the first frame update
    void Start()
    {
        ballRb.AddForce(Vector3.up * Random.Range(10,15), ForceMode.Impulse);
        ballRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnMouseDown()
    {
        if(gameScript.isGameActive == true)
        {
            Destroy(gameObject);
            gameScript.UpdateScore(amountOfScore);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if (!CompareTag("Good"))
            {
                gameScript.GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!CompareTag("Bad"))
        {
            gameScript.GameOver();
        }
    }
}
