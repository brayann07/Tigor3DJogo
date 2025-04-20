using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class DialogoComPlaca : MonoBehaviour
{
    public Canvas canvas;
    public TMP_Text text;
    public float pertoDaPlaca = 5f;
    public Transform jogador;
    public Canvas canvasDialogo;
    public TMP_Text textoDialogo;

    public AudioSource tigerfalando;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Canvas canvasdialogo = GameObject.Find("CanvasDoDialogo").GetComponent<Canvas>();
        //TMP_Text textodialogo = GameObject.Find("TextoDialogo").GetComponent<TMP_Text>(); nem funciona esse saco
        canvasDialogo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);
        if (distancia < 5)
        {
            Dialogo();
        }
        else
        {
            text.text = "";
        }
    }
    void Dialogo() {
        text.text = "Aperte E para interagir!";
        if (Input.GetKey(KeyCode.E))
        {
            AparecerUI();
        }
    }
    void AparecerUI()
    {
        canvasDialogo.gameObject.SetActive(true);
        tigerfalando.Play();
        textoDialogo.text = "Tigor:\n\nTenho que achar alguma forma de eliminar essa pedra...";
        StartCoroutine(CooldownDialogo());
        
    }
    IEnumerator CooldownDialogo()
    {
        Debug.Log("Cooldown dq 5 segundos...!");
        float tempoCooldown = 5f;       
        yield return new WaitForSeconds(tempoCooldown);
        tigerfalando.Stop();
        textoDialogo.text = "";
        canvasDialogo.gameObject.SetActive(false);
        Debug.Log("Cooldown!");
    }
}
