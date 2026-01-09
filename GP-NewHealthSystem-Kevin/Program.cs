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












    }
}
