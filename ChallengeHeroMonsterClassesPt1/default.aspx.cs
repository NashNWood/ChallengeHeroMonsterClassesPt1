using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPt1
{
    public partial class _default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Character peasant = new Character();

            peasant.Name = "Peasant";
            peasant.Health = 100;
            peasant.DamageMaximum = 100;
            peasant.AttackBonus = true;

            Character trogdor = new Character();

            trogdor.Name = "Trogdor the Burninator";
            trogdor.Health = 1000;
            trogdor.DamageMaximum = 50;
            trogdor.AttackBonus = false;

            Dice dice = new Dice();

            //Bonus
            if (peasant.AttackBonus)
                trogdor.Defend(peasant.Attack(dice));

            if (trogdor.AttackBonus)
                peasant.Defend(trogdor.Attack(dice));

            while (trogdor.Health > 0 && peasant.Health > 0)
            {
                trogdor.Defend(peasant.Attack(dice));
                peasant.Defend(trogdor.Attack(dice));

                //Play by play for the battle
                printStats(peasant);
                printStats(trogdor);

            }

            //This was a leftover from the first part of the assignment
            //int damage = peasant.Attack(dice);
            //trogdor.Defend(damage);

            //damage = trogdor.Attack(dice);
            //peasant.Defend(damage);

           
            displayResult(peasant, trogdor);

           
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
                resultLabel.Text += String.Format("<p>Both {0} and {1} died.</p>", opponent1.Name, opponent2.Name);

           else if (opponent1.Health <= 0)
                resultLabel.Text += String.Format("<p>{0} was slain in battle.</p>", opponent1.Name);

            else 
                resultLabel.Text += String.Format("<p>{0} was slain in battle.</p>", opponent2.Name);
        }

        private void printStats(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0} - Health: {1} - DamageMaximum: {2} - AttackBonus: {3}</p>",
                character.Name,
                character.Health,
                character.DamageMaximum,
                character.AttackBonus.ToString());
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            //Random random = new Random();
            //int damage = random.Next(this.DamageMaximum);

            dice.Sides = this.DamageMaximum;
            return dice.Roll();

        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();
        public int Roll()
        {
            return random.Next(this.Sides);

        }
    }
}