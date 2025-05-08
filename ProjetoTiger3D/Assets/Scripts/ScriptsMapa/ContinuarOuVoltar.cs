using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ContinuarOuVoltar : MonoBehaviour
{
    public AudioSource tigerFalando;   
    public TMP_Text textoMotivacional;
    public TMP_Text sacana;
    public Image Balao;
    public Image Tiger;
    private int aux = 0;
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoMotivacional.text = "";
        Balao.gameObject.SetActive(false);
        Tiger.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && aux == 0){  // só pra n travar como o marcos ensino aff
            Continuar();
            aux++;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && aux == 0){
            Sair();
            aux++;
        }
    }
    public void Continuar(){
        sacana.text = "";
        Balao.gameObject.SetActive(true);
        Tiger.gameObject.SetActive(true);
        textoMotivacional.text = "Tigor:\nSabia que podia contar com você!";
        tigerFalando.Play();
        StartCoroutine(SelecaoContinuar());
    }
    public void Sair(){
        sacana.text = "";
        Balao.gameObject.SetActive(true);
        Tiger.gameObject.SetActive(true);
        textoMotivacional.text = "Tigor:\nQue pena, nos vemos na próxima então!";
        tigerFalando.Play();
        StartCoroutine(SelecaoSair());
    }
    IEnumerator SelecaoContinuar(){
        yield return new WaitForSeconds(5);
        Balao.gameObject.SetActive(false);
        Tiger.gameObject.SetActive(false);
        tigerFalando.Stop();
        SceneManager.LoadScene(1);
    }
     IEnumerator SelecaoSair(){
        yield return new WaitForSeconds(5);
        Balao.gameObject.SetActive(false);
        Tiger.gameObject.SetActive(false);
        tigerFalando.Stop();
        SceneManager.LoadScene(0);
    }
}
