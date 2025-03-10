using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemController : MonoBehaviour
{

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("JumpPower")){     
           Destroy(other.gameObject);
           this.gameObject.GetComponent<CharacterMovement>().canDoubleJump = true;
           StartCoroutine(WaitForSeconds());
        }
    }


    IEnumerator WaitForSeconds(){
        yield return new WaitForSeconds(30f);
        this.gameObject.GetComponent<CharacterMovement>().canDoubleJump = false;
        Debug.Log("Power Up Done");

    }

}
