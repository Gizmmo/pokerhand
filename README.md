# pokerhand

This poker hand solver was created by Travis Scott.  You may need to download NUnit if NuGet doesn't get it automatically.

Assumptions
  - Game has a regular deck of 52, but I'm not making sure theres not overlaps (ex. two 2 of heart's cards)
  - If players tie on a combination of some sort, then the winner will be chosen by next highest cards
  - A tie on combination only happens if the combination has the exact same card ranks.  ex. a one pair where both players have a pair of 6's
  - You cannot override an existing players name, they will simply just be added further (there can be 100 travis' with all unqiue hands)
