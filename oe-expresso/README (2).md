# pe01-expresso-start
Eerste PE-opdracht voor PRB. Basis variabelen, scope en wpf-controls (nog geen gebruik van if ... else).

# Opdrachtomschrijving
Maak een WPF-applicatie voor een kassier in een koffiewinkel van een liefdadigheidsinstelling. Alle koffies, ongeacht hun grootte zijn er namelijk even duur!

# Beoordeling
## Minimumvereisten
* Het gebruik van variabelen en methodes is verplicht (waar gepast).

## Wat is goede codekwaliteit?
Goede codekwaliteit betekent goed gestructureerde code, goed gekozen variabelenamen, gebruik van aparte methodes waar nodig en het volgen van de C# naming conventions. 

# Functionaliteit
## De kassier kan:
* Ingeven welke grootte van koffie de klant wil (Small, Medium, Large)
* Bijhouden welke soort koffie er besteld worden door klanten uit hun assortiment
* Bijhouden hoeveel koffies er besteld moeten worden
* Een fooi ontvangen
* Een enkele bestelling in een wachtrij plaatsen. In dit geval moet de klant onmiddellijk betalen, maar wordt de koffie 'on demand geleverd'.
  Deze functie is slecht 1x beschikbaar. Er kunnen dus geen 2 klanten terzelfdertijd de wachtrij gebruiken. De wachtrij wordt wel weer
  beschikbaar gemaakt na afhandeling.
* **Bestellingen die afgehandeld zijn, worden getoond in lijst.**
  
## Er worden ook statistieken bijgehouden:
* van het aantal bestellingen
* van het totale aantal verkochte koffies
* van de totale inkomsten

## Gebruiksvriendelijkheid
* Zorg voor een gebruiksvriendelijke app: ken standaardwaarden toe en leeg de inputvelden wanneer er een bestelling geplaatst werd.

# Belangrijke opmerkingen
* **Indien de inputvelden blanco ingediend worden zal je applicatie hoogstwaarschijnlijk crashen. Hier worden géén punten voor afgetrokken.**
* Extra features toevoegen aan je oplossing mag, maar zorg er voor dat de bovenstaande minimum requirements zeker behaald worden. Extra inzet wordt beloond.

# Voorbeeld
![example](screens/coffeeflow.gif?raw=true)
