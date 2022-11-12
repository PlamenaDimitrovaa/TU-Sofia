public class Main {
    public static void main(String[] args) {
        Payable[] payables = new Payable[2];
        payables[0] = new DebitAccount(100.00, 0.3);
        System.out.println(payables[0].pay());
        System.out.println();
        payables[1] = new CreditAccount(100.00, 0.3, 3);
        System.out.println(payables[1].pay());
    }
}
