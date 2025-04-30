using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    public AudioSource musicaInicio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (musicaInicio != null)
        {
            musicaInicio.Play();
        }


    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
