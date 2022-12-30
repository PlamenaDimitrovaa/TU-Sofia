import java.io.IOException;
import java.net.Socket;

public class Client {
    public static void Main(String[] args)throws IOException {
        Socket socket = new Socket("localhost", 1234 );
    }
}
