# BlackJack Unit testing

Vervolledig de testen voor het blackjack project.

**Deadline:** 13/06/2022 09:00

## Gegeven

In deze repo vind je het startproject. Dit project is gemaakt aan de hand van een MVVM + C structuur. Alle code om het project te laten werken is reeds geschreven.

### BlackJack

In het blackjack project heeft onderstaande structuur:

- BlackJack
  - BlackJackPage.xaml
  - BlackJackViewModel.cs
- Cards
- CreateAccount
  - CreateAccountPage.xaml
  - CreateAccountViewModel.cs
- DataAccess
  - UserDataRepository.cs
- Helper
  - ActionCommand.cs
  - BlackJackDb.cs
  - BlackJackGame.cs
  - CardToBrushConverter.cs
  - Coordinator.cs
- Login
  - LoginPage.xaml
  - LoginViewModel.cs
- Model
  - Card.cs
  - Deck.cs
  - Suit.cs
  - User.cs
- App.xaml
- MainWindow.xaml

#### BlackJackPage.xaml, CreateAccountPage.xaml, LoginPage.xaml

Normaal zouden we met windows werken. Een andere manier van werken is gebruik maken van pages en de juiste page in te laden wanner we dit willen. Views worden op dezelfde manier als een window gemaakt. Het enige verschil is dat er in een page geen windowcontrols aanwezig zijn.

#### CardToBrushConverter.cs

Dit is een klasse die ons helpt om een card object om te zetten naar een image.

#### MainWindow.xaml

In de mainwindow gebeurd er momenteel niets. Dit window zal gebruikt worden om de juiste pages te tonen wanneer dit nodig is.

#### BlackJackDB

Dit is de klasse die ons zal helpen om de connectie naar de databank te leggen.

#### UserDataRepository

Met behulp van deze klasse, kunnen we op een gemakkelijke manier enkele database operaties doen. De belangrijkste operaties zijn:

- Users aanmaken
- Valideren of een bepaalde username al bestaat
- Een login valideren
- Budget aan een user toevoegen.

#### Card & User

Dit zijn 2 dataklasses die de data bijhouden voor kaarten en gebruikers.

#### Deck

Deck bevat de spelkaarten waarmee er gespeeld wordt. Deck bevat ook enkele functies om het aantal beschikbare kaarten in het deck te resetten. En om de kaarten te schudden.

#### Suit

Suit is een enum die de 4 mogelijk kaarttypes bijhoudt.

#### BlackJackGame.cs

Deze klasse is een klasse die ons helpt. Enerzijds is deze klasse verantwoordelijk om kaarten te delen. Anderzijds helpt deze klasse ook om de hoogste correcte waarde voor een speler te berekenen.

#### Coordinator.cs

Deze klasse helpt ons om de juiste views te tonen wanneer dit gevraagd wordt. Er zijn momenteel 4 opties:

- OpenLogin
- OpenCreateAccount
- OpenBlackJack
- ShowMessageBox

#### LoginViewModel, CreateAccountViewModel, BlackJackViewModel

Deze klasses bevatten de businesslogica voor de desbetreffende schermen.

### BlackJack.Tests

In het blackJack.Tests project, zijn alle nodige referenties en nuget packages reeds voorzien.

Ook vindt je hier al de klasses om je tests in te schrijven.

Tot slot is er 1 klasses `NSubstituteUtils` die 1 methode bevat om ons te helpen bij het mocken van een dbcontext klasse. Hieronder kan je een voorbeld vinden.

## Gevraagd

Vervolledig de testen die reeds gedefinieerd staan in de testklasses.

**Tip!** Onderstaande volgorde is aan te raden om de tests te schrijven:

- LoginViewModelTests
- CreateAccountViewModelTests
- BlackJackGameTests
- BlackJackViewModel
- UserDataRepositoryTests

Voorzie zelf de nodige mocks aan de hand van NSubstitute (niet voor elke test is dit nodig). Het is **niet** de bedoeling dat je het project wijzigt, wel mag je indien nodig klasses of methodes public maken (als ik het zou vergeten zijn). Ook mag je de nodige interfaces toevoegen met bijhorenden dependency injection (constructor toevoegen om de dependencies in te laden) om klasses testbaar te maken.

## Voorbeeld Mock BlackJackDb

We kunnen de klasse blackJackDB mocken zonder interface. In dit geval kunnen/mogen we een mock maken op basis van een gewone klasse.
In deze mock gaan we het resultaat van `Users` beïnvloeden, door hier ook een mock van DBSet aan toe te voegen. Voor dit laatste kunnen we gebruik maken van de methode `GenerateMockDbSet` die in de klasse `NSubstituteUtils` aanwezig is.

```c#
[Test]
public void GetUser_WithId_ReturnsCorrectUser()
{
    List<User> userList = new List<User>()
    {
        new User("Matthias", "password1"){ Id=1},// met behulp van de accolades kunnen we direct properties instellen, die we niet in de constructor gebruiken.
        new User("Ella", "password2"){Id=2}
    };

    // BlackJackDB Mocken
    BlackJackDb blackJackDb = Substitute.For<BlackJackDb>();
    // DbSet voor User maken met behulp van GenerateMockDbSet
    DbSet<User> mockUsers = NSubstituteUtils.GenerateMockDbSet(userList);

    // Instellen dat wanneer Users aangeroepen wordt, we gebruik maken van de mockUsers.
    blackJackDb.Users.Returns(mockUsers);
}
```

## Extra

Voeg gerust extra tests toe, als je er nog ziet.
De klasse deck kan enkele tests gebruiken en hier zijn op dit moment geen tests voor.
