using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float health = 3;
    public List<Image> imagens;
    void Start()
    {
    }
    public void TomeDano(float damage)
    {
        health -= damage;   
        AtualizarUI();
        if (health <= 0)
        {
            Debug.Log("tiger ta morto");
            Destroy(gameObject);
        }
    }
    public void RecupereVida(float recuperar){
        health += recuperar;   
        AtualizarUI();
        if (health >=1)
        {
            Debug.Log("tiger ta vivasso e recuperou vida");
        }
    }
    public void AtualizarUI(){
        for (int i = 0; i < imagens.Count; i++)
        {
            imagens[i].enabled = i < health;
        }

    }
}
