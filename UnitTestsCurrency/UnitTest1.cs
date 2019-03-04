using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP2_CoinProgram;

namespace UnitTestsCurrency
{
    [TestClass]
    public class USCoinTests
    {

        Penny p;

        public USCoinTests()
        {
            p = new Penny();
        }


        [TestMethod]
        public void USCoinPennyConstructor()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual(OOP2_CoinProgram.USCoinMintMark.D, p.MintMark); //D is the default mint mark
            Assert.AreEqual(System.DateTime.Now.Year, p.Year); //Current year is default year

        }

        [TestMethod]
        public void USCoinMintMark()
        {

            //Arrange
            string mintNameDenver, mintNamePhili, mintNameSanFran, mintNameWestPoint;
            USCoinMintMark D, P, S, W;

            //Act 
            mintNameDenver = "Denver";
            mintNamePhili = "Philadelphia";
            mintNameSanFran = "San Francisco";
            mintNameWestPoint = "West Point";
            D = OOP2_CoinProgram.USCoinMintMark.D;
            P = OOP2_CoinProgram.USCoinMintMark.P;
            S = OOP2_CoinProgram.USCoinMintMark.S;
            W = OOP2_CoinProgram.USCoinMintMark.W;

            //Assert
            Assert.AreEqual(USCoin.GetMintNameFromMark(D), mintNameDenver);
            Assert.AreEqual(USCoin.GetMintNameFromMark(P), mintNamePhili);
            Assert.AreEqual(USCoin.GetMintNameFromMark(S), mintNameSanFran);
            Assert.AreEqual(USCoin.GetMintNameFromMark(W), mintNameWestPoint);
        }

        [TestMethod]
        public void USCoinPennyMonetaryValue()
        {
            //Arrange
            p = new Penny();
            //Act 
            //nothing should have .01;
            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        [TestMethod]
        public void USCoinPennyAbout()
        {
            //Arrange
            p = new Penny();
            //Act 

            //Assert
            Assert.AreEqual("US Penny is from 2019. It is worth $0.01. It was made in Denver", p.About());
        }
    }
    [TestClass]
    public class PennyTests
    {
        public Penny p, philiPenny;

        [TestMethod]
        public void PennyConstructor()
        {
            //Arrange
            //Act 
            p = new Penny();
            philiPenny = new Penny(USCoinMintMark.P);
            //Assert
            //D is the default mint mark
            //Current Year is default year

            Assert.AreEqual(USCoinMintMark.P, philiPenny.MintMark);
        }

        [TestMethod]
        public void PennyMonetaryValue()
        {
            //Arrange
            Penny p;
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        [TestMethod]
        public void PennyAbout()
        {
            //Arrange
            Penny p;
            //Act 
            p = new Penny();
            //Assert
            //About output "US Penny is from 2017. It is worth $0.01. It was made in Denver"
        }
    }

    [TestClass]
    public class USCurrencyRepoTests
    {
        CurrencyRepo USCurrencyRepo;
        Penny penny;
        Nickel nickel;
        Dime dime;
        Quarter quarter;
        DollarCoin dollarCoin;


        public USCurrencyRepoTests()
        {
            USCurrencyRepo = new CurrencyRepo();
            penny = new Penny();
            nickel = new Nickel();
            dime = new Dime();
            quarter = new Quarter();
            dollarCoin = new DollarCoin();
        }

        [TestMethod]
        public void AddCoinTest()
        {
            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;
            //Act
            coinCountOrig = USCurrencyRepo.GetCoinCount();
            valueOrig = USCurrencyRepo.TotalValue();

            USCurrencyRepo.AddCoin(penny);
            coinCountAfterPenny = USCurrencyRepo.GetCoinCount();
            valueAfterPenny = USCurrencyRepo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                USCurrencyRepo.AddCoin(penny);
            }
            coinCountAfterFiveMorePennies = USCurrencyRepo.GetCoinCount();
            valueAfterFiveMorePennies = USCurrencyRepo.TotalValue();

            USCurrencyRepo.AddCoin(nickel);
            valueAfterNickel = USCurrencyRepo.TotalValue();
            USCurrencyRepo.AddCoin(dime);
            valueAfterDime = USCurrencyRepo.TotalValue();
            USCurrencyRepo.AddCoin(quarter);
            valueAfterQuarter = USCurrencyRepo.TotalValue();
            USCurrencyRepo.AddCoin(dollarCoin);
            valueAfterDollar = USCurrencyRepo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig + 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny + numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig + penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny + (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);

