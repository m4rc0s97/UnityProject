using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_health;
    public float m_stamina;
    public int m_score = 0;

    public void OnTriggerEnter(Collider other)
    {
       // other.GetComponent<TriggerObject>().OnTriggerEnterWithPlayer(this);
    }

    public void OnTriggerExit(Collider other)
    {
       // other.GetComponent<TriggerObject>().OnTriggerExitWithPlayer(this);
    }

    public void SetInvencibility (bool enabled)
    {

    }

    public void AddHealth (int health)
    {
        m_health += health;
    }
}




