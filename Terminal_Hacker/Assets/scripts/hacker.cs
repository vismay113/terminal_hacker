using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour
{
    string developerName = "VA Pheon!X";

    // Start is called before the first frame update
    void Start()
    {
        StartMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static void StartMenu()
    { 
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
        if (playerInput == "T" || playerInput == "t")
        {
            TerrorismCase();
        }
        else if (playerInput == "U" || playerInput == "u")
        {
            UniversityCase();
        }
        else if (playerInput == "M" || playerInput == "m")
        {
            MilitaryCase();
        }
        else if (playerInput == "Menu" || playerInput == "menu")
        {
            StartMenu();
        }
        else if (playerInput == "who is dev")
        {
            Terminal.ClearScreen();

            Terminal.WriteLine("This small game is developed by : " + developerName);
            Terminal.WriteLine("Thanlk you for caring");
            Terminal.WriteLine("");
            Terminal.WriteLine("Please type 'Menu' or 'menu' to go to wlcome page.");
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("You can't even Make the right choice !");
            Terminal.WriteLine("Then how are you going to hack us !");
        }
    }

    public void TerrorismCase()
    {
        Terminal.ClearScreen();

        Terminal.WriteLine("There are 8 Firewalls in the Terrorist network.");
        Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");
    }

    public void UniversityCase()
    {
        Terminal.ClearScreen();

        Terminal.WriteLine("There are 8 Firewalls in the University network.");
        Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");
    }

    public void MilitaryCase()
    {
        Terminal.ClearScreen();

        Terminal.WriteLine("There are 8 Firewalls in the Army network.");
        Terminal.WriteLine("I chalange that you can't even bypass 1 Firewall !");
    }
}
