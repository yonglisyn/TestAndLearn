using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestAndLearn.Tests
{
    [TestFixture()]
    public class ExplicitInterfaceTest
    {
        [Test]
        public void Why_Use_Explicit_Interface_Implementation()
        {
            //Arrange
            IStore store = new SuperMarket("storeName","storeOwner");
            store.TellMeWhy("I cannot access IsSoftDrink and SetAvailableBrands, because I am nobody");
            var storeWithBodyWash = (IStoreBodyWash) store;
            store.TellMeWhy("I am able to access IsSoftDrink, coz I am storeWithBodyWash");
            store.SetAvailableBrands();
            store.TellMeWhy($"{nameof(store.SetAvailableBrands)} is without public modifier, cannot be accessed with a case of {nameof(IStoreBodyWash)}");
            store.TellMeWhy($"I am able to access {nameof(IOldStore.IsApplePayAvailable)} coz {nameof(IOldStore.IsApplePayAvailable)} is implemented with public modifier");

            Assert.IsTrue(true);
            //store

        }
    }

    public partial class SuperMarket : IStore
    {
        public SuperMarket(string storename, string storeowner)
        {
            StoreName = storename;
            StoreOwner = storeowner;
        }
        public string StoreName { get; }
        public string StoreOwner { get; }

        public void TellMeWhy(string why)
        {
            TestContext.WriteLine(why);
        }
        public void Summary(string summary)
        {
            TestContext.WriteLine(summary);
        }

    }
    partial class SuperMarket
    {
        void IStoreBodyWash.SetAvailableBrands()
        {
            TestContext.WriteLine($"I am {nameof(IStoreBodyWash.SetAvailableBrands)}");
        }
    }
    partial class SuperMarket
    {
        
        public bool IsApplePayAvailable 
        {
            get
            {
                TestContext.WriteLine($"I am {nameof(IOldStore.IsApplePayAvailable)}");
                return true;
            }
            
        }
    }

    public interface IStore : IStoreBodyWash,IOldStore
    {
        string StoreName { get; }
        string StoreOwner { get; }
        void TellMeWhy(string why);
        void Summary(string summary);
    }

    public interface IStoreBodyWash
    {
        void SetAvailableBrands();
    }

    public interface IOldStore
    {
        bool IsApplePayAvailable { get; }
    }
}
