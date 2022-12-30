import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
    public static void main(String[] args) {
        //first option
        //ServerSocket serverSocket = new ServerSocket(1234);

        //second option
        ServerSocket serverSocket = null;
        try{
            serverSocket = new ServerSocket(1234);
        } catch (IOException e){
            System.out.println("Server cannot start");
        }

        while(true){
            System.out.println("Waiting for the connection with the client");
            try{
                Socket socket = serverSocket.accept();
                ThreadServerClient threadOne = new ThreadServerClient(socket);
                threadOne.start();
                threadOne.reservation();
            } catch (IOException e){
                System.out.printf("Connection with the client failed");
            }
        }
    }
}
