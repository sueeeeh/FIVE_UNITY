using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    public TextMeshProUGUI tmp;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score=0;

    }

    // Update is called once per frame
    void Update()
    {
        //run
        float h = Input.GetAxisRaw("Horizontal");
        if(h<0) h=0;
        Vector3 dir = new Vector3(h,0,0);
        transform.position += (dir*0.1f);

        //jump
        //Input.GetKeyDown(KeyCode.UpArrow);

        if(Input.GetKeyDown(KeyCode.Space)){
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0,7,0),ForceMode2D.Impulse); //순간적으로 7만큼 상승
        }

        if(transform.position.x > 10f){
            Vector3 vec = new Vector3(-9.5f,0,0);
            transform.position = vec;
            // if(CompareTag("JELLY")){
            //     gameObject.SetActive(true);
            // } 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("JELLYBASIC")){
            (collision.gameObject).SetActive(false);
            score+=1;
            tmp.text = "SCORE : " + score;
            GetComponent<AudioSource>().Play();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("BAR")){
            
            //GetComponent<Animator>().Enabled(true);
            GetComponent<Animator>().SetTrigger("tHurt");

            score-=5;
            tmp.text = "SCORE : " + score;
        }
    }

}
