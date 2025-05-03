using System.Collections;
using NUnit.Framework.Interfaces;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DialogoInicioDoJogo : MonoBehaviour
{
    public Image spriteTigerNormal;
    public Image spriteTigerBravo;
    public Image spriteTigerFeliz;
    public Image balaodoTiger;
    public TMP_Text faladoTiger;
    public AudioSource tigerFalando;
    
    private int aux = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    if(spriteTigerNormal != null && spriteTigerBravo != null && spriteTigerFeliz != null &&balaodoTiger != null && faladoTiger != null ){
        Debug.Log("ta funcionando os UI do tigor");
        balaodoTiger.gameObject.SetActive(false);
        spriteTigerNormal.gameObject.SetActive(false);
        spriteTigerBravo.gameObject.SetActive(false);
        spriteTigerFeliz.gameObject.SetActive(false);
        faladoTiger.gameObject.SetActive(false);
    }    
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && aux == 0){
            aux++; 
            balaodoTiger.gameObject.SetActive(true);
            spriteTigerNormal.gameObject.SetActive(true);
            faladoTiger.gameObject.SetActive(true);
        }
            faladoTiger.text = "Tigor:\nDesde de quando a floresta é assim escura...";
            tigerFalando.Play();
            StartCoroutine(Cooldown());
    }
      private IEnumerator Cooldown(){
        yield return new WaitForSeconds(3);
        tigerFalando.Stop();
        balaodoTiger.gameObject.SetActive(false);
        spriteTigerNormal.gameObject.SetActive(false);
        faladoTiger.gameObject.SetActive(false);
      }
}
