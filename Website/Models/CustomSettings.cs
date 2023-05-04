namespace Website.Models;

public class CustomSettings {
    public string AppName { get; set; }
    public int Port { get; set; }
    public EmailSettings Email { get; set; }

}

public class EmailSettings {
    public string Smtp { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
}
