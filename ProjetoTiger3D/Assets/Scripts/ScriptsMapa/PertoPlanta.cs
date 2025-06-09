using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class PertoPlanta : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject muda;
    public GameObject planta;
    public GameObject tigor;
    public TMP_Text textoPerto;
    public GameObject pedra;
    public GameObject explosaoParticulas;
    public AudioSource explosaoAudio;

    public PlayerAndar playerandar;
    public Image balaoTiger;
    public Image tigerFeliz;
    public TMP_Text textoDialogo;
    public AudioSource tigerfalando;

    private int aux = 0;
    void Start()
    {
        textoPerto.text = "";
        planta.gameObject.SetActive(false);
    }


    void Update()
    {
        InventarioPlayer inventario = UnityEngine.Object.FindFirstObjectByType<InventarioPlayer>();
        PedraExplodir pedraExplodir = UnityEngine.Object.FindFirstObjectByType<PedraExplodir>();
        PlayerAndar playerAndar = UnityEngine.Object.FindFirstObjectByType<PlayerAndar>();
        float distancia = Vector3.Distance(muda.transform.position, tigor.transform.position);
        if (distancia < 2)
        {
            if (inventario.qntMudaInt >= 1 && aux == 0)
            {
                textoPerto.text = "Aperte F para plantar a muda!";
                Debug.Log("Planto a muda!");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    aux = 1;
                    playerAndar.auxiliar += 1;
                    inventario.qntMudaInt -= 1;
                    pedraExplodir.intPedraDestruir += 1;
                    StartCoroutine(VoltarZero());
                    planta.SetActive(true);
                    Destroy(textoPerto);
                }
            }
            else
            {
                textoPerto.text = "";
            }
        }
        if (pedraExplodir.intPedraDestruir == 3)
        {
            pedra.gameObject.SetActive(false);
            pedra.GetComponent<Collider>().enabled = false;
            balaoTiger.gameObject.SetActive(true);
            tigerFeliz.gameObject.SetActive(true);
            tigerfalando.Play();
            textoDialogo.text = "Finalmente essa pedra foi quebrada!";
            StartCoroutine(Cooldown());
            pedraExplodir.intPedraDestruir = 4;
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2f);
        tigerfalando.Stop();
        balaoTiger.gameObject.SetActive(false);
        tigerFeliz.gameObject.SetActive(false);
        textoDialogo.text = "";
    }
     IEnumerator VoltarZero()
    {
        PlayerAndar playerAndar = tigor.GetComponent<PlayerAndar>();
        yield return new WaitForSeconds(5f);
        playerAndar.auxiliar = 0;
    }
}
