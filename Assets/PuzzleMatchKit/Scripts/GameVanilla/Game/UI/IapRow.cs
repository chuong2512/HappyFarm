﻿// Copyright (C) 2017-2020 gamevanilla. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using GameVanilla.Core;
using GameVanilla.Game.Common;
using GameVanilla.Game.Popups;

namespace GameVanilla.Game.UI
{
    /// <summary>
    /// An in-app purchasable item in the shop popup.
    /// </summary>
    public class IapRow : MonoBehaviour
    {
        [HideInInspector] public BuyCoinsPopup buyCoinsPopup;

        private int index;

#pragma warning disable 649
        [SerializeField] private GameObject mostPopular;
        [SerializeField] private GameObject bestValue;
        [SerializeField] private GameObject discount;
        [SerializeField] private Text discountText;
        [SerializeField] private Text numCoinsText;
        [SerializeField] private Text priceText;
        [SerializeField] private Image coinsImage;
        [SerializeField] private List<Sprite> coinIcons;
#pragma warning restore 649

        private IapItem cachedItem;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            Assert.IsNotNull(mostPopular);
            Assert.IsNotNull(bestValue);
            Assert.IsNotNull(discount);
            Assert.IsNotNull(discountText);
            Assert.IsNotNull(numCoinsText);
            Assert.IsNotNull(priceText);
            Assert.IsNotNull(coinsImage);
        }

        /// <summary>
        /// Fills this widget with the specified IAP item's information.
        /// </summary>
        /// <param name="item">The IAP item with which to fill this widget.</param>
        /// <param name="i"></param>
        public void Fill(IapItem item, int i)
        {
            cachedItem = item;

            index = i;

            numCoinsText.text = item.numCoins.ToString("n0");
            if (item.discount > 0)
            {
                discountText.text = string.Format("{0}%", item.discount);
            }
            else
            {
                discount.SetActive(false);
            }

            if (item.mostPopular)
            {
                bestValue.SetActive(false);
            }
            else if (item.bestValue)
            {
                mostPopular.SetActive(false);
            }
            else
            {
                mostPopular.SetActive(false);
                bestValue.SetActive(false);
            }

            coinsImage.sprite = coinIcons[(int)item.coinIcon];
            coinsImage.SetNativeSize();

            switch (index)
            {
                case 0:
                    priceText.text = "$9,99";
                    break;
                case 3:
                    priceText.text = "$0,99";
                    break;
                case 2:
                    priceText.text = "$2,99";
                    break;
                case 1:
                    priceText.text = "$4,99";
                    break;
            }
        }

        /// <summary>
        /// Called when the purchase button is pressed.
        /// </summary>
        public void OnPurchaseButtonPressed()
        {
            IAPManager.OnPurchaseSuccess = () =>
                PuzzleMatchManager.instance.coinsSystem.BuyCoins(cachedItem.numCoins);


            switch (index)
            {
                case 3:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                    break;
                case 2:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                    break;
                case 1:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                    break;
                case 0:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK4);
                    break;
            }


            GetComponent<PlaySound>().Play("Button");
        }
    }
}