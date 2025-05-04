using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PizzaColidir : MonoBehaviour
{
    private int aux = 0;
    public Image balaoTiger;
    public Image spriteFeliz;
    public TMP_Text falaTiger;
    public AudioSource tigerfalandoaq;
    public GameObject pizza;
    
    void OnTriggerEnter(Collider other)
    {
       InventarioPlayer inventario = FindFirstObjectByType<InventarioPlayer>();
        if (other.CompareTag("Player") && aux == 0)
        {
            tigerfalandoaq.Play();
            aux++;
            balaoTiger.gameObject.SetActive(true);
            falaTiger.gameObject.SetActive(true);
            spriteFeliz.gameObject.SetActive(true);
            Debug.Log("pego a pizza");
            inventario.qntPizzaInt += 1;
            inventario.AtualizarUI();
            falaTiger.text = "Tigor:\nEba, uma pizza pra depois";
            pizza.GetComponent<Collider>().isTrigger = false;
            StartCoroutine(CooldownDeDialogo());
        }
        else if (other.CompareTag("Player") && aux == 1)
        {
            tigerfalandoaq.Play();
            balaoTiger.gameObject.SetActive(true);
            falaTiger.gameObject.SetActive(true);
            spriteFeliz.gameObject.SetActive(true);
            Debug.Log("pego a pizza");
            inventario.qntPizzaInt += 1;
            inventario.AtualizarUI();
            falaTiger.text = "Tigor:\nTomará que tenha mais algumas por aí...";
            pizza.GetComponent<Collider>().isTrigger = false;
            StartCoroutine(CooldownDeDialogo());
        }
    }
     private IEnumerator CooldownDeDialogo(){
        yield return new WaitForSeconds(3);
        tigerfalandoaq.Stop();
        balaoTiger.gameObject.SetActive(false);
        spriteFeliz.gameObject.SetActive(false);
        falaTiger.gameObject.SetActive(false);
        Destroy(gameObject);
      }
}
