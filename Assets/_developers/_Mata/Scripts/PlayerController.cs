
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public bool wantsToUp, canUp, wantsToDown, canDown, wantsToRight, canRight, wantsToLeft, canLeft, stopMovement;
    public GameObject mesh;
    public Vector3 currentDirection = Vector3.zero;

    private void Start()
    {
        canUp = true;
        canDown = true;
        canLeft = true;
        canRight = true;
    }

    void Update()
    {
        if(wantsToUp && canUp)
        {
            wantsToUp = false;
            currentDirection = Vector3.up;
            mesh.transform.localScale = new Vector3(1, 1, 1);
            mesh.transform.rotation = Quaternion.Euler(0, 0, -90);

        }

        if (wantsToDown && canDown)
        {
            wantsToDown = false;
            currentDirection = Vector3.down;
            mesh.transform.localScale = new Vector3(-1, 1, 1);
            mesh.transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (wantsToRight && canRight)
        {
            wantsToRight = false;
            currentDirection = Vector3.right;
            mesh.transform.rotation = Quaternion.Euler(0, 0, 0);
            mesh.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (wantsToLeft && canLeft)
        {
            wantsToLeft = false;
            currentDirection = Vector3.left;
            mesh.transform.rotation = Quaternion.Euler(0, 0, 0);
            mesh.transform.localScale = new Vector3(1, 1, 1);
        }

        Move(currentDirection);
    }

    public void MoveUp()
    {
        wantsToUp = true;
        wantsToDown = false;
        wantsToRight = false;
        wantsToLeft = false;
    }

    public void MoveDown()
    {
        wantsToUp = false;
        wantsToDown = true;
        wantsToRight = false;
        wantsToLeft = false;
    }

    public void MoveRight()
    {
        wantsToUp = false;
        wantsToDown = false;
        wantsToRight = true;
        wantsToLeft = false;
    }

    public void MoveLeft()
    {
        wantsToUp = false;
        wantsToDown = false;
        wantsToRight = false;
        wantsToLeft = true;
    }

    public void Move(Vector3 direction)
    {
        transform.Translate(moveSpeed * direction * Time.deltaTime);
    }
}