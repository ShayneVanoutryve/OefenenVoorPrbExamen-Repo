# Oefening Methoden - Quiz

De gebruiker dient 3 vragen te beantwoorden.

Elk antwoord dient beoordeeld te worden (goed of fout) en het resultaat van die
beoordeling dient voor vraag 1 in lblFeedBack1 te komen, voor vraag 2 in lblFeedBack2
en voor vraag 3 in lblFeedBack3.

Alle controls zijn ondergebracht in zogenaamde WrapPanels : dit zijn containers
waarbinnen je controls kan onderbrengen.
Bij de opstart mag enkel de inhoud wrpQuestion1 zichtbaar en toegankelijk zijn:

![images/image02.png](images/image02.png)

Pas wanneer een antwoord gegeven wordt op vraag 1 (goed of fout) mag wrpQuestion2 zichtbaar worden.

We zorgen er ook voor dat – nu de gebruiker weet dat zijn/haar antwoord al dan niet goed is – bij vraag 1 geen nieuwe keuze gemaakt kan worden. We doen dit door de “enabled” eigenschap van het WrapPanel te wijzigen. Tevens dient in lblScore de score bijgehouden te worden (=verhogen met 1 bij een correct antwoord).

Hetzelfde geldt voor vraag 2 : na het beantwoorden wordt wrpQuestion3 zichtbaar + de
mogelijkheid om de quiz opnieuw te maken : de knop btnReset wordt zichtbaar en wanneer
hierop geklikt wordt keren we terug naar de toestand van in het begin (waar dus enkel
wrpQuestion1 zichtbaar en toegankelijk was en de score terug op 0 staat).

**Wanneer je merkt dat je in je programma 2 keer of meer identiek dezelfde code aan het
schrijven bent, denk dan even na. Misschien dien je wel een eigen methode te maken ?**

![images/image01.png](images/image01.png)

>Tip
>Je maakt een control zichtbaar of onzichtbaar door de eigenschap “Visibility” in te stellen. Je kan aan deze eigenschap (o.a.) de volgende waarden toekennen:
>
>* Visibility.Visible : de control is zichtbaar
>* Visibility.Hidden : de control is onzichtbaar maar er wordt plaats vrijgehouden
>* Visibility.Collapsed : de control is onzichtbaar en er wordt geen plaats vrijgehouden
