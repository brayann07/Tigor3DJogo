// using Unity.VisualScripting;
// using UnityEngine;

// public class BossIA : MonoBehaviour
// {
//     public GameObject player;
//     public GameObject pedra;
//     public int auxMudas = 0;
//     private float speed = 5f;
//     private bool atqAtivo = false;
//     void Start()
//     {

//     }


//     void Update()
//     {
//         float distancia = Vector3.Distance(transform.position, player.transform.position);
//         if (distancia <= 10 && auxMudas == 1)
//         {
//             seguirJogador();
//         }
//     }
//     void valorAleatorio(aleatorio)
//     {
//         if (aleatorio == 1)
//         {

//         }
//         if()
//     }
//     void seguirJogador()
//     {
//         Vector3 direcao = (player.transform.position - transform.position).normalized;
//         transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
//         float distancia = Vector3.Distance(transform.position, player.transform.position);
//         if (distancia <= 2)
//         {
//             atqAtivo = true;
//             if (atqAtivo == true)
//             {
//                 speed = 0f;
//             }   
//         }
//     }
//     void AtacarFisico()
//     {

//     }
//     void AtacarMagiaPreta()
//     {

//     }
//     void AtacarMagiaVerde()
//     {
        
//     }
// }
