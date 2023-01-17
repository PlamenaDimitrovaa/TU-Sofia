import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.HashMap;
import java.util.LinkedList;

public class Server {

    final static LinkedList<Document> normalDocs = new LinkedList<>();
    final static LinkedList<Document> specialDocs = new LinkedList<>();
    final static HashMap<String, Integer> approved = new HashMap<>();
    private final static String APPROVED_PASSWORD = "secret";

    public static void main(String[] args) {
        ConnectionThread student;
        ConnectionThread secretary;
        try {
            student = new ConnectionThread(5000, true);
            secretary = new ConnectionThread(5001, false);
        } catch (IOException e) {
            System.out.println("Can't start server");
            return;
        }
        student.start();
        secretary.start();

        ServerSocket ss;
        try {
            ss = new ServerSocket(5002);
        } catch (IOException e) {
            System.out.println("WARNING: Approved service failed to start!!!");
            return;
        }
        while (true) {
            try (Socket sock = ss.accept()) {
                ObjectInputStream in = new ObjectInputStream(sock.getInputStream());
                ObjectOutputStream out = new ObjectOutputStream(sock.getOutputStream());
                out.flush();
                out.writeUTF("Please send your password");
                out.flush();
                String userPass = in.readUTF();
                if (!userPass.equals(APPROVED_PASSWORD)) {
                    out.writeUTF("BAD PASSWORD. BYE");
                    out.flush();
                    continue;
                }
                out.writeUTF("OK");
                Document doc = (Document) in.readObject();
                synchronized (Server.approved) {
                    Integer i = Server.approved.get(doc.getName());
                    if (i == null) {
                        i = 0;
                    }

                    Server.approved.put(doc.getName(), i + 1);

                    out.writeInt(i + 1);
                    out.flush();
                }
            } catch (IOException e) {
                System.out.println("Secretary IO error in approved thread");
            } catch (ClassNotFoundException ex) {
                System.out.println("Secretary sent wrong object in approved thread");
            }
        }
    }
}

class ConnectionThread extends Thread {

    ServerSocket ss;
    boolean isStudentAccepted;

    ConnectionThread(int port, boolean isStudentAccepted) throws IOException {
        this.ss = new ServerSocket(port);
        this.isStudentAccepted = isStudentAccepted;
    }

    @Override
    public void run() {
        while (true) {
            Socket sock;
            try {
                sock = this.ss.accept();
                Thread t;
                if (this.isStudentAccepted) {
                    System.out.println("Student connected");
                    t = new StudentThread(sock);
                } else {
                    System.out.println("Secretary connected");
                    t = new SecretariesThread(sock);
                }
                t.start();
            } catch (IOException e) {
                System.out.println("New connection failure");
            }
        }
    }
}

class StudentThread extends Thread {

    Socket sock;

    StudentThread(Socket sock) {
        this.sock = sock;
    }

    @Override
    public void run() {
        try (ObjectOutputStream out = new ObjectOutputStream(this.sock.getOutputStream())) {
            out.writeUTF("Send docType: \"normal\" or \"special\"");
            out.flush();
            try (ObjectInputStream in = new ObjectInputStream(this.sock.getInputStream())) {
                String docType = in.readUTF();
                if (docType.equals("normal") || docType.equals("special")) {
                    out.writeUTF("OK");
                    out.flush();
                } else {
                    out.writeUTF("BAD TYPE");
                    out.flush();
                    this.sock.close();
                    return;
                }

                Document doc = (Document) in.readObject();
                if (docType.equals("normal")) {
                    synchronized (Server.normalDocs) {
                        Server.normalDocs.add(doc);
                    }
                    System.out.println("New normal document saved.");
                } else {
                    synchronized (Server.specialDocs) {
                        Server.specialDocs.add(doc);
                    }
                    System.out.println("New special document saved");
                }

            } catch (ClassNotFoundException ex) {
                System.out.println("Client sent invalid object");
            }
        } catch (IOException ex) {
            System.out.println("IO problem with student thread");
        }
    }
}

class SecretariesThread extends Thread {

    Socket sock;
    private final static String PASSWORD = "secret";

    SecretariesThread(Socket sock) {
        this.sock = sock;
    }

    @Override
    public void run() {
        try (ObjectOutputStream out = new ObjectOutputStream(this.sock.getOutputStream())) {
            out.writeUTF("Send your password");
            out.flush();
            try (ObjectInputStream in = new ObjectInputStream(this.sock.getInputStream())) {
                String userPass = in.readUTF();
                if (userPass.equals(SecretariesThread.PASSWORD)) {
                    out.writeUTF("OK");
                    out.flush();
                    System.out.println("Secretary connected");
                } else {
                    out.writeUTF("BAD PASSWORD");
                    out.flush();
                    this.sock.close();
                    System.out.println("Bad password for secretary connection");
                    return;
                }
                Document doc;
                synchronized (Server.specialDocs) {
                    if (!Server.specialDocs.isEmpty()) {
                        out.writeUTF("special");
                        out.flush();
                        doc = Server.specialDocs.getFirst();
                        out.writeObject(doc);
                        out.flush();
                        Server.specialDocs.removeFirst();
                        System.out.println("Special doc sent to secretary");
                        return;
                    }
                }

                synchronized (Server.normalDocs) {
                    if (!Server.normalDocs.isEmpty()) {
                        out.writeUTF("normal");
                        out.flush();
                        doc = Server.normalDocs.getFirst();
                        out.writeObject(doc);
                        out.flush();
                        Server.normalDocs.removeFirst();
                        System.out.println("Normal doc sent to secretary");
                        return;
                    }
                }
                out.writeUTF("NO DOCS");
                out.flush();
            }
        } catch (IOException ex) {
            System.out.println("IO error with secretary: " + ex.getMessage());
        }
    }
}
