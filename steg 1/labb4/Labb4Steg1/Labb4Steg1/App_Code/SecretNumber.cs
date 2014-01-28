using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb4Steg1.App_Code
{
    public class SecretNumber
    {
        //fält vad ska va privat??
        private int _number;
        private int _previousGuesses;

        public const int MaxNumberOfGuesses = 7;

        //Egenskaper
        public bool CanMakeGuess { get; }

        public int Count { get; }

        public int Number { get; }  //finns ett litet frågetecken bakom klassdiagrammet på denna

        public Outcome Outcome { get; private set; }        

        public IEnumerable PreviousGuesses { get; }

        //konstruktor
        public SecretNumber()
        {

        }

        //Metoder
        public static void Initialize()
        {
            _number = new Random(1, 101);
            _previousGuesses.Clear; 
        }

        public static int MakeGuess(int guess)
        {
            return; //returnera Outcome

        }
    }

    //uppräkningsbar typ Outcome

}