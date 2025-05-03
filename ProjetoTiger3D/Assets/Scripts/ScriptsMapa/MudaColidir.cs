using UnityEngine;

public class MudaColidir : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       InventarioPlayer inventario = FindFirstObjectByType<InventarioPlayer>();
        if (other.CompareTag("Player"))
        {
            Debug.Log("pego a muda");
            inventario.qntMudaInt += 1;
            inventario.AtualizarUI();
            
            Destroy(gameObject);
        }
    }
}
