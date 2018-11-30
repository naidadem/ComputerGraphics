using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class movement : MonoBehaviour {

    public static bool triggered=false;
    private int x_rotation;
    private int y_rotation;
    private int z_rotation;
    public float  z_speed; 
    public float speed; 
    private Vector3 targetPos;
    public Rigidbody rb;
    public ParticleSystem bb_particles;
    private float currentScore;

    public Text score;
    public Text scoreDeath;
    public CanvasGroup deathUI;
    public ParticleSystem pointPS;
    public ParticleSystem deathPS;
    public ParticleSystem extraPS;

    private Powerups powerManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        powerManager = GameObject.FindGameObjectWithTag("pwrMng").GetComponent<Powerups>();
        targetPos = transform.position;
        x_rotation = 90;
    }
    void Update()
    {
            float distance = transform.position.z - Camera.main.transform.position.z; 
            targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
            targetPos = Camera.main.ScreenToWorldPoint(targetPos);

        if (Vector3.Distance(transform.position, targetPos) > 0.01f) 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        rb.velocity = new Vector3(0,0,z_speed); 
    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "death") PlayerDied();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "net")
        {
            currentScore += 1;
            score.text = currentScore.ToString();
            ParticleSystem go = Instantiate(pointPS, transform.position, Quaternion.identity); 
        }
        else if (coll.gameObject.tag == "extra")
        {
            ParticleSystem go = Instantiate(extraPS, transform.position, Quaternion.identity);
            Destroy(coll.gameObject);
            powerManager.Power();
        }
    }

    public void PlayerDied()
    {
        if(currentScore > PlayerPrefs.GetFloat("highscore"))
        {
            PlayerPrefs.SetFloat("highscore", currentScore);
        }

        Instantiate(deathPS, transform.position, Quaternion.identity);

        deathUI.alpha = 1.0f;
        deathUI.interactable = true;
        deathUI.blocksRaycasts = true;
        score.text = "";
        scoreDeath.text = currentScore.ToString();

        this.enabled = false;
    }

    public IEnumerator PowerUP()
    {
        z_speed = 6.0f;
        yield return new WaitForSeconds(4.0f);
        z_speed = 9.0f;
    }


    public IEnumerator PowerDOWN()
    {
        z_speed = 13.0f;
        yield return new WaitForSeconds(4.0f);
        z_speed = 9.0f;
    }

    public void ExtraPoints()
    {
        currentScore += 5;
        score.text = currentScore.ToString();
    }

}
