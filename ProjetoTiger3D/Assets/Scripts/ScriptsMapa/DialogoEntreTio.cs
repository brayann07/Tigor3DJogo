using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogoEntreTio : MonoBehaviour
{
    private int aux = 0;
    public GameObject tigerSentado;
    public GameObject tigerLevantado;
    public GameObject tioLevantado;
    public GameObject tioDeCostas;
    public GameObject whey;

    // ali em cima ta os sprites da cena
    public TMP_Text dialogoText;
    public TMP_Text dialogoTextTio;
    // textos de dialogo
    public Image BalaoChat;
    public Image BalaoChatTio;

    //  imagens de balao
    public AudioSource musicaParar;
    public AudioSource tigerFalando;
    public AudioSource tioFalando;
    public AudioSource TP;
    public AudioSource zap;

    bool dialogoAtivo = false;

    void Start()
    {
        tigerLevantado.gameObject.SetActive(false);
        tioDeCostas.gameObject.SetActive(false);
        dialogoText.text = "";
        dialogoTextTio.text = "";
        BalaoChat.gameObject.SetActive(false);
        BalaoChatTio.gameObject.SetActive(false);
        whey.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !dialogoAtivo)
        {
            aux = 1;
            dialogoAtivo = true;
            musicaParar.Stop();
            Camera.main.transform.position = new Vector3(-1.42f, 2.00f, -13.55f);
            MostrarDialogo();
        }

        if (dialogoAtivo && Input.GetKeyDown(KeyCode.Space))
        {
            aux++;
            MostrarDialogo();
        }
    }

    void MostrarDialogo()
    {
        dialogoText.text = "";
        dialogoTextTio.text = "";
        BalaoChat.gameObject.SetActive(false);
        BalaoChatTio.gameObject.SetActive(false);
        dialogoText.gameObject.SetActive(false);
        dialogoTextTio.gameObject.SetActive(false);

        switch (aux)
        {
            case 1:
                BalaoChat.gameObject.SetActive(true);
                dialogoText.gameObject.SetActive(true);
                StartCoroutine(CooldownTiger());
                dialogoText.text = "Tigor:\nEntão tio...como eu tava falando";
                break;
            case 2:
                BalaoChat.gameObject.SetActive(false);
                dialogoText.gameObject.SetActive(false);
                zap.Play();
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                dialogoTextTio.text = "*Celular toca*";
                break;
            case 3:
                BalaoChat.gameObject.SetActive(false);
                dialogoText.gameObject.SetActive(false);
                zap.Play();
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                dialogoTextTio.text = "Tio do Tigor:\nEspera um pouco, Tigor";
                break;
            case 4:
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                StartCoroutine(CooldownTio());
                dialogoTextTio.text = "Tio do Tigor:\nCalma aí, de novo?";
                tioLevantado.SetActive(false);
                tioDeCostas.SetActive(true);
                whey.gameObject.SetActive(true);
                break;
            case 5:
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                StartCoroutine(CooldownTio());
                dialogoTextTio.text = "Tio do Tigor:\nUhum, tá, beleza, vou te enviar alguém de confiança";
                break;
            case 6:
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                tioLevantado.SetActive(true);
                tioDeCostas.SetActive(false);
                whey.gameObject.SetActive(false);
                StartCoroutine(CooldownTio());
                dialogoTextTio.text = "Tio do Tigor:\nSeguinte, cê vai ter que salvar Crossing Woods sozinho, porque o tio tá ocupado";
                
                break;
            case 7:
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                tioLevantado.SetActive(true);
                tioDeCostas.SetActive(false);
                StartCoroutine(CooldownTio());
                dialogoTextTio.text = "Tio do Tigor:\nLembra de tudo que o tio te ensinou sobre batalhas";
                break;
            case 8:
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                tioLevantado.SetActive(true);
                tioDeCostas.SetActive(false);
                StartCoroutine(CooldownTio());
                dialogoTextTio.text = "Tio do Tigor:\n 1 - ataque florestal, 2 - ataque psíquico, 3 - mete o soco";
                break;
            case 9:
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                tioLevantado.SetActive(true);
                tioDeCostas.SetActive(false);
                StartCoroutine(CooldownTio());
                dialogoTextTio.text = "Tio do Tigor:\n Qualquer dúvida é só apartar TAB para lembrar";
                break;
            case 10:
                BalaoChat.gameObject.SetActive(true);
                dialogoText.gameObject.SetActive(true);
                BalaoChatTio.gameObject.SetActive(false);
                dialogoTextTio.text = "";
                StartCoroutine(CooldownTiger());
                tigerSentado.SetActive(false);
                tigerLevantado.SetActive(true);
                dialogoText.text = "Tigor:\nQuê?? Como?? Pera aí!";
                break;
            case 11:
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(true);
                tioLevantado.SetActive(true);
                tioDeCostas.SetActive(false);
                StartCoroutine(CooldownTio());
                dialogoTextTio.text = "Tio do Tigor:\n Não fica aí parado, vai!!!";
                break;
            case 12:
                TP.Play();
                ChamarMapa();
                dialogoAtivo = false;
                break;
            default:
                Debug.Log("deu erro acho");
                break;
        }
    }
    private IEnumerator CooldownTiger(){
        tigerFalando.Play();
        yield return new WaitForSeconds(2);
        tigerFalando.Stop();
      }
     private IEnumerator CooldownTio(){
        tioFalando.Play();
        yield return new WaitForSeconds(2);
        tioFalando.Stop();
      }
    void ChamarMapa()
    {
        SceneManager.LoadScene(1);
    }
}
