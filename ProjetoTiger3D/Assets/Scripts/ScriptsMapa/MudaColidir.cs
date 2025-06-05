using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MudaColidir : MonoBehaviour
{
    public Image balaoTiger;
    public Image tigerFeliz;
    public TMP_Text textoDialogo;
    public AudioSource tigerfalando;
    public GameObject muda;
    public PlayerNivel playernivel;
    void OnTriggerEnter(Collider other)
    {
       InventarioPlayer inventario = FindFirstObjectByType<InventarioPlayer>();
        if (other.CompareTag("Player"))
        {
            balaoTiger.gameObject.SetActive(true);
            tigerFeliz.gameObject.SetActive(true);
            textoDialogo.gameObject.SetActive(true);
            tigerfalando.Play();
            if(inventario.qntMudaInt == 0){
                textoDialogo.text = "Tigor:\nMe pergunto para que eu vou usar isso futuramente...";
            }
            else if(inventario.qntMudaInt == 1 || inventario.qntMudaInt == 2 ){
                textoDialogo.text = "Tigor:\nTalvez se eu plantar no fim dessa floresta...";
            }
            else if(inventario.qntMudaInt > 2){
                textoDialogo.text = "Tigor:\nEnfim, vamos lá...";
            } 
            muda.GetComponent<Collider>().isTrigger = false;
            StartCoroutine(Cooldown());
            Debug.Log("pego a muda");
            inventario.qntMudaInt += 1;
            playernivel.numNivel += 1;
            playernivel.AtualizarNivel();
            inventario.AtualizarUI();
        }
    }
    IEnumerator Cooldown(){
        yield return new WaitForSeconds(2f);
        muda.gameObject.SetActive(false);
        tigerfalando.Stop();
        balaoTiger.gameObject.SetActive(false);
        tigerFeliz.gameObject.SetActive(false);
        textoDialogo.text = "";
        Destroy(gameObject);
    }
}
