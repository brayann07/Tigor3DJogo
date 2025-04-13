using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MudarTexto : MonoBehaviour {
    private TMP_Text texto;
    void Start ()
    {
        texto = GetComponent<TMP_Text>();
        texto.text = "H- Mutar a música";
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            texto.text = "H- Desmutar a música";
        }
        if(texto.text == "H- Desmutar a música" && Input.GetKey(KeyCode.H)){
            texto.text = "H- Mutar a música";
        }
    }
}