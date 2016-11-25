using UnityEngine;
using System.Collections;

public class GoHomeGame : MonoBehaviour {

    public Vector2 homeLocation;
    public Vector2 playerLocation;
    public bool gameWon;

    // Use this for initialization
    void Start () {
        print("The fog surrounds me...");
        print("I have no idea where I am...");
        print("All I know is that I need to go home.");
        homeLocation = new Vector2(5, 8);
        gameWon = false;
    }

    // Update is called once per frame
    void Update () {
        if (gameWon == false)
        {
            UpdateMovement(KeyCode.LeftArrow, new Vector2(-1, 0));
            UpdateMovement(KeyCode.RightArrow, new Vector2(1, 0));
            UpdateMovement(KeyCode.UpArrow, new Vector2(0, 1));
            UpdateMovement(KeyCode.DownArrow, new Vector2(0, -1));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("I've gotten lost once more... I need to get home.");
                homeLocation = new Vector2(3, 6);
                gameWon = false;
            }
        }
    }

    private void UpdateMovement(KeyCode kc, Vector2 vect)
    {
        if (Input.GetKeyDown(kc))
        {
            playerLocation = playerLocation + vect;
            PrintDistanceToHome();
        }
    }

    private void PrintDistanceToHome()
    {
        Vector2 pathToHome = homeLocation - playerLocation;
        print("Distance to home: " + pathToHome.magnitude);
        if (playerLocation == homeLocation)
        {
            print("I've found my way home, finally!");
            print("Press spacebar to start again.");
            gameWon = true;
        }
    }
}
