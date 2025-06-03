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
    public int pedraDestruir;

    public PlayerAndar playerandar;
    public Image balaoTiger;
    public Image tigerFeliz;
    public TMP_Text textoDialogo;
    public AudioSource tigerfalando;

    Animator anim;
    private int aux = 0;
    void Start()
    {
        textoPerto.text = "";
        playerandar = FindFirstObjectByType<PlayerAndar>();
        planta.gameObject.SetActive(false);
    }

    
    void Update()
    {
        InventarioPlayer inventario = FindFirstObjectByType<InventarioPlayer>();
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
                    playerandar.auxiliar = 1;
                    inventario.qntMudaInt -= 1;
                    pedraDestruir += 1;
                    StartCoroutine(VoltarZero());
                    planta.SetActive(true);
                    Destroy(textoPerto);
                    playerandar.PlantarPlanta();
                }
            }
            else
            {
                textoPerto.text = "";
            }
        }
    if(pedraDestruir == 3)
        {
            Destroy(pedra);
            balaoTiger.gameObject.SetActive(true);
            tigerFeliz.gameObject.SetActive(true);
            tigerfalando.Play();
            textoDialogo.text = "Finalmente essa pedra foi quebrada!";
            StartCoroutine(Cooldown());
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
        yield return new WaitForSeconds(5f);
        playerandar.auxiliar = 0;
    }
}
