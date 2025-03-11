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


    public void Start()
    {
        charmov = gameObject.GetComponent<CharacterMovement>();
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpPower"))
        {
            Destroy(other.gameObject);
        
            jumpParticles.Play();
            charmov.canDoubleJump = true;
            StartCoroutine(JumpPowerTimer());
        }
        else if (other.CompareTag("SpeedPower"))
        {
            Destroy(other.gameObject);
            speedParticles.Play();
            charmov.speedBoost = true;
            StartCoroutine(SpeedPowerTimer());
        }
    }




    IEnumerator JumpPowerTimer()
    {
        yield return new WaitForSeconds(30f);
        charmov.canDoubleJump = false;
        Debug.Log("Jump Power Done");

    }


    IEnumerator SpeedPowerTimer()
    {
        yield return new WaitForSeconds(5f);
        charmov.speedBoost = false;
        Debug.Log("Speed Power Done.");

    }

}
