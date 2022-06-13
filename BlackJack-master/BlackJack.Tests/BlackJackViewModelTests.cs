using NUnit.Framework;

namespace BlackJack.Tests
{
    internal class BlackJackViewModelTests
    {
        [Test]
        public void Ctor_OnCleanStart_CorrectButtonsAreEnabled()
        {

        }

        [Test]
        public void Ctor_OnCleanStart_BudgetIsLoadedAndDefaultBidIsSet()
        {

        }

        [Test]
        public void ChangeBidString_WithEmptyString_StartGameButtonIsDisabled()
        {

        }

        [Test]
        public void ChangeBidString_WithNonEmptyString_StartGameButtonIsEnabled()
        {

        }

        [Test]
        public void LogOutCommand_OpensLoginScreen()
        {

        }

        [Test]
        public void TakeCardCommand_AddsCardToPlayerHandAndUpdatesScore()
        {

        }

        [Test]
        public void TakeCardCommand_WithEndTotalAbove21_DealerGetsNextCards()
        {

        }

        [Test]
        public void StopCommandAction_DealersLastCardIsTurnedAndUpdatesScore()
        {

        }

        [Test]
        // Blackjack is een score van 21 hebben met slechts 2 kaarten
        public void StopCommandAction_WithPlayerHavingBlackJack_DealerDoesntTakeCards()
        {

        }

        public void StopCommandAction_WithPlayerBusted_DealerDoesntTakeCards()
        {

        }

        [Test]
        public void StopCommandAction_WithPlayerNotHavingBlackJack_DealerTakesCardsUntilAtLeastAScoreOf17AndUpdatesScore()
        {

        }

        [Test]
        public void StopCommand_EnablesBidStringAndDisablesTakeCardAndStopButton()
        {

        }

        [Test]
        public void StopCommand_WithPlayerHavingBlackJackAndDealerDoesnt_ResultIsBlackJackAndBudgetRaisesWith150Percent()
        {

        }

        [Test]
        public void StopCommand_WithPlayerAndDealerHavingBlackJack_ResultIsDrawAndBidIsRepayed()
        {

        }

        [Test]
        public void StopCommand_WithPlayerBustedAndDealerNot_ResultIsLostAndBudgetDoesntChange()
        {

        }

        [Test]
        public void StopCommand_WithPlayerNotBustedAndDealerBusted_ResultIsWinAndBudgetRaisesWith100Percent()
        {

        }

        [Test]
        public void StopCommand_WithPlayerAndDealerBusted_ResultIsLostAndBudgetDoesntChange()
        {

        }

        [Test]
        public void StopCommand_WithPlayerHigherValueThanDealer_ResultIsWinAndBudgetRaisesWith100Percent()
        {

        }

        [Test]
        public void StopCommand_WithDealerHigherValueThanPlayer_ResultIsLostAndBudgetDoesntChange()
        {

        }

        [Test]
        public void StopCommand_WithDealerAndPlayerSameValue_ResultIsDrawAndBidIsRepayed()
        {

        }

        [Test]
        public void StartCommand_DisablesStartGameButtonAndBidStringEnablesDrawCardAndStopButtonAndHidesResult()
        {

        }

        [Test]
        public void StartCommand_ClearsPlayerAndDealersHandAndAdds2NewCardsLastCardOfDealerIsHidden()
        {

        }

        [Test]
        public void StartGameCommand_WithBid_ReducesBudget()
        {

        }
    }
}
