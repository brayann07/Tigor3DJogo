using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChamarCena : MonoBehaviour
{
    public AudioSource musica;
    public AudioSource somDialogo;
    public Canvas canvas;
    public TMP_Text texto;
    public Image imagem;
    public Canvas canvaMenu;
    public Button botao;
    void Start()
    {
        imagem.gameObject.SetActive(false);
    }

    public void AoApertar()
    {
        botao.gameObject.SetActive(false);   
        canvaMenu.gameObject.SetActive(false);
        StartCoroutine(SequenciaDeCena());
        imagem.gameObject.SetActive(true);
    }

    IEnumerator SequenciaDeCena()
    {
        if (musica != null)
        {
            musica.Stop();
        }
        texto.text = "Tiger...";
        somDialogo.Play();
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        texto.text = "Você é o único que pode nos ajudar...";
        yield return new WaitForSeconds(3f);
        texto.text = "Por favor, volte a Crossing Woods";
        yield return new WaitForSeconds(3f);
        texto.text = "Por favor, volte a Crossing Woods.";
        yield return new WaitForSeconds(1f);
        texto.text = "Por favor, volte a Crossing Woods..";
        yield return new WaitForSeconds(1f);
        texto.text = "Por favor, volte a Crossing Woods...";
        yield return new WaitForSeconds(1f);
        somDialogo.Stop();
        texto.text = "Enquanto em Crossing Woods...";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SampleScene");
    }
}
