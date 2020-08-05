using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace TestingParkingCost 
{
    public class TestingParkingLot : IDisposable
    {
        private IWebDriver _webDriver;
 
        public void Dispose()
        {
            _webDriver.Close();
        }

        [Fact]
        public void Test_Valet_6Hours()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Valet&StartingDate=8%2F4%2F2020&StartingTime=10%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F4%2F2020&LeavingTime=4%3A00&LeavingTimeAMPM=PM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 18.00", _webDriver.FindElement(By.CssSelector("b")).Text);
        }

        [Fact]
        public void Test_Valet_1Day_1Hour()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Valet&StartingDate=8%2F4%2F2020&StartingTime=15%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F5%2F2020&LeavingTime=16%3A00&LeavingTimeAMPM=AM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 36.00",_webDriver.FindElement(By.CssSelector("b")).Text );
        }


        [Fact]
        public void Test_Valet_5_and_half_Hours()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Valet&StartingDate=8%2F4%2F2020&StartingTime=10%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F4%2F2020&LeavingTime=15%3A30&LeavingTimeAMPM=AM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 18.00", _webDriver.FindElement(By.CssSelector("b")).Text);
        }

        [Fact]
        public void Test_ShortTerm_1hour()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Short&StartingDate=8%2F4%2F2020&StartingTime=10%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F4%2F2020&LeavingTime=11%3A00&LeavingTimeAMPM=AM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 2.00", _webDriver.FindElement(By.CssSelector("b")).Text);
        }

        [Fact]
        public void Test_ShortTerm_13hour()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Short&StartingDate=8%2F4%2F2020&StartingTime=01%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F4%2F2020&LeavingTime=14%3A00&LeavingTimeAMPM=AM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 24.00", _webDriver.FindElement(By.CssSelector("b")).Text);
        }


        [Fact]
        public void Test_LongtTermGarage_1week_1hour()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Long-Garage&StartingDate=8%2F4%2F2020&StartingTime=07%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F11%2F2020&LeavingTime=08%3A00&LeavingTimeAMPM=AM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 74.00", _webDriver.FindElement(By.CssSelector("b")).Text);
        }


        [Fact]
        public void Test_LongtTermSurface_1hour()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Long-Surface&StartingDate=8%2F4%2F2020&StartingTime=07%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F4%2F2020&LeavingTime=08%3A00&LeavingTimeAMPM=AM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 2.00", _webDriver.FindElement(By.CssSelector("b")).Text);
        }

        [Fact]
        public void Test_EconomyLot_5hours()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Economy&StartingDate=8%2F4%2F2020&StartingTime=07%3A00&StartingTimeAMPM=AM&LeavingDate=8%2F4%2F2020&LeavingTime=12%3A00&LeavingTimeAMPM=PM&action=calculate&Submit=Calculate");
            Assert.Equal("$ 9.00", _webDriver.FindElement(By.CssSelector("b")).Text);
        }


        [Fact]
        public void Test_EmptyEntryHour()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://www.shino.de/parkcalc/index.php?ParkingLot=Valet&StartingDate=8%2F3%2F2020&StartingTime=&StartingTimeAMPM=AM&LeavingDate=8%2F4%2F2020&LeavingTime=08%3A00&LeavingTimeAMPM=AM&action=calculate&Submit=Calculate");
            Assert.Equal("ERROR!",_webDriver.FindElement(By.CssSelector("b")).Text);
        }
    }
}
