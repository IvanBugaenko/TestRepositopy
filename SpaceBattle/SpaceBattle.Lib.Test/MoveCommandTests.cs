using Moq;

namespace SpaceBattle.Lib.Test;

public class MoveTests
{
    [Fact]
    public void SetPosErr()
    {
        Mock<IMovable> m = new Mock<IMovable>();
        m.SetupProperty(m => m.Pos, new Vector(12, 5));
        m.SetupGet<Vector>(m => m.Speed).Returns(new Vector(-7, 3));
        m.SetupSet(m => m.Pos = It.IsAny<Vector>()).Throws<Exception>();
        var c = new MoveCommand(m.Object);

        Assert.Throws<Exception>(() => c.Execute());
    }

    [Fact]
    public void GetSpeedErr()
    {
        Mock<IMovable> m = new Mock<IMovable>();
        m.SetupProperty(m => m.Pos, new Vector(12, 5));
        m.SetupGet<Vector>(m => m.Speed).Throws<Exception>();
        var c = new MoveCommand(m.Object);

        Assert.Throws<Exception>(() => c.Execute());
    }
}
