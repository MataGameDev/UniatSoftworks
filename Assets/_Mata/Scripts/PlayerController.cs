
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    void Update()
    {
        // Obtener la dirección de movimiento desde los botones UI
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular la dirección en el espacio del mundo
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Rotar la dirección según la orientación de la cámara
        direction = Camera.main.transform.TransformDirection(direction);

        // Mover el personaje en la dirección calculada
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    public void MoveUp()
    {
        // Mover hacia arriba en el eje Z
        transform.Translate(Vector3.forward * moveSpeed);
    }

    public void MoveDown()
    {
        // Mover hacia abajo en el eje Z
        transform.Translate(Vector3.back * moveSpeed);
    }

    public void MoveRight()
    {
        // Mover hacia la derecha en el eje X
        transform.Translate(Vector3.right * moveSpeed);
    }

    public void MoveLeft()
    {
        // Mover hacia la izquierda en el eje X
        transform.Translate(Vector3.left * moveSpeed);
    }
}