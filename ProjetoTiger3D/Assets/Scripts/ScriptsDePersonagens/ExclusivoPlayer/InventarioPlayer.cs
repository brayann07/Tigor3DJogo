using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class InventarioPlayer : MonoBehaviour{
    public Image inventarioPanel;
    public TMP_Text qtdPizza;
    public TMP_Text qtdMuda;
    public int qntPizzaInt = 0;
    public int qntMudaInt = 0;
    public Button comerapizza;
    private int aux = 0;
    void Start()
    {
        inventarioPanel.gameObject.SetActive(false);
        qtdPizza.text = ""+qntPizzaInt;
        qtdMuda.text = ""+qntMudaInt;
    }
    public void AtualizarUI()
    {
        qtdPizza.text = "" + qntPizzaInt;
        qtdMuda.text = "" + qntMudaInt;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && aux == 0){
            inventarioPanel.gameObject.SetActive(true);
            aux++;
        }
        else if (Input.GetKeyDown(KeyCode.B) && aux == 1){
            inventarioPanel.gameObject.SetActive(false);
            aux--;
        }
    }
    public void Comer(){
        VidaPlayer vidaPlayer = gameObject.GetComponent<VidaPlayer>();
        if(qntPizzaInt > 0 && vidaPlayer.health != 3){
            qntPizzaInt--;
            AtualizarUI();
            vidaPlayer.RecupereVida(1);
        }
    }
}
