﻿using System.Collections.ObjectModel;
using MPLib.Core.Game;

namespace MPLib.Models.Games.CardGames
{
    public interface ICardGameRound<TPlayer, out TMyPlayer> : IGameRound<TPlayer, TMyPlayer> where TPlayer : Player where TMyPlayer : Player
    {
        protected internal CardEncryptionKeys MyPlayerCardEncryptionKeys { get; set; }

        protected internal ReadOnlyCollection<Card> SourceDeck { get; set; }
    }
}
