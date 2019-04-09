using System;

namespace Dojodachi.Models
{
  public class Pet
  {
    public int Fullness { get; set; }
    public int Happiness { get; set; }
    public int Energy { get; set; }
    public int Meals { get; set; }
    public string Status { get; set; }
    public bool isDead { get; set; }

    public Pet()
    {
      Fullness = 20; 
      Happiness = 20; 
      Energy = 50; 
      Meals = 3; 
      Status = "Dojodachi is ready, start the game!";
      isDead = false; 
    }

    Random random = new Random();

    public void Feed()
    {
      if(Meals > 0)
      {
        Meals--; 
        if(random.Next(0,4) > 0)
        {
          int addFullness = random.Next(5,11);
          Fullness += addFullness;
          Status = $"Your Dojodachi had 1 meal and gained {addFullness} Fullness!";
        }
        else
        {
          Status = "Your Dojodachi doesn't want to eat!";
        }
      }
      else
      {
        Status = "You don't have any more meals, work to earn more meals for your Dojodachi!";
      }
      Won();
      Dead();
    }

    public void Play()
    {
      if(Energy >= 5)
      {
        Energy -= 5; 
        if(random.Next(0,4) > 0)
        {
          int addHappiness = random.Next(5,11);
          Happiness += addHappiness; 
          Status = $"Your Dojodachi gained {addHappiness} Happiness while using up 5 Energy!";
        }
        else 
        {
          Status = "Your Dojodachi doesn't feel like playing!";
        }
      }
      else 
      {
        Status = "You're out of energy and must eat to get more energy!";
      }
      Won(); 
      Dead(); 
    }

    public void Work()
    {
      if(Energy >= 5)
      {
        Energy -= 5; 
        int earnedMeals = random.Next(1,4);
        Meals += earnedMeals;
        Status = $"Your Dojodachi went to work, earned {earnedMeals} Meals and used 5 energy!";
      }
      else
      {
        Status = "You're out of energy, please allow your Dojodachi to eat to gain more energy!";
      }
      Won(); 
      Dead();
    }

    public void Sleep()
    {
      if(Fullness >= 5 && Happiness >= 5)
      {
        Fullness -= 5; 
        Happiness -= 5; 
        Energy += 15; 
      }
      else
      {
        Status = "You don't have enough happiness or fullness to go to sleep!";
      }
      Won();
      Dead();
    }

    public bool Dead()
    {
      if(Fullness == 0 && Energy == 0 && Happiness == 0)
      {
        isDead = true;
        Status = "Your Domodachi died... please take better care of your pet next time and restart to play again!";
        return true;
      }
      else {return false;}
    }

    public bool Won()
    {
      if(Fullness > 99 && Energy > 99 && Happiness > 99)
      {
        isDead = true; 
        Status = "You won! Want to play again?";
        return true; 
      }
      else {return false;}
    }

    public void Reset()
    {
      Fullness = 20; 
      Happiness = 20; 
      Meals = 3; 
      Energy = 50; 
      isDead = false; 
      Status = "Dojodachi is ready, start the game!";
    }
  }
}