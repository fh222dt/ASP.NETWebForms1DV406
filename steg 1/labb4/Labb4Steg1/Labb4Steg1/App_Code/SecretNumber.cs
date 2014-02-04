using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Labb4Steg1.App_Code
{
    public class SecretNumber
    {
        //fält
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
        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _previousGuesses = new List<int>();
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess > 0 && guess < 101)
            {
                if (guess == _number)
                {
                    Outcome = Outcome.Correct;
                    _previousGuesses.Add(guess);
                    return Outcome;
                }

                if (Count+1 >= MaxNumberOfGuesses)  //plus 1 för att kolla av innan gissningen är klar
                {
                    Outcome = Outcome.NoMoreGuesses;
                    _previousGuesses.Add(guess);
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
                    _previousGuesses.Add(guess);
                    return Outcome;
                }
                if (guess > _number)
                {
                    Outcome = Outcome.High;
                    _previousGuesses.Add(guess);
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