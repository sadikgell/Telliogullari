using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BabyActions : MonoBehaviour
{

    private BoxCollider babyCollider;
    private Happiness happiness;
    // Start is called before the first frame update
    void Start()
    {
        babyCollider = GetComponent<BoxCollider>();
        happiness = GameObject.Find("GameManager").GetComponent<Happiness>();
        //Debug.Log($"{babyCollider.gameObject.name},{happiness.gameObject.name}");
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Trigger entered. Colliding object tag: {other.gameObject.tag}");

        if (other.gameObject.CompareTag("InteractPos"))
        {
            //Debug.Log("Bebe�i mutlu ettiniz.");
            MakeBabyHappy();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("InteractNeg"))
        {
            //Debug.Log("Bebe�i mutsuz ettiniz.");
            MakeBabySad();
            Destroy(other.gameObject);
        }

    } 

    private void MakeBabyHappy()
    {
        happiness.increaseHappiness(5);
    }

    private void MakeBabySad()
    { 
        happiness.decreaseHappiness(5);
    }

    void BabyHappyReact() 
    {
        //Debug.Log("Happy react.");
    }

    void BabySadReact()
    {
        //Debug.Log("Sad react.");
    }

    void BabyNeutralReact()
    {
        //Debug.Log("Neutral react.");
    }

    void FixedUpdate()
    {
        if (happiness.getHappiness() > 70f)
        {
            BabyHappyReact();
        }
        else if(happiness.getHappiness() < 30f)
        {
            BabySadReact();
        }
        else
        {
            BabyNeutralReact();
        }
    }
}
