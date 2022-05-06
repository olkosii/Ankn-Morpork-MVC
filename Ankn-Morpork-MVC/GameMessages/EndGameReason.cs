using System;

namespace Ankn_Morpork_MVC.GameMessages
{
    public class EndGameReason
    {
        public const string winMessage = "CONGRATULATIONS!!! You have earned enough money to leave Ankn Morpork";
        public const string diedMessage = "YOU DIED...";
        public const string notSuitablePlayerRewardMessage = "This Assassin wouldn't accept reward of that amount";
        public const string assasinKillMessage = "Assasin killed you";
        public const string thiefKillMessage = "You resisted and thief killed you";
        public const string beggarKillMessage = "Beggar chase you to death";
        public const string playerDidNotHaveEnoughMoneyForBeggarMessage = "You didn't have enough money in order to pay Beggar guild";
        public const string playerDidNotHaveEnoughMoneyForAssasinMessage = "You didn't have enough money in order to pay Assasin guild";
        public const string playerDidNotHaveEnoughMoneyForThiefMessage = "You didn't have enough money in order to pay Thief guild";
    }
}