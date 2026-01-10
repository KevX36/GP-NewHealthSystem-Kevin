using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_NewHealthSystem_Kevin
{
    internal class Program
    {
        static bool valadInput = false;
        static Random random = new Random();
        //if ture heal, if not do Damage
        static bool HealOrDMG = true;
        static void Main(string[] args)
        {
            int Roll = random.Next(1, 20);
            Console.WriteLine("Please enter a name, then hit enter");
            string name = Console.ReadLine();
            player p1 = new player(name,100,100);
            
            while (p1.Health > 0)
            {
                Console.WriteLine($"{p1}    Health: {p1.Health}     Shield: {p1.Shield}     Status: {p1.GetStatusString()}");
                while (valadInput == false)
                {
                    Console.WriteLine("enter D to take damage, enter H to heal");
                    string inupt = Console.ReadLine();
                    if (inupt == "H")
                    {
                        HealOrDMG = true;
                        valadInput = true;
                    }
                    else if (inupt == "h")
                    {
                        HealOrDMG = true;
                        valadInput = true;
                    }
                    else if (inupt == "D")
                    {
                        HealOrDMG = false;
                        valadInput = true;
                    }
                    else if (inupt == "d")
                    {
                        HealOrDMG = false;
                        valadInput = true;
                    }
                    else
                    {
                        Console.WriteLine("that is not a valad input, try again");
                    }

                }
                valadInput = false;
                if(HealOrDMG == true)
                {
                    p1.heal(Roll);
                }
                else
                {
                    p1.TakeDamage(Roll);
                }

                Console.Clear();

            }
            Console.WriteLine("You died, press enter key to end");
            Console.ReadLine();












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
        public void heal(int recover)
        {
            _Health.Heal(recover);
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
