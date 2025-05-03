
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogoEntreTio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image SpriteTiger;
    public int aux = 0;
    public GameObject tigerSentado;
    public GameObject tigerLevantado;
    public GameObject tioLevantado;
    public GameObject tioDeCostas;
    public TMP_Text dialogoText;
    public TMP_Text dialogoTextTio;
    public Image SpriteTiodoTigor;
    public Image BalaoChat;
    public Image BalaoChatTio;
    public AudioSource musicaParar;
    public AudioSource tigerFalando;
    public AudioSource tioFalando;
    void Start()
    {
        Debug.Log("todo certinho aq");
        dialogoText.text = "";
        dialogoTextTio.text = "";
        BalaoChat.gameObject.SetActive(false);
        BalaoChatTio.gameObject.SetActive(false);
        SpriteTiger.gameObject.SetActive(false);
        SpriteTiodoTigor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            ComecarDialogo();
            aux++;
        }
    }
    void ComecarDialogo(){
        Camera.main.transform.position = new Vector3(-1.42f, 2.00f, -13.55f);
        musicaParar.Stop();
        SpriteTiger.gameObject.SetActive(true);
        BalaoChat.gameObject.SetActive(true);
        dialogoText.gameObject.SetActive(true);
        switch(aux){
            case 1:
                dialogoText.text = "Tigor:\nEntão tio...como eu tava falando";
                if(Input.GetKeyDown(KeyCode.Space)){
                    aux++;
                    SpriteTiger.gameObject.SetActive(false);
                    BalaoChat.gameObject.SetActive(false);
                    dialogoText.gameObject.SetActive(false);
                }
                break;
            case 2:
                SpriteTiodoTigor.gameObject.SetActive(true);
                BalaoChatTio.gameObject.SetActive(true);
                dialogoTextTio.text = "*Celular toca*";
                  if(Input.GetKeyDown(KeyCode.Space)){
                    aux++;
                }
                break;
            case 3:
                dialogoTextTio.text = "Tio do Tigor:\nCalma aí";
                tioLevantado.gameObject.SetActive(false);
                tioDeCostas.gameObject.SetActive(true);               
                if(Input.GetKeyDown(KeyCode.Space)){
                    aux++;
                }
                break;
            case 4:
                dialogoTextTio.text = "Tio do Tigor:\nUhum, tá";
                if(Input.GetKeyDown(KeyCode.Space)){
                    aux++;
                }
                break;
            case 5:
                tioLevantado.gameObject.SetActive(true);
                tioDeCostas.gameObject.SetActive(false);     
                dialogoTextTio.text = "Tio do Tigor:\nSeguinte, se vai ter que salvar Crossing Woods, pq o tio ta ocupado";
                if(Input.GetKeyDown(KeyCode.Space)){
                    aux++;
                }
                break;
            case 6:
                SpriteTiodoTigor.gameObject.SetActive(false);
                BalaoChatTio.gameObject.SetActive(false);
                SpriteTiger.gameObject.SetActive(true);
                dialogoTextTio.gameObject.SetActive(false);
                tigerSentado.gameObject.SetActive(false);
                tigerLevantado.gameObject.SetActive(true);
                BalaoChat.gameObject.SetActive(true);
                dialogoText.gameObject.SetActive(true);
                dialogoText.text = "Oxi?!";
                if(Input.GetKeyDown(KeyCode.Space)){
                    aux++;
                }
                break;
            case 7:
                ChamarMapa();
                break;
            default:
                Debug.Log("deu erro acho");
                break;
        }
    }
    void ChamarMapa(){

    }
}
