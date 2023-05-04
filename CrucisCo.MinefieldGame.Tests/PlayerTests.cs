namespace CrucisCo.MinefieldGame.Tests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MoveRightIncrementsXPosition()
        {
            // Arrange
            var player = new Player(4, 4, 1, 8);

            // Act
            player.Move(Direction.Right);

            // Assert
            Assert.That(player.PosX, Is.EqualTo(5));
            Assert.That(player.PosY, Is.EqualTo(4));
        }

        [Test]
        public void MoveDownIncrementsYPosition()
        {
            // Arrange
            var player = new Player(4, 4, 1, 8);

            // Act
            player.Move(Direction.Down);

            // Assert
            Assert.That(player.PosY, Is.EqualTo(5));
            Assert.That(player.PosX, Is.EqualTo(4));
        }

        [Test]
        public void MoveLeftDecrementsXPosition()
        {
            // Arrange
            var player = new Player(4, 4, 1, 8);

            // Act
            player.Move(Direction.Left);

            // Assert
            Assert.That(player.PosX, Is.EqualTo(3));
            Assert.That(player.PosY, Is.EqualTo(4));
        }

        [Test]
        public void MoveUpIncrementsYPosition()
        {
            // Arrange
            var player = new Player(4, 4, 1, 8);

            // Act
            player.Move(Direction.Up);

            // Assert
            Assert.That(player.PosY, Is.EqualTo(3));
            Assert.That(player.PosX, Is.EqualTo(4));
        }

        [Test]
        public void MoveLeftAtZeroXPositionShouldNotResultInAMove()
        {
            // Arrange
            var player = new Player(0, 4, 1, 8);

            // Act
            player.Move(Direction.Left);

            // Assert
            Assert.That(player.PosX, Is.EqualTo(0));
            Assert.That(player.PosY, Is.EqualTo(4));
        }

        [Test]
        public void MoveRightAtMaxXPositionShouldNotResultInAMove()
        {
            // Arrange
            var player = new Player(7, 4, 1, 8);

            // Act
            player.Move(Direction.Right);

            // Assert
            Assert.That(player.PosX, Is.EqualTo(7));
            Assert.That(player.PosY, Is.EqualTo(4));
        }

        [Test]
        public void MoveUpAtZeroYPositionShouldNotResultInAMove()
        {
            // Arrange
            var player = new Player(4, 0, 1, 8);

            // Act
            player.Move(Direction.Up);

            // Assert
            Assert.That(player.PosX, Is.EqualTo(4));
            Assert.That(player.PosY, Is.EqualTo(0));
        }

        [Test]
        public void MoveDownAtMaxYPositionShouldNotResultInAMove()
        {
            // Arrange
            var player = new Player(4, 7, 1, 8);

            // Act
            player.Move(Direction.Down);

            // Assert
            Assert.That(player.PosX, Is.EqualTo(4));
            Assert.That(player.PosY, Is.EqualTo(7));
        }
    }
}