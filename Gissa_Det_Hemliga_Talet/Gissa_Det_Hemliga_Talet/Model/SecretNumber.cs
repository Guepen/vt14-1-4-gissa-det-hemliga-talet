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
                if (Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;

                    return true;
                }

                return false;
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
            if (guess < 1 || guess > 100)
            { 
                throw new ArgumentOutOfRangeException();
            }

            if (Count > MaxNumberOfGuesses)
            { 
                throw new ApplicationException(); 
            }


            if (guess < Number)
            {
                return Outcome.Low;
            }

            if (guess > Number)
            {
                return Outcome.High;
            }

            else
            {
               
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