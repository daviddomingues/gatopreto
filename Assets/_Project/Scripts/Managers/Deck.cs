﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ProjetoGatoPreto
{
	public class Deck : MonoBehaviour
	{
		public List<CardData> cards;
		public CardData TopCardData
		{
			set
			{
				SetOpenCard(value);
			}
			get
			{
				return topCardData;
			}
		}
		private CardData topCardData;
		private Card topCard;
		private Image bottomCardFrontImage;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			topCard = ReferencesManager.instance.card.GetComponent<Card>();
			bottomCardFrontImage = ReferencesManager.instance.dummyCardFront.GetComponent<Image>();
		}

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			Shuffle();
			Draw();
		}

		void SetOpenCard(CardData cardData)
		{
			topCard.Data = cardData;
			topCardData = cardData;
		}

		public void Shuffle()
		{
			cards.Shuffle();
		}

		public CardData Draw()
		{
			if (cards.Count <= 0)
			{
				return null;
			}
			else
			{
				TopCardData = cards[0];
				if (cards.Count >= 2)
				{
					bottomCardFrontImage.sprite = cards[1].cardTexture;
					bottomCardFrontImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				}
				else
				{
					bottomCardFrontImage.sprite = null;
					bottomCardFrontImage.color = new Color(1f, 1f, 1f, 0f);
				}
				return cards[0];
			}
		}

		public void Discard()
		{
			TopCardData = null;
			if (cards.Count <= 0)
			{
				cards.RemoveAt(0);
			}
		}
	}
}