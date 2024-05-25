using CarLibrary;

namespace Lab13.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddMethod()
        {
            MyObservableCollection<Car> coll = new MyObservableCollection<Car>("First");

            LightCar car = new LightCar();
            car.RandomInit();

            Journal journal = new Journal();
            coll.CollectionCountChanged += journal.CollectionCountChanged;

            coll.Add(car);

            Assert.AreEqual(1, coll.Count);
            Assert.AreEqual(1, journal.JournalEntries.Count);

            JournalEntry entry = journal.JournalEntries[0];
            Assert.AreEqual("add", entry.TypeChange);
            Assert.AreEqual(car.ToString(), entry.DataObject);
        }

        [TestMethod]
        public void TestRemoveMethod()
        {
            MyObservableCollection<Car> coll = new MyObservableCollection<Car>("First");

            LightCar car = new LightCar();
            car.RandomInit();

            HeavyCar heavyCar = new HeavyCar();
            heavyCar.RandomInit();

            MiddleCar middleCar = new MiddleCar();
            middleCar.RandomInit();

            Journal journal1 = new Journal();
            coll.CollectionCountChanged += journal1.CollectionCountChanged;

            coll.Add(car);
            coll.Add(heavyCar);
            coll.Add(middleCar);

            coll.Remove(heavyCar);

            Assert.AreEqual(2, coll.Count);
            Assert.AreEqual(journal1.JournalEntries.Count, 4);

            JournalEntry journalEntry = journal1.JournalEntries[3];
            Assert.AreEqual("remove", journalEntry.TypeChange);
            Assert.AreEqual(heavyCar.ToString(), journalEntry.DataObject);
        }

        [TestMethod]
        public void TestChangeMethod()
        {
            MyObservableCollection<Car> coll = new MyObservableCollection<Car>("First");

            LightCar car = new LightCar();
            car.RandomInit();

            HeavyCar heavyCar = new HeavyCar();
            heavyCar.RandomInit();

            MiddleCar middleCar = new MiddleCar();
            middleCar.RandomInit();

            Journal journal = new Journal();
            coll.CollectionReferenceChanged += journal.CollectionReferenceChanged;

            coll.Add(car);
            coll.Add(heavyCar);

            coll[car] = middleCar;

            Assert.AreEqual(2, coll.Count);
            Assert.AreEqual(1, journal.JournalEntries.Count);
            Assert.AreEqual("changed", journal.JournalEntries[0].TypeChange);
            Assert.AreEqual(middleCar.ToString(), journal.JournalEntries[0].DataObject);
        }
    }
}