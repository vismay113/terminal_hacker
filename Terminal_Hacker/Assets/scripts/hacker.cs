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

    const string menuHint = "You can goto main menu at any time by typing 'Menu or menu' !";
    const string developerName = "VA Pheon!X";
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
            levelManager(playerInput, level);
        }
    }

    public void HandleMainMenu(string playerInput)
    {
        if (playerInput == "T" || playerInput == "t")
        {
            level = 1;
            levelSelect(level);
        }
        else if (playerInput == "U" || playerInput == "u")
        {
            level = 2;
            levelSelect(level);
        }
        else if (playerInput == "M" || playerInput == "m")
        {
            level = 3;
            levelSelect(level);
        }
        else if (playerInput == "who is dev")
        {
            level = 8;
            levelSelect(level);
        }
        else if (playerInput == "quit" || playerInput == "Quit")
        {
            Application.Quit();
        }
        else
        {
            level = 10;
            levelSelect(level);
        }
    }

    public void levelSelect(int getLevel)
    {
        Terminal.ClearScreen();

        switch(level)
        {
            case 1:
                Terminal.WriteLine("There are 5 Firewalls in the Terrorist network.");
                Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");

                PasswordState(getLevel);

                break;

            case 2:
                Terminal.WriteLine("There are 5 Firewalls in the University network.");
                Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");

                PasswordState(getLevel);

                break;

            case 3:
                Terminal.WriteLine("There are 5 Firewalls in the Army network.");
                Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");

                PasswordState(getLevel);

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

    public void PasswordState(int getLevel)
    {
        currentState = gameState.Password;

        password = setPassword(getLevel);

        if (layerPassed <= 0)
        {
            Terminal.WriteLine("Enter the password, hint : ");
            Terminal.WriteLine(password.Anagram());
            Terminal.WriteLine("");
        }
        else
        {
            Terminal.WriteLine("Enter Password for Next layer, hint : ");
            Terminal.WriteLine(password.Anagram());
            Terminal.WriteLine("");
        }
    }

    public string setPassword(int getLevel)
    {
        string makePassword = null;

        switch(getLevel)
        {
            case 1:
                makePassword = tPassword[Random.Range(0, tPassword.Length)];
                break;

            case 2:
                makePassword = uPassword[Random.Range(0, uPassword.Length)];
                break;

            case 3:
                makePassword = mPassword[Random.Range(0, mPassword.Length)];
                break;

            default:
                Debug.LogError("Invalid level reached");
                break;
        }

        return makePassword;
    }

    public void levelManager(string playerInput, int getLevel)
    {
        if (playerInput == password)
        {
            Terminal.ClearScreen();

            Terminal.WriteLine("Congratulations...");
            Terminal.WriteLine("You have bypassed the firewall layer. Let's see if you can bypass the next one.");

            layerPassed++;

            PasswordState(getLevel);
        }
        else
        {
            failedAttempts--;
            Terminal.WriteLine("");
            Terminal.WriteLine("Wrong Password.");
            Terminal.WriteLine("Only " + failedAttempts + " attempts left.");
            
            if (failedAttempts < 3)
            {
                Terminal.WriteLine("");
                Terminal.WriteLine(menuHint);
                Terminal.WriteLine("");
            }

            Terminal.WriteLine("Enter the password, hint : ");
            Terminal.WriteLine(password.Anagram());
            Terminal.WriteLine("");
        }

        if (failedAttempts <= 0)
        {
            Terminal.ClearScreen();

            Terminal.WriteLine("As I thaught...");
            Terminal.WriteLine("You are not as good as you think you are !!!");
            Terminal.WriteLine("Type 'Menu' or 'menu' to go to welcome page.");
        }

        if (layerPassed == 5)
        {
            playerWon();
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