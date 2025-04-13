using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MudarTexto : MonoBehaviour
{
    private TMP_Text texto;
    private bool aux = false;
    void Start()
    {
        texto = GetComponent<TMP_Text>();
        texto.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            aux = !aux;

            if (aux)
            {
                texto.text = "H - Mutar a música";
            }
            else
            {
                texto.text = "H - Desmutar a música";
            }
        }
    }
}
