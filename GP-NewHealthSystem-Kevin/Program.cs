using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_NewHealthSystem_Kevin
{
    internal class Program
    {
        static void Main(string[] args)
        {


















        }
    }

    class health
    {
        public health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;


        }
        




        private int _maxHealth = 100;
        private int _currentHealth = 100;
        public void Restore()
        {
            _currentHealth = _maxHealth;
        }
        public void Heal(int healing)
        {
            _currentHealth += healing;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
        public void TakeDamage(int DMG)
        {
            _currentHealth -= DMG;
            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }
        }
        public int currentHP
        {
            get { return _currentHealth; }
        }
        public int maxHP
        {
            get { return _maxHealth; }
        }







    }

    class player
    {
        public player(string name, int maxHealth, int maxShield)
        {
            _name = name;
            _Health = new health(maxHealth);
            _Shield = new health(maxShield);


        }
        string _name;
        health _Health;
        health _Shield;
        public string Name
        {
            get { return _name; }
        }
        public int Health
        {
            get { return _Health.currentHP; }
        }
        public int Shield
        {
            get { return _Shield.currentHP; }
        }
        public void TakeDamage(int DMG)
        {
            if (DMG < 0)
            {
                Console.WriteLine("error, value too low");
            }
            else if(_Shield.currentHP > 0)
            {
                if(DMG < _Shield.currentHP)
                {
                    _Shield.TakeDamage(DMG);
                }
                else
                {
                    DMG -= _Shield.currentHP;
                    _Shield.TakeDamage(1000000000);
                    _Health.TakeDamage(DMG);
                }
            }
            else
            {
                _Health.TakeDamage(DMG);
            }











        }
        public string GetStatusString()
        {
            string Status = "error";
            if( _Health.currentHP > (_Health.maxHP / 2))
            {
                Status = "Safe";
            }
            else if (_Health.currentHP > (_Health.maxHP / 4))
            {
                Status = "Danger";
            }
            else if (_Health.currentHP > 0)
            {
                Status = "Peral";
            }
            else if (_Health.currentHP <= 0)
            {
                Status = "Dead";
            }
            //you catch the referance?

            return Status;
        }






    }
}
