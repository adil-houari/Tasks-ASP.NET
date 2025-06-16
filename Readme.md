[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/2pnOTwD3)

[![.NET](../../actions/workflows/main.yml/badge.svg)](../../actions/workflows/main.yml)


# Oefening Test Doubles #2

## Opgave 1: NotesTakingApp (NotesService)
In de solution vind je een project om notes op te slaan in een database (de implementatie in de program klasse is wel achterwege gelaten).

### Beschrijving klasses
De 2 belangrijke klasses in deze opgave zijn:
* NotesRepository
* NotesService

#### NotesRepository
De NotesRepository is verantwoordelijk voor de communicatie met de database. Deze klasse bevat de CRUD-operaties die we nodig hebben in de applicatie.

#### NotesService
Deze is verantwoordelijk voor operaties op de data. Deze klasse gaat niet zelf rechtstreeks de database aanspreken maar maakt gebruik van de NotesRepository. 

### Testen
Vervolledig de tests die reeds voorzien zijn. Enkel de methodes zijn voorzien.

#### NotesServiceTests
Begin met deze tests te schrijven. Maak hierbij gebruik van NSubstitute om test doubles te creëren.

Vergeet ook niet de applicatie code zodanig te maken dat je gebruik kan maken van test-doubles. Denk hierbij aan onderstaande stappen:

1. Maak voor de afhankelijkheden van je te testen klasse een interface zodat deze afhankelijkheden tijdens het testen geïnjecteerd kunnen worden.
2. Gebruik in je te testen klasse enkel de interface als object-type.
3. Zorg ervoor dat je in een constructor kan kiezen welke klasse je gebruikt als afhankelijkheid.


## Opgave 2: Yahtzee
In de solution vind je een eenvoudige implementatie van het spel Yahtzee.

### Belangrijke klasses
De enige klasse die logica bevat is de YathzeeGame klasse. De klasse bevat logica om met 5 dobbelstenen te rollen. Met de methode `CalculateYahtzeeValue` kan je berekenen wat je score is voor een bepaalde worp voor een bepaalde `YahtzeeCategory`. 

### Testen
Kies zelf 3 categorieën waarvoor je testen wil schrijven. Voor elke categorie worden er 2 testen verwacht.

1. Test waarbij de score 0 is.
2. Test waarbij de score groter dan 0 is.

Je schrijft dus in totaal 6 testen.

__!! belangrijk:  Zorg ervoor dat je de randomwaardes zelf onder controle hebt. Maak gebruik van een Test double voor je randomwaarden.__

