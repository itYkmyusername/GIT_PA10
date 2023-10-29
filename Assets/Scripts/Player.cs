using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    [SerializeField] private float JumpAmount;
    [SerializeField]

    private Rigidbody rb;

    public Text ObsticleCountText;
    public GameManager GM;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, JumpAmount);
        }
            thisAnimation.Play();

        if(transform.position.y >= 3.44f)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (transform.position.y <= -3.67f)
        {
            SceneManager.LoadScene("GameLose");
        }

        
            
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            SceneManager.LoadScene("GameLose");
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obsticle")
        {
            GM.GetComponent<GameManager>().UpdateScore(1);
        }
    }
}
