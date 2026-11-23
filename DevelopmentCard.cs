using System;

namespace catan 
{
  class DevelopmentCard
  {
    public string Name { get; set;}
    public string CardType { get; set;}
    public int VictoryPoints { get; set;}
    public bool BoughtThisTurn { get; set;}
    public DevelopmentCard (string name, string cardType, int victoryPoints)
    {
      Name = name;
      CardType = cardType;
      VictoryPoints = victoryPoints;
    }
  }
}
