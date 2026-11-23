using System;
using System.Collections.Generic;

namespace catan
{
  class DevelopmentCardDeck
  {
    public List<DevelopmentCard> Cards = new List<DevelopmentCard> ();
    public DevelopmentCardDeck();
    {
      for(int i = 0; i < 14; i ++)
      {
        Cards.Add(new DevelopmentCard("Knight", "Knight", 0));
      }
      for(int i = 0; i < 2; i++
      {
        Cards.Add(new DevelopmentCard("Road Building", "Progress", 0));
        Cards.Add(new DevelopmentCard("Years of Plenty", "Progress", 0));
        Cards.Add(new DevelopmentCard("Monopoly", "Progress", 0));
      }
      Cards.Add(new DevelopmentCard("Chapel", "VictoryPoint", 1));
      Cards.Add(new DevelopmentCard("Library", "VictoryPoint", 1));
      Cards.Add(new DevelopmentCard("Market", "VictoryPoint", 1));
      Cards.Add(new DevelopmentCard("Palace", "VictoryPoint", 1));
      Cards.Add(new DevelopmentCard("University", "VictoryPoint", 1));
    }
  }
}
