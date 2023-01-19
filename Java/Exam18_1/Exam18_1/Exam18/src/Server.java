import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.PrintStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import static java.lang.System.in;
import static java.lang.System.out;
import static java.util.stream.Nodes.collect;

public class Server {

    private final static String file = "txt.bin";
    private ServerSocket serverSocket;

    public List<Regex> loadRegex() {
        try {
            ObjectInputStream in = new ObjectInputStream(new FileInputStream(file))
            return (List<Regex>) in.readObject();

        } catch (IOException e) {
            e.printStackTrace();
        }

        return null;
    }

    public void saveRegex(List<Regex> regexes) {
        List<Regex> regexList = loadRegex();
        for (Regex reg : regexes) {
            if (regexList.contains(reg)) {
                regexes.remove(reg);
            }
        }

        try (ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream(file))) {
            out.writeObject(regexes);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void start() {
        try {
            serverSocket = new ServerSocket(8080);
            while (true) {
                Socket client = serverSocket.accept();

                Thread clientThread = new Thread(() ->
                {
                    Scanner sc = null;
                    PrintStream out = null;

                    try {
                        sc = new Scanner(client.getInputStream());
                        out = new PrintStream(client.getOutputStream());
                        regexMenu(sc, out);
                    } catch (IOException e) {
                        e.printStackTrace();
                    } finally {
                        if (sc != null)
                            sc.close();
                        if (out != null)
                            out.close();
                    }
                });

                clientThread.start();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void regexMenu(Scanner scanner, PrintStream out) {
        String command = scanner.nextLine();

        switch (command) {
            case "CREATE": {
                Create(scanner, out);
            }
            case "SEARCH": {
                Search(scanner, out);
            }

        }
    }

    public void Create(Scanner scanner, PrintStream out) {

        String createPattern = scanner.nextLine();
        String createDescription = scanner.nextLine();
        Regex regex = new Regex(createPattern, createDescription);
        int lines = scanner.nextInt();
        String[] createStr = new String[lines];
        for (int i = 0; i < lines; ++i) {
            createStr[i] = scanner.nextLine();
        }
        out.println(RegexTester.test(regex, createStr));

        String fileAdd = scanner.nextLine();

        switch (fileAdd) {
            case "N":
                return;
            case "Y": {
                synchronized (this) {
                    List<Regex> regexes = loadRegex();
                    regexes.add(regex);
                    saveRegex(regexes);
                }
            }
            default: {
                out.println("Wrong");
            }
        }
    }

    public void Search(Scanner scanner, PrintStream out) {
        String Keyword = scanner.nextLine();

        synchronized (this) {
            List<Regex> resultList = new ArrayList<Regex>();
            List<Regex> regexes = loadRegex();

            for (Regex create : regexes) {
                if (create.getDescription().contains(Keyword)) {
                    resultList.add(create);
                }
                List<Regex> sortedRegex = resultList
                        .stream()
                        .sorted(Comparator.comparing(Regex::getRating()))
                        .collect(Collectors.toList());
				
				//A redefined toString method in class Regex can also be used
                for (Regex regs : sortedRegex) {
                    out.println("Regex{" +
					"id=" + regs.getId() +
					", pattern='" + regs.getPattern() + '\'' +
					", description='" + regs.getDescription() + '\'' +
					", rating=" + regs.getRating() +
					'}');
                }
				
                int testing = scanner.nextInt();
                Regex chosenRegex = null;
                for (Regex regex : sortedRegex) {
                    if (regex.getId() == testing) {
                        chosenRegex = regex;
                    }
                }
                if (chosenRegex == null) {
                    return;
                }
                int lines = scanner.nextInt();
                String[] strings = new String[lines];
                for (int i = 0; i < lines; i++) {
                    strings[i] = scanner.nextLine();
                }

                out.println(RegexTester.test(chosenRegex, strings));

                String rate = scanner.nextLine();

                switch (rate) {
                    case "N": {
                        return;
                    }
                    case "H":
                        synchronized (this) {
                            List<Regex> createReg = loadRegex();
                            createReg.remove(chosenRegex);
                            chosenRegex.setRating(chosenRegex.getRating() + 1);
                            createReg.add(chosenRegex);
                            saveRegex(createReg);
                        }
                    case "L": {
                        synchronized (this) {
                            List<Regex> createReg = loadRegex();
                            createReg.remove(chosenRegex);
                            chosenRegex.setRating(chosenRegex.getRating() - 1);
                            createReg.add(chosenRegex);
                            saveRegex(createReg);
                        }
                    }
                }

            }
        }
    }
}






