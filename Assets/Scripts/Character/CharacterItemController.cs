using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEditor;
using UnityEngine;

public class CharacterItemController : MonoBehaviour
{
    CharacterMovement charmov;
   
   public ParticleSystem speedParticles;

   public ParticleSystem jumpParticles;

    public ParticleSystem scoreParticles;

    public void Start()
    {
        charmov = gameObject.GetComponent<CharacterMovement>();
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpPower"))
        {
            other.gameObject.SetActive(false);
            jumpParticles.Play();
            charmov.canDoubleJump = true;
            StartCoroutine(JumpPowerTimer(other));
        }
        else if (other.CompareTag("SpeedPower"))
        {
            other.gameObject.SetActive(false);
            speedParticles.Play();
            charmov.speedBoost = true;
            StartCoroutine(SpeedPowerTimer(other));
        }else if(other.CompareTag("ScorePickup")){
            Destroy(other.gameObject);
            scoreParticles.Play();
            ScoreController.score += 50;
        }
    }




    IEnumerator JumpPowerTimer(Collider other)
    {
        yield return new WaitForSeconds(30f);
        charmov.canDoubleJump = false;
        Debug.Log("Jump Power Done");
        if(other != null){
            other.gameObject.SetActive(true);
        }
        
    }


    IEnumerator SpeedPowerTimer(Collider other)
    {
        yield return new WaitForSeconds(5f);
        charmov.speedBoost = false;
        Debug.Log("Speed Power Done.");
        if(other!=null){
            other.gameObject.SetActive(true);
        }
    }

}
