import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.LinkedList;

public class CustomerInfoServer {
    public static void main(String[] args) throws IOException {
        ServerSocket serverSocket;
        try{
            serverSocket = new ServerSocket(1211);
        } catch(IOException e){
            System.out.println("Error creating a server!");
        }

        LinkedList<String>  listOfBranches = new LinkedList<String>();
        LinkedList<Customer> listOfCustomers = new LinkedList<Customer>();

        Thread thread = new MultiThread();
        Socket clientSocket = null;
        while(true){
            try{
                clientSocket = serverSocket.accept();

                new MultiThread(serverSocket, clientSocket, listOfBranches, listOfCustomers).start();
            }
            catch(IOException e){
                e.printStackTrace();
            }
        }
    }
}
