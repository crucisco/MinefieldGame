namespace CrucisCo.MinefieldGame.Tests
{
    public class MinefieldTests
    {
        [Test]
        public void SpecifiedMinesAreCreatedTest()
        {
            const int MinesToCreate = 8;
            // Arrange
            var minefield = new Minefield(4, MinesToCreate);

            // Act            

            // Assert
            int mineCounter = 0;
            foreach (var item in minefield.Mines)
            {
                if (item) mineCounter++;
            }

            Assert.That(mineCounter, Is.EqualTo(MinesToCreate));
        }
    }
}