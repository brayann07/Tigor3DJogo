using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class AbrirComandos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image imagem;
    private int auxiliar;
    void Start()
    {
        imagem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKeyDown(KeyCode.Tab) && auxiliar == 0){
        imagem.gameObject.SetActive(true);
        auxiliar++;
    }else if(Input.GetKeyDown(KeyCode.Tab) && auxiliar == 1){
        imagem.gameObject.SetActive(false);
        auxiliar--;
    }
    }
}
