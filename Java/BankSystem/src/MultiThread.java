import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.LinkedList;

public class MultiThread {

    ServerSocket serverSocket;

    LinkedList<String> listOfBranches;

    LinkedList<Customer> listOfCustomers;

    private static ObjectInputStream din;

    private static ObjectOutputStream dout;

    Socket clientSocket;

    public MultiThread(ServerSocket serverSocket, Socket clientSocket,
                       LinkedList<String> listOfBranches, LinkedList<Customer> listOfCustomers) {
        this.serverSocket = serverSocket;
        this.clientSocket = clientSocket;
        this.listOfBranches = listOfBranches;
        this.listOfCustomers = listOfCustomers;
    }

    public void run() throws IOException {
        try {
            din = new ObjectInputStream(clientSocket.getInputStream());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}