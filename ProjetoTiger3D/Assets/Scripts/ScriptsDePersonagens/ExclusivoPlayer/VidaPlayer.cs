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
    public void AtualizarUI(){
        for (int i = 0; i < imagens.Count; i++)
        {
            imagens[i].enabled = i < health;
        }

    }
}
