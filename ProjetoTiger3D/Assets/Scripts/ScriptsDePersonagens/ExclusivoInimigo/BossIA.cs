using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossIA : MonoBehaviour
{
    public GameObject player;
    public GameObject pedra;
    private float speed = 5f;
    private bool atqAtivo = false;
    public bool aoGanhar = false;
    private float distanciaValor = 10f;
    public AudioSource musicaTocandoAgora;
    public AudioSource musicafinal;
    int aux = 0;
    bool textoVidaAparecer = false;
    public TMP_Text textoVida;
    public int numDevidas = 40;
    public float VelocidadeOriginal = 5f;
    public GameObject magiaPreta;
    public GameObject magiaVerde;
    public float tempodeespera = 2f;
    void Start()
    {
        textoVida.gameObject.SetActive(false);
        musicafinal.loop = true;
    }
    void Update()
    {
        transform.LookAt(player.transform);
        float distancia = Vector3.Distance(transform.position, player.transform.position);
        if (distancia <= 20)
        {
            trocarMusica();
        }
        if (distancia <= distanciaValor && aux == 0)
        {
            speed = VelocidadeOriginal * 3;
            textoVidaAparecer = true;
            distanciaValor = 1000f;
            seguirJogador();
        }
        if (distancia <= distanciaValor && aux == 0 && numDevidas<=20)
        {
            speed = VelocidadeOriginal * 4;
            textoVidaAparecer = true;
            distanciaValor = 1000f;
            seguirJogador();
        }
        if (textoVidaAparecer)
        {
            textoVida.gameObject.SetActive(true);
            if (numDevidas > 15)
            {
                textoVida.text = "VIDA TOTAL DO BOSS:" + numDevidas;
            }
            else if (numDevidas <= 15)
            {
                textoVida.fontSize = 50;
                textoVida.text = "O BOSS ESTÁ FURIOSO!!!\nVIDA TOTAL DO BOSS:" + numDevidas;
                tempodeespera = 0.5f;
            }
            
        }
        if (numDevidas <= 0)
        {
            aoGanhar = true;
        }
        if (aoGanhar)
        {
            SceneManager.LoadScene(3);
        }
    }
   void trocarMusica()
{
    if (!musicafinal.isPlaying)
    {
        musicaTocandoAgora.Stop();
        musicafinal.Play();
    }
}
    void valorAleatorio()
    {
        int numEscolhido = Random.Range(1, 4);    // vai chamar algum void aq;
        if (numEscolhido == 1)
        {
            AtacarFisico();
        }
        else if (numEscolhido == 2)
        {
            AtacarMagiaPreta();
        }
        else if (numEscolhido == 3)
        {
            AtacarMagiaVerde();
        }
        else
        {
            Debug.Log("oxi, bugou!");
        }
    }
    void seguirJogador()
    {
        float distancia = Vector3.Distance(transform.position, player.transform.position);
        if (atqAtivo == false)
        {
            Vector3 direcao = (player.transform.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (distancia <= 7)
        {
            atqAtivo = true;
            valorAleatorio();
        }
    }
    void AtacarFisico()
    {
        atqAtivo = false;
        Debug.Log("escolhi fisico!");
    }
    void AtacarMagiaPreta()
    {
        Debug.Log("escolhi preto!");
        StartCoroutine(CooldowndeMovimento());

        GameObject magia = Instantiate(magiaVerde, transform.position, Quaternion.identity);
        magia.transform.localScale *= 2f;
        ProjetilInimigo scriptdeMagia = magia.GetComponent<ProjetilInimigo>();
        scriptdeMagia.direction = (player.transform.position - transform.position).normalized;
        Destroy(magia, 1f);
        atqAtivo = false;
    }
    void AtacarMagiaVerde()
    {
        Debug.Log("escolhi verde!");
        StartCoroutine(CooldowndeMovimento());

        GameObject magia = Instantiate(magiaPreta, transform.position, Quaternion.identity);
        magia.transform.localScale *= 2f;
        ProjetilInimigo scriptdeMagia = magia.GetComponent<ProjetilInimigo>();
        scriptdeMagia.direction = (player.transform.position - transform.position).normalized;
        Destroy(magia, 1f);
        atqAtivo = false;
    }
    public IEnumerator CooldowndeMovimento()
    {
        aux = 1;
        speed = 0f;
        yield return new WaitForSeconds(tempodeespera);
        aux = 0;
    }
}
