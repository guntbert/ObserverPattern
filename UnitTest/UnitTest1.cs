using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverPattern;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestSetup()
        {
            CurrentWeather sut = null;
            sut = new CurrentWeather();
            //cw.WeatherChange += new EventHandler<WeatherChangeEventArgs>();
        }

        [TestMethod]
        public void ShouldHaveSameZipCodeOnCreate()
        {
            //Arrange
            CurrentWeather sut = null;
            sut = new CurrentWeather();
            //Act
            sut.Weather = new Weather { City = "37203", Temp = 61 };
            //Assert
            Assert.AreEqual(sut.Weather.City, "37203"); 
        }

        [TestMethod]
        public void ShouldHaveSameTempOnCreate()
        {
            //Arrange
            CurrentWeather sut = null;
            sut = new CurrentWeather();
            //Act
            sut.Weather = new Weather { City = "37203", Temp = 61 };
            //Assert
            Assert.AreEqual(sut.Weather.Temp, 61);
        }

        [TestMethod]
        public void ShouldNotHaveSameTempOnCreate()
        {
            //Arrange
            CurrentWeather sut = null;
            sut = new CurrentWeather();

            //Act
            sut.Weather = new Weather { City = "37027", Temp = 56 };

            //Assert
            Assert.AreNotEqual(sut.Weather.Temp, 61);
        }
        
        [TestMethod]
        public void ShouldNotHaveSameZipCodeOnCreate()
        {
            //Arrange
            CurrentWeather sut = null;
            sut = new CurrentWeather();

            //Act
            sut.Weather = new Weather { City = "37027", Temp = 61 };

            //Assert
            Assert.AreNotEqual(sut.Weather.City, "37203");
        }

        [TestMethod]
        public void ShouldHaveNullZipCodeOnCreate()
        {
            //Arrange
            CurrentWeather sut = null;
            sut = new CurrentWeather();

            //Act
            sut.Weather = new Weather { City = null, Temp = 61 };

            //Assert
            Assert.IsNull(sut.Weather.City);
        }

        [TestMethod]
        public void ShouldHaveEmptyZipCodeOnCreate()//Not quite Sure
        {
            //Arrange
            CurrentWeather sut = null;
            sut = new CurrentWeather();

            //Act
            sut.Weather = new Weather { City = "", Temp = 61 };

            //Assert
            Assert.AreEqual(sut.Weather.City, "");
        }
//--------------------------------
        [TestMethod]
        public void ShouldOnlyChangeNashvilleOnTempUpdateForCity()
        {
            //Arrange
            CurrentWeather cw = new CurrentWeather();
            NashvilleMonitor sut = new NashvilleMonitor(cw);
            BrentwoodMonitor sut2 = new BrentwoodMonitor(cw);

            //Act
            cw.Weather = new Weather { City = "37203", Temp = 50 };
            cw.Weather = new Weather { City = "37027", Temp = 50 };
            cw.Weather = new Weather { City = "37203", Temp = 61 };

            //Assert
            Assert.AreEqual(sut.currentCityWeather.Temp, 61);
            Assert.AreNotEqual(sut2.currentCityWeather.Temp, 61);
        }

        [TestMethod]
        public void ShouldNotChangeNashvilleOnTempUpdateForCity()
        {
            //Arrange
            CurrentWeather cw = new CurrentWeather();
            NashvilleMonitor sut = new NashvilleMonitor(cw);

            //Act
            cw.Weather = new Weather { City = "37203", Temp = 50 };
            cw.Weather = new Weather { City = "37204", Temp = 61 };

            //Assert
            Assert.AreNotEqual(sut.currentCityWeather.Temp, 61);
        }

        [TestMethod]
        public void ShouldOnlyChangeBrentwoodOnTempUpdateForCity()
        {
            //Arrange
            CurrentWeather cw = new CurrentWeather();
            BrentwoodMonitor sut = new BrentwoodMonitor(cw);
            NashvilleMonitor sut2 = new NashvilleMonitor(cw);

            //Act
            cw.Weather = new Weather { City = "37203", Temp = 50 };
            cw.Weather = new Weather { City = "37027", Temp = 50 };
            cw.Weather = new Weather { City = "37027", Temp = 61 };

            //Assert
            Assert.AreEqual(sut.currentCityWeather.Temp, 61);
            Assert.AreNotEqual(sut2.currentCityWeather.Temp, 61);
        }

        [TestMethod]
        public void ShouldObserverNotMatchZipCode()
        {
            //Arrange
            CurrentWeather cw = new CurrentWeather();
            NashvilleMonitor sut = new NashvilleMonitor(cw);

            //Act
            cw.Weather = new Weather { City = "37203", Temp = 61 };

            //Assert
            Assert.AreNotEqual(sut.currentCityWeather.City, "37027");
        }

        [TestMethod]
        public void ShouldNashvilleObserverMatchTemp()
        {
            //Arrange
            CurrentWeather cw = new CurrentWeather();
            NashvilleMonitor sut = new NashvilleMonitor(cw);

            //Act
            cw.Weather = new Weather { City = "37203", Temp = 61 };

            //Assert
            Assert.AreEqual(sut.currentCityWeather.Temp, 61);
        }

        [TestMethod]
        public void ShouldBrentwoodObserverMatchTemp()
        {
            //Arrange
            CurrentWeather cw = new CurrentWeather();
            BrentwoodMonitor sut = new BrentwoodMonitor(cw);

            //Act
            cw.Weather = new Weather { City = "37027", Temp = 61 };

            //Assert
            Assert.AreEqual(sut.currentCityWeather.Temp, 61);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //
        }
    }
}
