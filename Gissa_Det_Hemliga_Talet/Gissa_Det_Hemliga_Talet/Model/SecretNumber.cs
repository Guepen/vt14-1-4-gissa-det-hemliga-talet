using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Gissa_Det_Hemliga_Talet.Model
{
     public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreveiousGuess };

    public class SecretNumber
    {
        private int _number;
        private List<int> _preveiousGuesses; 
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses;
               
            }

        }

        public int Count
        {
           get{return _preveiousGuesses.Count;}
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                { 
                    return null; 
                }

                else
                {
                    return _number;
                }

            }
        }

        public Outcome Outcome
        {
            get;
            private set;
        }

        public IEnumerable<int> PreviousGuesses
        {
            get { return _preveiousGuesses.AsReadOnly(); }
        }

        public void Initialize()
        {
            Outcome = Outcome.Indefinite;
            _preveiousGuesses.Clear();
            Random ran = new Random();
            _number = ran.Next(1,101);
 
        }

        public Outcome MakeGuess(int guess)
        {
            if (Count >= MaxNumberOfGuesses)
            {
                return Outcome.NoMoreGuesses;
            }

            if (PreviousGuesses.Contains(guess))
            {
                return Outcome.PreveiousGuess;
            }

            _preveiousGuesses.Add(guess);

            if(guess < _number)
            {
               return Outcome.Low;

            }

            else if (guess > _number)
            {
               return Outcome.High;
            }

            else{
                return Outcome.Correct;   
            }

         }

        public SecretNumber()
        {
            _preveiousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }



    }
}