using UnityEngine;

public class PararMusica : MonoBehaviour
{
    public AudioSource musica;
    private bool tatocando = false;
    void Start()
    {
        if(musica != null)
        {
            musica.loop = false;
            musica.Play();
            tatocando = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (tatocando)
            {
                musica.Pause();
                tatocando = false;
            }
            else
            {
                musica.UnPause();
                tatocando = true;
            }
        }
    }
}
