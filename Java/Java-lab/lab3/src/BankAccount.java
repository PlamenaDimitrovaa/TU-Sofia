public abstract class BankAccount implements Payable{
    private double amount;
    private double interest;

    public BankAccount(double amount, double interest) {
        this.amount = amount;
        this.interest = interest;
    }

    public double getAmount() {
        return amount;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    public double getInterest() {
        return interest;
    }

    public void setInterest(double interest) {
        this.interest = interest;
    }
}
