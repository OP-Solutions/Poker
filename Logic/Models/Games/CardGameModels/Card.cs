﻿using System;
using EtherBetClientLib.Models.Games.Poker;

namespace EtherBetClientLib.Models.Games.CardGameModels
{
    /// <summary>
    /// The card.
    /// </summary>
    public struct Card : IComparable<Card>
    {
        public const int RankCount = 13;
        public const int SuitCount = 4;

        public bool Equals(Card other)
        {
            return Rank == other.Rank && Suit == other.Suit;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return obj is Card card && Equals(card);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Rank * 397) ^ (int) Suit;
            }
        }

        public override string ToString()
        {
            return $"{Rank}, {Suit}";
        }

        /// <summary>
        /// Card rank
        /// </summary>
        public readonly CardRank Rank;

        /// <summary>
        /// Card suit
        /// </summary>
        public readonly CardSuit Suit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> struct. 
        /// </summary>
        /// <param name="rank">
        /// Card rank
        /// </param>
        /// <param name="suit">
        /// Card suit
        /// </param>
        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }


        public static int ToNumber(Card card)
        {
            return ((int) card.Rank - 1) + ((int) card.Suit - 1) * RankCount;
        }

        /// <summary>
        /// Extension method to cast int to Card
        /// </summary>
        public static Card FromNumber(int number)
        {
            var rank = (number % RankCount) + 1;
            
            var suit = (number / RankCount) + 1;

            return new Card((CardRank)rank, (CardSuit)suit);
        }

        #region OPERATOR OVERLOADING AND INTERFACE IMPLEMENTING

        public static bool operator >(Card first, Card second)
        {
            return (int) first.Rank > (int) second.Rank;
        }

        public static bool operator <(Card first, Card second)
        {
            return (int) first.Rank < (int) second.Rank;
        }

        public static int operator -(Card first, Card second)
        {
            return first.Rank - second.Rank;
        }

        public static bool operator !=(Card first, Card second) => !(first == second);

        public static bool operator ==(Card first, Card second) =>
            first.Rank == second.Rank && first.Suit == second.Suit;

        public int CompareTo(Card other)
        {
            return (int) Rank - (int) other.Rank;
        }

        #endregion
    }
}