using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3;
    public TMP_Text vida;
    void Start()
    {
        vida.text = "3";
    }
    public void TomeDano(float damage)
    {
        health -= damage;
        
        if(health == 3){
            vida.text = "3";
        }else if(health == 2){
            vida.text = "2";
        }else if(health == 1){
            vida.text = "1";
        }
        if (health <= 0)
        {
            Debug.Log("tiger ta morto");
            Destroy(gameObject);
        }
    }
}
