using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterConrol : MonoBehaviour
{
    private Touch touch;
    float speedModifier,leftrightSpeed=4, gorwnSpeed=0.03f,speed=4.5F;
    public AudioClip congraSound, barrierSound, scoreSound,jumpSound,portralSound,hitSound;
    public AudioSource audioSource1, audioSource2;
    public GameObject Vfx;
    public bool EndofLevel=false;
    bool test = false;
    public int coin,level;
    public float Score;
    public Text scoreText;
    public float count;
    public Text levelText;
    public Text coinText;
    



    void Start()
    {
        speedModifier = 0.005F;
    }

    void Update()
    {
        coinText.text = CoinCounter.totalCoin.ToString();
        scoreText.text = Score.ToString("F1");
        levelText.text ="Level " + level.ToString();
      
        if(transform.localScale.x > 0.1f&&count<24|| !EndofLevel)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            // Scor Screen
        }


        if (transform.position.z > 2.18)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, 2.1f);
        }

        if (transform.position.z < -2.18)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, -2.1f);
        }
           
       
       


        if (!EndofLevel&&transform.position.z<2.19f&& transform.position.z > -2.19)
        {
           

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3
                        (
                        transform.position.x,
                        transform.position.y,
                        transform.position.z + (touch.deltaPosition.x * speedModifier * -1)
                        );
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + leftrightSpeed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + leftrightSpeed * Time.deltaTime * -1);

            }
        }
        if (test)
        {
            if (transform.position.z == 0)
                test = false;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, 0), 2 * Time.deltaTime);
        }




    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EOL")
        {
            EndofLevel = true;
            Vfx.gameObject.SetActive(true);

            audioSource1.clip = congraSound;
            audioSource1.Play();

            audioSource2.clip = jumpSound;
            audioSource2.Play();
            Score = 0;


            test = true;
            if ((transform.localScale.x > 0.1))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(10, 10, 0);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(12, 13, 0);
            }
          
           
        }

        if (other.gameObject.tag == "boost1")
        {
            audioSource1.clip = portralSound;
            audioSource1.Play();
            transform.localScale = new Vector3(transform.localScale.x + gorwnSpeed, transform.localScale.y + gorwnSpeed, transform.localScale.z+ gorwnSpeed);

        }
        if (other.gameObject.tag == "boost2")
        {
            audioSource1.clip = portralSound;
            audioSource1.Play();
            transform.localScale = new Vector3(transform.localScale.x + 2*gorwnSpeed, transform.localScale.y +2*gorwnSpeed, transform.localScale.z+ 2*gorwnSpeed);

        }


        if (other.gameObject.tag == "damage1")
        {
            audioSource1.clip = hitSound;
            audioSource1.Play();
            transform.localScale = new Vector3(transform.localScale.x - gorwnSpeed, transform.localScale.y - gorwnSpeed, transform.localScale.z- gorwnSpeed);

            
        }
        if (other.gameObject.tag == "damage2")
        {
            audioSource1.clip = hitSound;
            audioSource1.Play();
            transform.localScale = new Vector3(transform.localScale.x - 2 * gorwnSpeed, transform.localScale.y - 2 * gorwnSpeed, transform.localScale.z-2*gorwnSpeed);

        }

        if (other.gameObject.tag == "barrier")
        {
            audioSource1.clip = barrierSound;
            audioSource1.Play();
            transform.localScale = new Vector3(transform.localScale.x - 2*gorwnSpeed, transform.localScale.y - 2*gorwnSpeed, transform.localScale.z-2*gorwnSpeed);
            int randomN = Random.RandomRange(0, 5);


            if (randomN == 0)
                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(13, 7, 10);
            else if (randomN == 1)
                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(18, 6, -10);
            else if (randomN == 2)
                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(22, 5, -15);
            else if (randomN == 3)
                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(7, 4, -15);
            else if (randomN == 4)
                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(8, 4, -16);

        }

        if (other.gameObject.tag == "barrierlevelend")
        {
            scoreText.enabled = true;
            if (transform.localScale.x > 0.1)
            {
               
                audioSource1.clip = barrierSound;
                audioSource1.Play();
                audioSource2.clip = scoreSound;
                audioSource2.Play();
                CoinCounter.totalCoin++;
                count++;

                Score = Score + 5*(1+(count * 0.2f));

                transform.localScale = new Vector3(transform.localScale.x - gorwnSpeed, transform.localScale.y - gorwnSpeed, transform.localScale.z- gorwnSpeed);
                int randomN = Random.RandomRange(0, 5);


                if (randomN == 0)
                    other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(13, 7, 10);
                else if (randomN == 1)
                    other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(18, 6, -10);
                else if (randomN == 2)
                    other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(22, 5, -15);
                else if (randomN == 3)
                    other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(7, 4, -15);
                else if (randomN == 4)
                    other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(8, 4, -16);
               
                if (transform.localScale.x < 0.1|| count==24)
                {
                    StartCoroutine(Wait(0.75f));
                }
            }

            else
            {
                StartCoroutine(Wait(0.75f));

            }


        }






        if (other.gameObject.tag == "bag")
        {
             if (other.transform.localScale.x <= transform.localScale.x)
             {
            Destroy(other.gameObject);
            audioSource1.clip = scoreSound;
            audioSource1.Play();
            transform.localScale = new Vector3(transform.localScale.x + gorwnSpeed, transform.localScale.y + gorwnSpeed, transform.localScale.z+ gorwnSpeed);
             }
            if (other.transform.localScale.x > transform.localScale.x)
            {
                if (transform.localScale.x > 0.1)
                {
              //      Destroy(other.gameObject);
                    audioSource1.clip = hitSound;
                    audioSource1.Play();
                    if (other.transform.localScale.x - transform.localScale.x < 0.1)
                        transform.localScale = new Vector3(transform.localScale.x - (other.transform.localScale.x - transform.localScale.x), transform.localScale.y - (other.transform.localScale.x - transform.localScale.x), transform.localScale.z);
                    else
                        transform.localScale = new Vector3(transform.localScale.x - gorwnSpeed, transform.localScale.y - gorwnSpeed, transform.localScale.z- gorwnSpeed);

                }

            }


        }
       

        
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(level);

    }




}
