namespace Website.Services;

public interface IMyService {
    Guid Uid { get; set; }
}

public class MyService : IMyService {
    public MyService(IConfiguration config) {
    }

    public Guid Uid { get; set; } = Guid.NewGuid();
}

public class MyServiceMock : IMyService {
    public MyServiceMock(IConfiguration config) {
    }

    public Guid Uid { get; set; } = Guid.NewGuid();
}