            Assert.AreEqual(valueAfterFiveMorePennies + nickel.MonetaryValue, valueAfterNickel);
            Assert.AreEqual(valueAfterNickel + dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime + quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter + dollarCoin.MonetaryValue, valueAfterDollar);

        }


        [TestMethod]
        public void RemoveCoinTest()
        {

            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;

            USCurrencyRepo = new CurrencyRepo();  //reset repo

            //add some coins
            USCurrencyRepo.AddCoin(penny);

            for (int i = 0; i < numPennies; i++)
            {
                USCurrencyRepo.AddCoin(penny);
            }
            USCurrencyRepo.AddCoin(nickel);
            USCurrencyRepo.AddCoin(dime);
            USCurrencyRepo.AddCoin(quarter);
            USCurrencyRepo.AddCoin(dollarCoin);

            //Act
            coinCountOrig = USCurrencyRepo.GetCoinCount();
            valueOrig = USCurrencyRepo.TotalValue();
            USCurrencyRepo.RemoveCoin(penny);
            coinCountAfterPenny = USCurrencyRepo.GetCoinCount();
            valueAfterPenny = USCurrencyRepo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                USCurrencyRepo.RemoveCoin(penny);
            }
            coinCountAfterFiveMorePennies = USCurrencyRepo.GetCoinCount();
            valueAfterFiveMorePennies = USCurrencyRepo.TotalValue();

            USCurrencyRepo.RemoveCoin(nickel);
            valueAfterNickel = USCurrencyRepo.TotalValue();
            USCurrencyRepo.RemoveCoin(dime);
            valueAfterDime = USCurrencyRepo.TotalValue();
            USCurrencyRepo.RemoveCoin(quarter);
            valueAfterQuarter = USCurrencyRepo.TotalValue();
            USCurrencyRepo.RemoveCoin(dollarCoin);
            valueAfterDollar = USCurrencyRepo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig - 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny - numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig - penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny - (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);
            
            Assert.AreEqual(valueAfterNickel - dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime - quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter - dollarCoin.MonetaryValue, valueAfterDollar);

        }

        [TestMethod]
        public void MakeChangeTests()
        {
            //Arrange
            CurrencyRepo changeOneQuatersOnHalfDollar, changeTwoDollars, changeOneDollarOneHalfDoller,
               changeOneDimeOnePenny, changeOneNickelOnePenny, changeFourPennies;


            //Act
            changeTwoDollars = (CurrencyRepo)USCurrencyRepo.CreateChange(2.0);
            changeOneDollarOneHalfDoller = (CurrencyRepo)USCurrencyRepo.CreateChange(1.5);
            changeOneQuatersOnHalfDollar = (CurrencyRepo)USCurrencyRepo.CreateChange(.75);

            changeOneDimeOnePenny = (CurrencyRepo)USCurrencyRepo.CreateChange(.11);
            changeOneNickelOnePenny = (CurrencyRepo)USCurrencyRepo.CreateChange(.06);
            changeFourPennies = (CurrencyRepo)USCurrencyRepo.CreateChange(.04);


            //Assert
            Assert.AreEqual(changeTwoDollars.Coins.Count, 2);
            Assert.AreEqual(changeTwoDollars.Coins[0].GetType(), new DollarCoin().GetType());
            Assert.AreEqual(changeTwoDollars.Coins[1].GetType(), new DollarCoin().GetType());

            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins.Count, 2);
            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins[0].GetType(), new DollarCoin().GetType());
            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins[1].GetType(), new HalfDollar().GetType());


            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins.Count, 2);
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins[0].GetType(), new HalfDollar().GetType());
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins[1].GetType(), new Quarter().GetType());

            Assert.AreEqual(changeOneDimeOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneDimeOnePenny.Coins[0].GetType(), new Dime().GetType());
            Assert.AreEqual(changeOneDimeOnePenny.Coins[1].GetType(), new Penny().GetType());

            Assert.AreEqual(changeOneNickelOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneNickelOnePenny.Coins[0].GetType(), new Nickel().GetType());
            Assert.AreEqual(changeOneNickelOnePenny.Coins[1].GetType(), new Penny().GetType());


            Assert.AreEqual(changeFourPennies.Coins.Count, 4);
            Assert.AreEqual(changeFourPennies.Coins[0].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[1].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[2].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[3].GetType(), new Penny().GetType());

        }
    }
}
