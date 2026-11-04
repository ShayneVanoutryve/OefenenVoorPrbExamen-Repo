# Oefening selecties : verkeerslichten

Nadat je de starterscode hebt binnengehaald verschijnen volgende controls op je venster :   
  
![img1](assets/img1.png)  
  
Je zal in je solution explorer ook merken dat een map werd opgenomen met de naam "afbeeldingen" waarin zich 3 afbeeldingen bevinden :   
  
![img2](assets/img2.png)   
  
De bedoeling van het programma is om **random** getallen te genereren van 1 t/m 3 (dus of 1, of 2, of 3).   
  
Wanneer een getal = 1, dan moet : 
  * lblInfo in het oranje gekleurd worden  
  * er in lblInfo een aangepaste tekst verschijnen : ORANJE   Als het veilig kan, zou je nu best stoppen (zie afbeelding)  
  * in imgTrafficLight de correcte afbeelding verschijnen  
  ![oranje](assets/oranje.png)   
  
Wanneer een getal = 2, dan moet : 
  * lblInfo in het rood gekleurd worden  
  * er in lblInfo een aangepaste tekst verschijnen : ROOD   Gooi onmiddellijk alles dicht (zie afbeelding)  
  * in imgTrafficLight de correcte afbeelding verschijnen  
  ![rood](assets/rood.png)   
  
Wanneer een getal = 3, dan moet : 
  * lblInfo in het groen gekleurd worden  
  * er in lblInfo een aangepaste tekst verschijnen : GROEN   Karren maar. Alles veilig (zie afbeelding)  
  * in imgTrafficLight de correcte afbeelding verschijnen  
  ![groen](assets/groen.png)   
  
Het random getal genereer je zowel bij het opstarten van het programma als wanneer op btnNext wordt geklikt.  
Uiteraard voer je dan alle hierboven beschreven acties uit.  

De code om de afbeelding in imgTraffixLight te plaatsen is in je project reeds aanwezig via de methode SetTrafficLightImagePath.  
Deze methode krijgt als parameter de naam (een `string`) van de afbeelding die dient gebruikt te worden (dus ofwel "verkeer_groen.png", ofwel "verkeer_oranje.png" ofwel "verkeer_rood.png").  


### **INFO RANDOM GETALLEN**  
> 
> In C# is een random generator aanwezig.  
> Omdat je deze random generator op meerdere plaatsen zal nodig hebben doe je er goed aan om deze globaal te maken.  
> De generator maak je als volgt aan : 
> 
>   #### `Random rnd = new Random();`
> 
> waarbij **rnd** nu dus de ranom generator is  
> 
> Om deze random generator (rnd dus) te gebruiken pas je de **Next** methode toe.  Dit doe je bijvoorbeeld als volgt : 
> 
>   #### `int willekeurigGetal = rnd.Next(1,4);`  
>   
> In de variabele willekeurigGetal zit nu een willekeurig getal gaande van 1 tot 3 (dus of 1, of 2 of 3).  Hierbij is dus het eerste argument (in dit voorbeeld 1) de ondergrens, en het tweede argument (hier dus 4) de bovengrens + 1 : je dient als tweede argument dus steeds een waarde te kiezen die één groter is dan de maximaal te genereren waarde.  
> 
  
### **INFO Achtergrondkleur instellen**  
> 
> De achtergrondkleur van lblInfo kan je bijvoorbeeld als volgt in het oranje kleuren : 
> #### `lblInfo.Background = Brushes.Orange;`
>  Je gebruikt hier dus de Brushes klasse voor.  
>  Wil je ook de voorgrondkleur aanpassen, dan zoek je dat zelf even op internet op.
  
