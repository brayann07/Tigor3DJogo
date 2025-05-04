using TMPro;
using UnityEngine;

public class PlayerNivel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text nivel;
    public int numNivel = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtualizarNivel(){
        nivel.text = ""+numNivel;
    }
}
