using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Labb4Steg1.App_Code
{
    public class SecretNumber
    {
        //fält vad ska va privat??
        private int _number;
        private List<int> _previousGuesses;
        //konstant
        public const int MaxNumberOfGuesses = 7;


        //Egenskaper
        public bool CanMakeGuess 
        {
            get
            {
                if (Outcome == Outcome.NoMoreGuesses)
                {
                    return false;
                }
                else if (Outcome == Outcome.Correct)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public int Count 
        { 
            get { return _previousGuesses.Count; } 
        }

        public int? Number //är nullable
        {
            get
            {
                if (CanMakeGuess == true)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
            //behövs set?
        }  

        public Outcome Outcome { get; private set; }

        public ReadOnlyCollection<int> PreviousGuesses
        {
            get
            {
                ReadOnlyCollection<int> prevGuesses = new ReadOnlyCollection<int>(_previousGuesses);
                return prevGuesses;
            }
        }

        //konstruktor
        public SecretNumber()
        {
            Initialize();
            _previousGuesses = new List<int>(7);
        }

        //Metoder
        public void Initialize()    //static?
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)     //static??
        {
            if (guess > 0 && guess < 101)
            {

                if (Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;
                    return Outcome;
                }
                if (guess == _number)
                {
                    Outcome = Outcome.Correct;
                    return Outcome;
                }
                if (_previousGuesses.Contains(guess))
                {
                    Outcome = Outcome.PreviousGuesses;
                    return Outcome;
                }
                if (guess < _number)
                {
                    Outcome = Outcome.Low;
                    return Outcome;
                }
                if (guess > _number)
                {
                    Outcome = Outcome.High;
                    return Outcome;
                }
                else if (PreviousGuesses.Contains(guess))
                {
                    Outcome = Outcome.PreviousGuesses;
                    return Outcome;
                }
                else
                {
                    Outcome = Outcome.Indefinite;
                    return Outcome;
                }

            }
            else
            {
                throw new ArgumentOutOfRangeException("guess", "talet måste vara mellan 1-100");
            }

        }
    }

    //uppräkningsbar typ Outcome
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuesses };
}