using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectors : MonoBehaviour
{
    public int direction; //1- Up  2- Down  3- Right  4- Left
    public PlayerController player;


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Laberinto"))
        {
            switch (direction)
            {
                case 1:
                    player.canUp = true;
                    break;
                case 2:
                    player.canDown = true;
                    break;
                case 3:
                    player.canRight = true;
                    break;
                case 4:
                    player.canLeft = true;
                    break;
            }
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Laberinto"))
        {
            switch (direction)
            {
                case 1:
                    player.canUp = false;
                    break;
                case 2:
                    player.canDown = false;
                    break;
                case 3:
                    player.canRight = false;
                    break;
                case 4:
                    player.canLeft = false;
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (direction == 5 && other.CompareTag("Laberinto"))
        {
            Vector3 lastDirection = player.currentDirection;
            player.currentDirection = Vector3.zero;
            player.Move(-lastDirection);
        }
    }
}
