using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour
{
    // game state & configuration data 
    int level;
    int layerPassed = 0;
    int failedAttempts = 5;

    enum gameState { Menu, Password, Win };
    gameState currentState;

    string developerName = "VA Pheon!X";
    string password = null;

    string[] tPassword = { "assault", "brutality", "confusion", "ferocity", "vehemence", "fierceness", "massacre", "carnage" };
    string[] uPassword = { "collage", "polytechnic", "matriculate", "cantabrigian", "fraternity", "grant", "professoriate", "library" };
    string[] mPassword = { "ballistic", "conscription", "fortification", "ammunition", "amphibious", "bombardment", "encampment", "midshipman" };

    // Start is called before the first frame update
    void Start()
    {
        StartMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMenu()
    {
        currentState = gameState.Menu;
        layerPassed = 0;
        failedAttempts = 5;
        Terminal.ClearScreen();

        Terminal.WriteLine("Welcome to the Hacking Chalange !");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 'T/t' for Terrorist Network");
        Terminal.WriteLine("Press 'U/u' for University Network");
        Terminal.WriteLine("Press 'M/m' for Military Network");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter Your Choice - ");
    }

    void OnUserInput(string playerInput)
    {
        if (playerInput == "Menu" || playerInput == "menu")
        {
            level = 0;
            StartMenu();
        }
        else if (currentState == gameState.Menu)
        {
            HandleMainMenu(playerInput);
        }
        else if (currentState == gameState.Password)
        {
            levelManager(playerInput);
        }
    }

    public void levelSelect()
    {
        Terminal.ClearScreen();

        switch(level)
        {
            case 1:
                Terminal.WriteLine("There are 8 Firewalls in the Terrorist network.");
                Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");

                PasswordState();

                break;

            case 2:
                Terminal.WriteLine("There are 8 Firewalls in the University network.");
                Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");

                PasswordState();

                break;

            case 3:
                Terminal.WriteLine("There are 8 Firewalls in the Army network.");
                Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");

                PasswordState();

                break;

            case 8:
                Terminal.WriteLine("This small game is developed by : " + developerName);
                Terminal.WriteLine("Thank you for caring");
                Terminal.WriteLine("");
                Terminal.WriteLine("Please type 'Menu' or 'menu' to go to welcome page.");
                break;

            default:
                Terminal.WriteLine("");
                Terminal.WriteLine("You can't even Make the right choice !");
                Terminal.WriteLine("Then how are you going to hack us !");
                break;
        }
    }

    public void PasswordState()
    {
        currentState = gameState.Password;

        Terminal.ClearScreen();
        Terminal.WriteLine("Enter the password : ");
    }

    public void HandleMainMenu(string playerInput)
    {
        if (playerInput == "T" || playerInput == "t")
        {
            level = 1;
            password = tPassword[Random.Range(0, tPassword.Length)];
            levelSelect();
        }
        else if (playerInput == "U" || playerInput == "u")
        {
            level = 2;
            password = uPassword[Random.Range(0, uPassword.Length)];
            levelSelect();
        }
        else if (playerInput == "M" || playerInput == "m")
        {
            level = 3;
            password = mPassword[Random.Range(0, mPassword.Length)];
            levelSelect();
        }
        else if (playerInput == "who is dev")
        {
            level = 8;
            levelSelect();
        }
        else if (playerInput == "quit" || playerInput == "Quit")
        {
            Application.Quit();
        }
        else
        {
            level = 10;
            levelSelect();
        }
    }

    public void levelManager(string playerInput)
    {
        if (playerInput == password)
        {
            Terminal.WriteLine("Congratulations...");
            Terminal.WriteLine("You have bypassed the firewall layer. Let's see if you can bypass the next one.");

            layerPassed++;
        }
        else
        {
            failedAttempts--;
            Terminal.WriteLine("Wrong Password.");
            Terminal.WriteLine("Only " + failedAttempts + " attempts left.");
            Terminal.WriteLine("Enter the password : ");
        }

        if (failedAttempts <= 0)
        {
            Terminal.ClearScreen();

            Terminal.WriteLine("As I thaught...");
            Terminal.WriteLine("You are not as good as you think you are !!!");
            Terminal.WriteLine("Type 'Menu' or 'menu' to go to welcome page.");
        }
    }

    public void playerWon()
    {
        Terminal.ClearScreen();

        Terminal.WriteLine("Looks like I am a looser now.");
        Terminal.WriteLine("");
        Terminal.WriteLine("You are more than I was counting.");
        Terminal.WriteLine("");
        Terminal.WriteLine("You can be great asset to my team.");
        Terminal.WriteLine("Thank you for playing.");
        Terminal.WriteLine("Type 'Menu' or 'menu' to go to welcome page.");
    }
}
